using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpLoadTester
{
    public class Conf
    {
        public const string URI = "";
        public const int DurationInMinutes = 10;
        public const int Timeout = 10 * 1000;
        public const int ConcurrentDaemons = 100;
    }

    public static class Timer
    {
        public static readonly Stopwatch Stopwatch;

        public static void Start()
        {
            Stopwatch.Start();
        }

        static Timer()
        {
            Stopwatch = new Stopwatch();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Start the master time and run until the time is complete or the program is killed.
            Timer.Stopwatch.Start();

            // Spin up X number of workers on their own threads and have them hit the site.
            var daemons = new Daemon[Conf.ConcurrentDaemons];
            foreach (var d in daemons)
            {

            }
            
            while (Timer.Stopwatch.Elapsed.Minutes < Conf.DurationInMinutes)
            {
                // do nothing but run.
            }
        }
    }

    public class Daemon
    {
        public void DoWork()
        {
            while (Timer.Stopwatch.Elapsed.Minutes < Conf.DurationInMinutes)
            {
                var req = WebRequest.Create(Conf.URI);
                req.Timeout = Conf.Timeout;
                var res = req.GetResponse() as HttpWebResponse;

                if (res == null)
                {
                    Console.WriteLine("Response was null.");
                }
                else if (res.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("Error Response: Status={0}", res.StatusCode);
                }
            }
        }
    }
}
