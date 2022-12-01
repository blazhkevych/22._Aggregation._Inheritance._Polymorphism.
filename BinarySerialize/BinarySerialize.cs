using System.Runtime.Serialization.Formatters.Binary;
using ILogNameSpace;
using ISerializeNameSpace;
using StorageNameSpace;

namespace BinarySerializeNameSpace
{
    public class BinarySerialize : ISerialize
    {
        // Метод принимает коллекцию для сохранения в файл.
        public void Save(List<Storage> list)
        {
            // Сериализация.
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("StorageList_Binary.dat", FileMode.OpenOrCreate);
            formatter.Serialize(fs, list);
            fs.Close();
        }

        // Метод возвращает ссылку на коллекцию загруженную из файла.
        public List<Storage> Load()
        {
            // Десериализация.
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("StorageList_Binary.dat", FileMode.OpenOrCreate);
            List<Storage> list = (List<Storage>)formatter.Deserialize(fs);
            fs.Close();
            return list;
        }
    }
}