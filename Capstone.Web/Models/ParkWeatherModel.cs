using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkWeatherModel
    {
		public Park park { get; set; }

		public IList<Weather> weather { get; set; }

        public string TempPref { get; set; }

		public ParkWeatherModel(Park park, IList<Weather> weather)
		{
			this.park = park;
			this.weather = weather;
		}

        public string ProvideRecommendation(Weather weather)
        {
            return String.Concat(recommendation[weather.Forecast] + " " + TempRecommend(weather.High, weather.Low));
        }

        private Dictionary<string, string> recommendation = new Dictionary<string, string>()
        {
            { "snow", "Pack some snowshoes. " },
            { "rain", "Bring your rain gear and waterproof shoes! " },
            { "thunderstorms", "Seek shelter and avoid hiking on exposed ridges. " },
            { "sunny", "Pack some sunblock. " },
            { "cloudy", "Better pack a flashlight and umbrella. " },
            { "partlyCloudy", "Wear your favorite hat. " }
        };

        public string TempRecommend(int high, int low)
        {
            if (high >= 75)
            {
                return "Bring an extra gallon of water. ";
            }
            else if (high - low >= 20)
            {
                return "Wear breathable layers of clothing. ";
            }
            else if (low <= 20)
            {
                return "Exposure to frigid temperatures is dangerous.  Please be careful. ";
            }
            else
            {
                return "";
            }
        }

        public int DisplayCelsius(int temp)
        {
            int CelsiusTemp = Convert.ToInt32((temp - 32) / 1.8);
            return CelsiusTemp;
        }
    }
}
