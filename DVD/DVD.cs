using ILogNameSpace;
using StorageNameSpace;

namespace DVDNameSpace
{
    public class DVD : Storage
    {
        // Скорость записи.
        public double WriteSpeed { get; set; }

        // Метод вывода в консоль информации о носителе.
        public override void PrintReport(ILog log)
        {
            base.PrintReport(log);
            log.PrintReport("WriteSpeed: " + WriteSpeed);
        }

        // Конструктор.
        public DVD(string manufacturer, string model, double capacity, int quantity, double writeSpeed)
            : base(manufacturer, model, capacity, quantity)
        {
            WriteSpeed = writeSpeed;
        }
    }
}