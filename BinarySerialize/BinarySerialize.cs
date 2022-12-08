using System.Runtime.Serialization.Formatters.Binary;
using ISerializeNameSpace;
using StorageNameSpace;

namespace BinarySerializeNameSpace;

public class BinarySerialize : ISerialize
{
    // Метод принимает коллекцию для сохранения в файл.
    public void Save(List<Storage> list)
    {
        // Сериализация.
        var formatter = new BinaryFormatter();
        var fs = new FileStream("StorageList_Binary.dat", FileMode.OpenOrCreate);
        formatter.Serialize(fs, list);
        fs.Close();
    }

    // Метод возвращает ссылку на коллекцию загруженную из файла.
    public List<Storage> Load()
    {
        // Десериализация.
        var formatter = new BinaryFormatter();
        var fs = new FileStream("StorageList_Binary.dat", FileMode.OpenOrCreate);
        var list = (List<Storage>)formatter.Deserialize(fs);
        fs.Close();
        return list;
    }
}