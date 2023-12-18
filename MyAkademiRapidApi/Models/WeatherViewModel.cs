using Microsoft.AspNetCore.Mvc;

namespace MyAkademiRapidApi.Models
{
    public class WeatherViewModel
    {
        //public string city { get; set; }

        //public string country { get; set; }

        //public string timezone_id { get; set; }

        //public decimal lat { get; set; }


        public Location[] locations { get; set; }

        public class Location
        {
            public string city { get; set; }
            public int woeid { get; set; }
            public string country { get; set; }
            public float lat { get; set; }
            public float _long { get; set; }
            public string timezone_id { get; set; }
        }

     


 

    }
}
