using System;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.IO;
using RabbitMQ.Client;
using System.Collections.Generic;
using TMDBMobile.Core.Model;
using TMDBMobile.Core.Services;
using Newtonsoft.Json;

//using RestSharp;

namespace Sourcer
{
    public partial class Sourcer : ServiceBase
    {
        public Sourcer()
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
                Publish();
            }
            catch(Exception ex)
            {
                Log(ex.Message + ex.StackTrace);
            }

        }

        public void Publish()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var list = Discover0();

                foreach (Movie m in list)
                {
                    string message = JsonConvert.SerializeObject(m);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);
                }
            }
        }

        public List<Movie> Discover0()
        {

            TMDBService serv = new TMDBService(new DebugConfigurationService());

            var res = serv.Discover().GetAwaiter().GetResult();

            Log("Got data from source");

            return res.Data.Results;
        }

        private void Log(string mess)
        {
            using (StreamWriter outputFile = File.AppendText($@"C:\Users\yurij\Desktop\Log.txt")) outputFile.WriteLine(mess);
        }
        protected override void OnStop()
        {

        }
    }
}
