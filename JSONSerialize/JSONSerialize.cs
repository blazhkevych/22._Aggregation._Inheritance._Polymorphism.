using ISerializeNameSpace;
using StorageNameSpace;

namespace JSONSerializeNameSpace
{
    public class JSONSerialize : ISerialize
    {
        // Метод принимает коллекцию для сохранения в файл.
        public void Save(List<Storage> list)
        {
            //throw new NotImplementedException();
        }

        // Метод возвращает ссылку на коллекцию загруженную из файла.
        public List<Storage> Load()
        {
            throw new NotImplementedException();
        }
    }
}