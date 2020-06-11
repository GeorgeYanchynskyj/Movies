using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Listener
{
    public partial class Listener : ServiceBase
    {
        public Listener()
        {
            InitializeComponent();
            Log("---- NEW START----");
        }

        protected override void OnStart(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 6000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            try
            {
                //Publish();
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace);
            }

        }

        private void Log(string mess)
        {
            using (StreamWriter outputFile = File.AppendText($@"C:\Users\yurij\Desktop\ListenerLog.txt")) outputFile.WriteLine(mess);
        }

        protected override void OnStop()
        {
        }
    }
}
