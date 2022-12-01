using ILogNameSpace;
using ISerializeNameSpace;
using StorageNameSpace;
using System.Text.RegularExpressions;
using ConsoleLogNameSpace;
using DVDNameSpace;
using FlashNameSpace;
using HDDNameSpace;
using SomeInfoGeneratorNameSpace;

namespace PriceListNameSpace
{
    public class PriceList
    {
        List<Storage> list = new List<Storage>();

        // Количество элементов в коллекции.
        public int Count => list.Count;

        // Добавлениe носителя информации в список.
        public void Add(Storage storage)
        {
            list.Add(storage);
        }

        // Удалениe носителя информации из списка по заданному критерию. 
        public void Remove(int index)
        {
            try
            {
                list.RemoveAt(index - 1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }

        // Изменение параметров носителя по выбранному индексу в зависимости от типа носителя.
        public void Change(int index)
        {
            // Проверка на выход за границы списка.
            if (index > list.Count || index < 1)
            {
                Console.WriteLine("Неверный индекс!");
                return;
            }
            // Редактирование данных носителя информации в зависимости от выбранного типа носителя.
            switch (list.ElementAt(index - 1).GetType().Name)
            {
                case "DVD":
                    // Редактирование данных DVD.
                    Console.WriteLine("Введите новое имя производителя: ");
                    list.ElementAt(index - 1).Manufacturer = Console.ReadLine();
                    Console.WriteLine("Введите новую модель: ");
                    list.ElementAt(index - 1).Model = Console.ReadLine();
                    try
                    {
                        Console.WriteLine("Введите новую ёмкость носителя: ");
                        list.ElementAt(index - 1).Capacity = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Неверный формат данных!");
                        // Установить значение по умолчанию для этого поля.
                        list.ElementAt(index - 1).Capacity = default;
                    }

                    try
                    {
                        Console.WriteLine("Введите новое количество носителей: ");
                        list.ElementAt(index - 1).Quantity = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Неверный формат данных!");
                        // Установить значение по умолчанию для этого поля.
                        list.ElementAt(index - 1).Quantity = default;
                    }

                    try
                    {
                        Console.WriteLine("Введите новую скорость чтения/записи: ");
                        (list.ElementAt(index - 1) as DVD).WriteSpeed = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Неверный формат данных!");
                        // Установить значение по умолчанию для этого поля.
                        (list.ElementAt(index - 1) as DVD).WriteSpeed = default;
                    }
                    break;

                    // todo: продолжить для остальных ...


            }


        }



        // Поиск носителя информации по заданному критерию и вывод его на экран.
        public void Search(string search)
        {
            // Поиск по всем полям на совпадение подстроки в зависимости от типа носителя информации.
            int i = 1;
            foreach (Storage storage in list)
            {
                if (storage is DVD)
                {
                    DVD dvd = (DVD)storage;
                    if (dvd.Manufacturer.Contains(search) || dvd.Model.Contains(search) ||
                        dvd.Capacity.ToString().Contains(search) || dvd.Quantity.ToString().Contains(search) ||
                        dvd.WriteSpeed.ToString().Contains(search))
                    {
                        Console.WriteLine("Носитель № " + i);
                        dvd.ReportOutput(new ConsoleLog());
                        Console.WriteLine();
                    }
                }
                else if (storage is Flash)
                {
                    Flash flash = (Flash)storage;
                    if (flash.Manufacturer.Contains(search) || flash.Model.Contains(search) ||
                        flash.Capacity.ToString().Contains(search) || flash.Quantity.ToString().Contains(search) ||
                        flash.Speed.ToString().Contains(search))
                    {
                        Console.WriteLine("Носитель № " + i);
                        flash.ReportOutput(new ConsoleLog());
                        Console.WriteLine();
                    }
                }
                else if (storage is HDD)
                {
                    HDD hdd = (HDD)storage;
                    if (hdd.Manufacturer.Contains(search) || hdd.Model.Contains(search) ||
                        hdd.Capacity.ToString().Contains(search) || hdd.Quantity.ToString().Contains(search) ||
                        hdd.SpindleSpeed.ToString().Contains(search))
                    {
                        Console.WriteLine("Носитель № " + i);
                        hdd.ReportOutput(new ConsoleLog());
                        Console.WriteLine();
                    }
                }
                i++;
            }
        }

        // Вывод информации о списке носителей, взависимости от входящего параметра.
        public void ReportOutput(ILog log)
        {
            // Проверка на пустоту списка.
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }
            // Смотрим что пришло в качестве параметра (ConsoleLog или FileLog).
            if (log.GetType().Name == "ConsoleLog")
            {
                // Выводим в консоль информацию о носителях.
                int i = 1;
                foreach (Storage storage in list)
                {
                    Console.WriteLine("Носитель № " + i);
                    i++;
                    Console.WriteLine($"{storage.GetType().Name}");
                    storage.ReportOutput(log);
                    Console.WriteLine();
                }
            }
        }

        // Метод сохранения списка носителей информации в файл.
        public void Save(ISerialize iSerialize)
        {
            // Смотрим что пришло в качестве параметра (BinarySerialize или JSONSerialize или XMLSerialize).
            if (iSerialize.GetType().Name == "BinarySerialize")
            {
                iSerialize.Save(list);
            }
            else if (iSerialize.GetType().Name == "JSONSerialize")
            {
                iSerialize.Save(list);
            }
            else if (iSerialize.GetType().Name == "XMLSerialize")
            {
                iSerialize.Save(list);
            }
        }

        // Метод загрузки списка носителей информации из файла.
        public void Load(ISerialize iSerialize)
        {
            // Смотрим что пришло в качестве параметра (BinarySerialize или JSONSerialize или XMLSerialize).
            if (iSerialize.GetType().Name == "BinarySerialize")
            {
                list = iSerialize.Load();
            }
            else if (iSerialize.GetType().Name == "JSONSerialize")
            {
                list = iSerialize.Load();
            }
            else if (iSerialize.GetType().Name == "XMLSerialize")
            {
                list = iSerialize.Load();
            }
        }

        // Индексатор
        public object this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = (Storage)value;
            }
        }
    }
}