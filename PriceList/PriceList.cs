using ILogNameSpace;
using ISerializeNameSpace;
using StorageNameSpace;

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
        private void Print(ILog log)
        {
            // Смотрим что пришло в качестве параметра (ConsoleLog или FileLog).
        }

        // Метод сохранения списка носителей информации в файл.
        private void Save(ISerialize iSerialize)
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