using ILogNameSpace;
using StorageNameSpace;
using System.Runtime.Serialization;

namespace HDDNameSpace
{
    [Serializable]
    [DataContract(Name = "HDD", Namespace = "HDDNameSpace")]
    [KnownType(typeof(Storage))]
    public class HDD : Storage
    {
        // Скорость вращения шпинделя.
        [DataMember]
        public double SpindleSpeed { get; set; }

        // Метод вывода в консоль информации о носителе.
        public override void ReportOutput(ILog log)
        {
            base.ReportOutput(log);
            log.ReportOutput("SpindleSpeed: " + SpindleSpeed);
        }

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
    }
}