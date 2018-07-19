using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
		public string ParkCode { get; set; }
		public int FiveDayForecastValue { get; set; }
		public int Low { get; set; }
		public int High { get; set; }
		public string Forecast { get; set; }

		public int HighC
		{
			get
			{
				return (int)(Math.Round((this.High - 32) / 1.8));
			}
		}

		public int LowC
		{
			get
			{
				return (int)(Math.Round((this.Low - 32) / 1.8));
			}
		}
	}
}
