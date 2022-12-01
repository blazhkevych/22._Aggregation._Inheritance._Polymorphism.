using System.Xml.Serialization;
using ISerializeNameSpace;
using StorageNameSpace;

namespace XMLSerializeNameSpace
{
    public class XMLSerialize : ISerialize
    {
        // Метод принимает коллекцию для сохранения в файл.
        public void Save(List<Storage> list)
        {
            // Сериализация.
            XmlSerializer formatter = new XmlSerializer(typeof(List<Storage>));
            FileStream fs = new FileStream("StorageList_XML.dat", FileMode.OpenOrCreate);
            formatter.Serialize(fs, list);
            fs.Close();
        }

        // Метод возвращает ссылку на коллекцию загруженную из файла.
        public List<Storage> Load()
        {
            // Десериализация.
            XmlSerializer formatter = new XmlSerializer(typeof(List<Storage>));
            FileStream fs = new FileStream("StorageList_XML.dat", FileMode.OpenOrCreate);
            List<Storage> list = (List<Storage>)formatter.Deserialize(fs);
            fs.Close();
            return list;
        }
    }
}