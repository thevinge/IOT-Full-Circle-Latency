using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            var startDtSignalGenerator = new List<DateTime>();
            var serialSignalGenerator = new SerialSignalGenerator("COM5");
            serialSignalGenerator.dateTimes = startDtSignalGenerator;
            serialSignalGenerator.RunningMinutes = 1;
            var threadGenerator = new Thread(serialSignalGenerator.Start);

            var endDtSignalReceiver = new List<DateTime>();
            var serialSignalReceiver = new SignalReceiver("COM6");
            serialSignalReceiver.dateTimes = endDtSignalReceiver;
          
            var threadReceiver = new Thread(serialSignalReceiver.Start);

            threadReceiver.Start();
            threadGenerator.Start();
            threadGenerator.Join();
            threadReceiver.Join();

            var result =serialSignalGenerator.dateTimes.Zip(serialSignalReceiver.dateTimes).Select(tuple =>
                {
                    return (tuple.Second.Ticks - tuple.First.Ticks) * 100;
                });

            var writer = new StreamWriter("result.txt");
            foreach (var line in result)
            {
                writer.WriteLine(line);
            }
            writer.Flush();
            writer.Close();
        }
    }
}