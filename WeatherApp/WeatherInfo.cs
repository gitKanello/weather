using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class WeatherInfo
    {
        public class coord {
            public double lon { get; set; } 
            public double lat { get; set; }

        }
        public class weather
        {
            public int id { get; set; }
            public string mian { get; set; }
            public string description { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }
        public class clouds
        {
            public int all { get; set; }
        }

        public class code
        {
            public string Base { get; set; }
            public double Visibility { get; set; }
            public int dt { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
            public coord coord { get; set; }
            public main main { get; set; }
            public clouds clouds { get; set; }

            //public bool Changed()
            //{
            //    if (this.main.temp != )
            //    {
            //        return true;
            //    }
            //    return false;
            //}
        }


    }
}
