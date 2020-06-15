using System;
using System.Collections.Generic;
//using TMDBMobile.Core.Model;
//using TMDBMobile.Core.Services;
using Sourcer;
using DAL.Tablers;
using DAL.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;

//using RestSharp;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's try...");

            //TMDBService serv = new TMDBService(new DebugConfigurationService());

            //var res = serv.Discover().GetAwaiter().GetResult();

            //var list = Discover();//.GetAwaiter().GetResult();

            //var list = Sourcer.Sourcer.Discover0();

            //foreach (Movie m in list)
            //{
            //    Console.WriteLine(m.Title);
            //}

            //var tabler = new MovieTabler();

            //var res = tabler.GetMovies();

            //var tabler = new MovieTabler();

            //var res1 = tabler.UpsertMovie(new Movie(3, "test5", "ok", 100, 5, "eng", new DateTime(2020, 1, 1)));

            Listen();
            //foreach(var mov in res.)

            Console.WriteLine("I tried");
            Console.ReadLine();
        }

        public static void Listen()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                Console.WriteLine(" Reading...");

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
                    //Console.WriteLine(" [x] Received {0}", message);
                    Process(message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                while (true) { }
            }
        }

        private static void Process(string mess)
        {
            var movie = JsonConvert.DeserializeObject<Movie>(mess);

            var tabler = new MovieTabler();

            var res1 = tabler.UpsertMovie(movie);

            Console.WriteLine(movie.Title + " inserted " + res1);
        }

        //static List<Movie> Discover()
        //{

        //    TMDBService serv = new TMDBService(new DebugConfigurationService());

        //    var res = serv.Discover().GetAwaiter().GetResult();

        //    return res.Data.Results;
        //}

    }
}
