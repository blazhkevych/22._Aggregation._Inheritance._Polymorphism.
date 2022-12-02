using ILogNameSpace;
using StorageNameSpace;
using System.Runtime.Serialization;

namespace FlashNameSpace
{
    [Serializable]
    [DataContract(Name = "Flash")]
    public class Flash : Storage
    {
        // Скорость USB.
        [DataMember]
        public double Speed { get; set; }

        // Метод вывода в консоль информации о носителе.
        public override void ReportOutput(ILog log)
        {
            base.ReportOutput(log);
            log.ReportOutput("Speed: " + Speed);
        }

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
    }
}