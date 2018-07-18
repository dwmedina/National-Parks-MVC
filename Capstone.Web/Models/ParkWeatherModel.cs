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


    }
}
