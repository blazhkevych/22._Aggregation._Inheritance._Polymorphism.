using System.Runtime.Serialization;
using System.Xml.Serialization;
using ILogNameSpace;

namespace StorageNameSpace;

[Serializable]
[DataContract(Name = "Storage")]
// Для сериализации в JSON.
[KnownType(typeof(DVD))]
[KnownType(typeof(Flash))]
[KnownType(typeof(HDD))]
// Для сериализации в XML.
[XmlInclude(typeof(DVD))]
[XmlInclude(typeof(Flash))]
[XmlInclude(typeof(HDD))]
public abstract class Storage
{
    // Конструктор.
    public Storage(string manufacturer, string model, double capacity, int quantity)
    {
        Manufacturer = manufacturer;
        Model = model;
        Capacity = capacity;
        Quantity = quantity;
    }

    // Конструктор по умолчанию.
    public Storage()
    {
        Manufacturer = "Unknown";
        Model = "Unknown";
        Capacity = 0.0;
        Quantity = 0;
    }

    // Имя производителя.
    [DataMember] public string Manufacturer { get; set; }

    // Модель.
    [DataMember] public string Model { get; set; }

    // Ёмкость носителя.
    [DataMember] public double Capacity { get; set; }

    // Количество.
    [DataMember] public int Quantity { get; set; }

    // Метод вывода в консоль информации о носителе.
    public virtual void ReportOutput(ILog log)
    {
        log.ReportOutput("Manufacturer: " + Manufacturer);
        log.ReportOutput("Model: " + Model);
        log.ReportOutput("Capacity: " + Capacity);
        log.ReportOutput("Quantity: " + Quantity);
    }
}

[Serializable]
[DataContract(Name = "HDD")]
public class HDD : Storage
{
    // Конструктор.
    public HDD(string manufacturer, string model, double capacity, int quantity, double spindleSpeed)
        : base(manufacturer, model, capacity, quantity)
    {
        SpindleSpeed = spindleSpeed;
    }

    // Констор по умолчанию.
    public HDD()
    {
        SpindleSpeed = 0.0;
    }

    // Скорость вращения шпинделя.
    [DataMember] public double SpindleSpeed { get; set; }

    // Метод вывода в консоль информации о носителе.
    public override void ReportOutput(ILog log)
    {
        base.ReportOutput(log);
        log.ReportOutput("SpindleSpeed: " + SpindleSpeed);
    }
}

[Serializable]
[DataContract(Name = "Flash")]
public class Flash : Storage
{
    // Конструктор.
    public Flash(string manufacturer, string model, int capacity, int quantity, double speed)
        : base(manufacturer, model, capacity, quantity)
    {
        Speed = speed;
    }

    // Констор по умолчанию.
    public Flash()
    {
        Speed = 0.0;
    }

    // Скорость USB.
    [DataMember] public double Speed { get; set; }

    // Метод вывода в консоль информации о носителе.
    public override void ReportOutput(ILog log)
    {
        base.ReportOutput(log);
        log.ReportOutput("Speed: " + Speed);
    }
}

[Serializable]
[DataContract(Name = "DVD")]
public class DVD : Storage
{
    // Конструктор.
    public DVD(string manufacturer, string model, double capacity, int quantity, double writeSpeed)
        : base(manufacturer, model, capacity, quantity)
    {
        WriteSpeed = writeSpeed;
    }

    // Констор по умолчанию.
    public DVD()
    {
        WriteSpeed = 0.0;
    }

    // Скорость записи.
    [DataMember] public double WriteSpeed { get; set; }

    // Метод вывода в консоль информации о носителе.
    public override void ReportOutput(ILog log)
    {
        base.ReportOutput(log);
        log.ReportOutput("WriteSpeed: " + WriteSpeed);
    }
}