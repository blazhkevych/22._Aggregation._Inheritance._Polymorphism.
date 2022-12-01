using ILogNameSpace;
using ISerializeNameSpace;
using StorageNameSpace;
using System.Text.RegularExpressions;
using DVDNameSpace;
using SomeInfoGeneratorNameSpace;

namespace PriceListNameSpace
{
    public class PriceList
    {
        List<Storage> list = new List<Storage>();

        // Добавлениe носителя информации в список.
        public void Add(Storage storage)
        {
            list.Add(storage);
        }

        // Удалениe носителя информации из списка по заданному критерию. // todo: сделать удаление по критерию.


        // Изменение определённых параметров носителя информации.


        // Поиск носителя информации по заданному критерию.


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
            else
            {
                // Выводим информацию в файл.
                foreach (Storage storage in list)
                {
                    storage.ReportOutput(log);
                }
            }
        }

        // Метод сохранения списка носителей информации в файл.
        public void Save(ISerialize iSerialize)
        {
            // Смотрим что пришло в качестве параметра (BinarySerialize или JSONSerialize или XMLSerialize).


        }

        // Метод загрузки списка носителей информации из файла.
        private void Load(ISerialize iSerialize)
        {
            // Смотрим что пришло в качестве параметра (BinarySerialize или JSONSerialize или XMLSerialize).
        }
    }
}