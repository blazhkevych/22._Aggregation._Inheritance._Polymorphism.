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

        // Изменение определённых параметров носителя информации.


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
    }
}