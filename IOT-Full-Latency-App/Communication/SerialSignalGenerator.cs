using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace IOT_Full_Latency_App.Communication
{
    public class SerialSignalGenerator
    {
        private SerialPort sp = new SerialPort("COM5");
        public List<DateTime> dateTimes { get; set; }

        public int RunningMinutes { get; set; }

        public void Start()
        {
            sp.BaudRate = 9600;
            sp.Open();

            var i = 1;
            var startDate = DateTime.Now;

            while (DateTime.Now - startDate < TimeSpan.FromMinutes(RunningMinutes))
            {
                var command = (i % 2) + 1;
                dateTimes.Add(DateTime.Now);
                sp.Write($"{command}");
                i++;
                Thread.Sleep(1000);
            }
        }
    }
}