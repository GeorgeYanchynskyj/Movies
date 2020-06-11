using System;
using System.Collections.Generic;
using TMDBMobile.Core.Model;
using TMDBMobile.Core.Services;
using Sourcer;
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

            var list = Discover();//.GetAwaiter().GetResult();

            //var list = Sourcer.Sourcer.Discover0();

            foreach (Movie m in list)
            {
                Console.WriteLine(m.Title);
            }


            //foreach(var mov in res.)

            Console.WriteLine("I tried");
            Console.ReadLine();
        }

        static List<Movie> Discover()
        {

            TMDBService serv = new TMDBService(new DebugConfigurationService());

            var res = serv.Discover().GetAwaiter().GetResult();

            return res.Data.Results;
        }

    }
}
