using ILogNameSpace;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StorageNameSpace
{
    [Serializable]
    [DataContract(Name = "Storage")]
    [KnownType(typeof(Storage))]

    public abstract class Storage
    {
        // Имя производителя.
        [DataMember]
        public string Manufacturer { get; set; }

        // Модель.
        [DataMember]
        public string Model { get; set; }

        // Ёмкость носителя.
        [DataMember]
        public double Capacity { get; set; }

        // Количество.
        [DataMember]
        public int Quantity { get; set; }

        // Метод вывода в консоль информации о носителе.
        public virtual void ReportOutput(ILog log)
        {
            log.ReportOutput("Manufacturer: " + Manufacturer);
            log.ReportOutput("Model: " + Model);
            log.ReportOutput("Capacity: " + Capacity);
            log.ReportOutput("Quantity: " + Quantity);
        }

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
    }
}