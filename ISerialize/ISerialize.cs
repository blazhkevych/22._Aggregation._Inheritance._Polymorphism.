using StorageNameSpace;

namespace ISerializeNameSpace;

public interface ISerialize
{
    // Метод принимает коллекцию для сохранения в файл.
    void Save(List<Storage> list);

    // Метод возвращает ссылку на коллекцию загруженную из файла.
    List<Storage> Load();
}