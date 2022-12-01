using System.Runtime.Serialization.Json;
using System.Xml;
using ISerializeNameSpace;
using StorageNameSpace;

namespace JSONSerializeNameSpace
{
    public class JSONSerialize : ISerialize
    {
        // Метод принимает коллекцию для сохранения в файл.
        public void Save(List<Storage> list)
        {
            // Сериализация.
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            FileStream fs = new FileStream("StorageList_JSON.dat", FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(fs, list);
            fs.Close();
        }

        // Метод возвращает ссылку на коллекцию загруженную из файла.
        public List<Storage> Load()
        {
            // Десериализация.
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            FileStream fs = new FileStream("StorageList_JSON.dat", FileMode.OpenOrCreate);
            List<Storage> list = (List<Storage>)jsonFormatter.ReadObject(fs);
            fs.Close();
            return list;
        }
    }
}