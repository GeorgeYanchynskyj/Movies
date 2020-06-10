using System;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.IO;
using RabbitMQ.Client;

namespace Sourcer
{
    public partial class Sourcer : ServiceBase
    {
        public Sourcer()
        {
            InitializeComponent();
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

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = $"It's {DateTime.Now} already !";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
            }

            //using (StreamWriter outputFile = File.AppendText($@"C:\Users\yurij\Desktop\T.txt"))  outputFile.WriteLine("test");

        }
        protected override void OnStop()
        {

        }
    }
}
