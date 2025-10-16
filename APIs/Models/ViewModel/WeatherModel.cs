using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIs.Models.ViewModel
{
    public class WeatherModel
    {
        public string Name { get; set; }
        public MainInfo Main { get; set; }
        public List<WeatherInfo> Weather { get; set; }

        public class MainInfo
        {
            public double Temp { get; set; }
            public double Humidity { get; set; }
        }

        public class WeatherInfo
        {
            public string Main {  get; set; }
            public string Description { get; set; }

            public string Icon { get; set; }
        }


    }
}