using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
using Newtonsoft.Json;
using DAL.Models;
using DAL.Tablers;

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
                Listen();
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace);
            }

        }

        public void Listen()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                Log(" Reading...");

                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Process(message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                while (true) { }
                
            }
        }

        private void Process(string mess)
        {
            var movie = JsonConvert.DeserializeObject<Movie>(mess);

            var tabler = new MovieTabler();

            var res1 = tabler.UpsertMovie(movie);

            Log(movie.Title + " inserted " + res1);
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
