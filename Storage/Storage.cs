using ILogNameSpace;

namespace StorageNameSpace
{
    public abstract class Storage
    {
        // Имя производителя.
        public string Manufacturer { get; set; }

        // Модель.
        public string Model { get; set; }

        // Ёмкость носителя.
        public double Capacity { get; set; }

        // Количество.
        public int Quantity { get; set; }

        // Метод вывода в консоль информации о носителе.
        public virtual void PrintReport(ILog log)
        {
            log.PrintReport("Manufacturer: " + Manufacturer);
            log.PrintReport("Model: " + Model);
            log.PrintReport("Capacity: " + Capacity);
            log.PrintReport("Quantity: " + Quantity);
        }

        // Конструктор.
        public Storage(string manufacturer, string model, double capacity, int quantity)
        {
            Manufacturer = manufacturer;
            Model = model;
            Capacity = capacity;
            Quantity = quantity;
        }
    }
}