using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LiveCharts;
using LiveCharts.Wpf;
using System.Timers;
using System.Text;
using System.Threading;
using System.Windows;
using LiveCharts.Defaults;

namespace WeatherApp
{
    class Program
    {
        Dictionary<string, string> x = new Dictionary<string, string> { };
        const string AAPID = "";
        string cityName = "Athens";
        private static System.Timers.Timer aTimer;
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            string nap = getWeather().ToString();
            Console.WriteLine("The Wather Now Is :  " + nap);
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(5000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        public static string getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q=London&appid=6d6fbd77236e01c78fd6f3eb9837373c&units=metric&cnt=6");
                var json = web.DownloadString(url);
                if (WeatherChanged())
                {

                }
                // WeatherInfo.main nn = /*JsonConvert.DeserializeObject<WeatherInfo.main>(json);*/
                //WeatherInfo.main outPut = result;
                WeatherInfo.code scd = JsonConvert.DeserializeObject<WeatherInfo.code>(json);
                
                //double nap = nn.temp;
                double currTemp = scd.main.temp;

                return currTemp.ToString();
            }
        }

        private static bool WeatherChanged(string json, out bool BubbleEvent)
        {
            BubbleEvent = true;
            return BubbleEvent;
        }

        static void Main(string[] args)
        {
            //string nap = getWeather();
           
            

                SetTimer();
            while (aTimer.Enabled)
            {
                string nap = getWeather().ToString();

                Console.WriteLine("\nPress the Enter key to exit the application...\n");
                Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
                Console.ReadLine();
                aTimer.Stop();
                aTimer.Dispose();
            }
            Console.WriteLine("Terminating the application...");


            var doubleValues = new ChartValues<double> { 1, 2, 3 };
            var intValues = new ChartValues<int> { 1, 2, 3 };

            //the observable value class is really helpful, it notifies the chart to update
            //every time the ObservableValue.Value property changes
            var observableValues = new ChartValues<LiveCharts.Defaults.ObservableValue>
            {
                 new LiveCharts.Defaults.ObservableValue(1), //initializes Value property as 1
                 new LiveCharts.Defaults.ObservableValue(2),
                new LiveCharts.Defaults.ObservableValue(3)
            };

            //interval.Stop();
        }
        }
    }


