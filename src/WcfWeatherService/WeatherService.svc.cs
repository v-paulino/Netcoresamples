using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{ 
    public class WeatherService : IWeatherService
    {
        public string GetWheather(string localtioncode)
        {
            return "Its Rainning";
        }

        public WeatherDetailsResponse GetWheatherDetails(WeatherDetailsRequest composite)
        {
            return new WeatherDetailsResponse()
            {
                DetailDescription = "Today is gonna rain the entire day",
                IsRainning = true,
                Temperature = "14C"
            };
        }
    }
}
