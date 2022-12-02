﻿using ILogNameSpace;
using Microsoft.VisualBasic;
using StorageNameSpace;
using System.Runtime.Serialization;

namespace DVDNameSpace
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(Storage))]
    public class DVD : Storage
    {
        // Скорость записи.
        [DataMember]
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