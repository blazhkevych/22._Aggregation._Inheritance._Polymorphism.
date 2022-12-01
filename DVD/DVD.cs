using ILogNameSpace;
using StorageNameSpace;

namespace DVDNameSpace
{
    [Serializable]
    public class DVD : Storage
    {
        // Скорость записи.
        public double WriteSpeed { get; set; }

        // Метод вывода в консоль информации о носителе.
        public override void ReportOutput(ILog log)
        {
            base.ReportOutput(log);
            log.ReportOutput("WriteSpeed: " + WriteSpeed);
        }

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
    }
}