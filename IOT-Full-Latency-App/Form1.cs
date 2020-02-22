using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using IOT_Full_Latency_App.Communication;


namespace IOT_Full_Latency_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var StartDatetimes = new List<DateTime>();
            var serialSignalGenerator = new SerialSignalGenerator();
            serialSignalGenerator.dateTimes = StartDatetimes;
            serialSignalGenerator.RunningMinutes = 30;
            var thread1 = new Thread(serialSignalGenerator.Start);
            thread1.Start();
            Thread.Sleep(5000);

            Console.WriteLine(serialSignalGenerator.dateTimes);
            
        }
    }
}