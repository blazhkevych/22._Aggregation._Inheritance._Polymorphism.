﻿using ILogNameSpace;
using StorageNameSpace;

namespace HDDNameSpace
{
    public class HDD : Storage
    {
        // Скорость вращения шпинделя.
        public double SpindleSpeed { get; set; }

        // Метод вывода в консоль информации о носителе.
        public override void PrintReport(ILog log)
        {
            base.PrintReport(log);
            log.PrintReport("SpindleSpeed: " + SpindleSpeed);
        }

        // Конструктор.
        public HDD(string manufacturer, string model, double capacity, int quantity, double spindleSpeed)
            : base(manufacturer, model, capacity, quantity)
        {
            SpindleSpeed = spindleSpeed;
        }
    }
}