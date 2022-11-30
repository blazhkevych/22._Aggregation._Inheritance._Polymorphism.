using ILogNameSpace;
using StorageNameSpace;

namespace FlashNameSpace
{
    public class Flash : Storage
    {
        // Скорость USB.
        public double Speed { get; set; }

        // Метод вывода в консоль информации о носителе.
        public override void PrintReport(ILog log)
        {
            base.PrintReport(log);
            log.PrintReport("Speed: " + Speed);
        }

        // Конструктор.
        public Flash(string manufacturer, string model, int capacity, int quantity, double speed)
            : base(manufacturer, model, capacity, quantity)
        {
            Speed = speed;
        }
    }
}