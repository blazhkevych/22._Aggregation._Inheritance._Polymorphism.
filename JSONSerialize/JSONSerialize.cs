using System.Runtime.Serialization.Json;
using ISerializeNameSpace;
using StorageNameSpace;

namespace JSONSerializeNameSpace;

public class JSONSerialize : ISerialize
{
    // Метод принимает коллекцию для сохранения в файл.
    public void Save(List<Storage> list)
    {
        // Сериализация.
        var jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
        var fs = new FileStream("StorageList_JSON.dat", FileMode.OpenOrCreate);
        jsonFormatter.WriteObject(fs, list);
        fs.Close();
    }

    // Метод возвращает ссылку на коллекцию загруженную из файла.
    public List<Storage> Load()
    {
        // Десериализация.
        var jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
        var fs = new FileStream("StorageList_JSON.dat", FileMode.OpenOrCreate);
        var list = (List<Storage>)jsonFormatter.ReadObject(fs);
        fs.Close();
        return list;
    }
}