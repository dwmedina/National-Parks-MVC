using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
		public string ParkCode { get; set; }
		public string ParkName { get; set; }
		public string State { get; set; }
		public int Acreage { get; set; }
		public int ElevationInFt { get; set; }
		public double MilesOfTrail { get; set; }
		public int NumberOfCampsites { get; set; }
		public string Climate { get; set; }
		public int YearFounded { get; set; }
		public int AnnualVisitors { get; set; }
		public string InspirationalQuote { get; set; }
		public string QuoteSource { get; set; }
		public string Description { get; set; }
		public decimal EntryFee { get; set; }
		public int NumberOfSpecies { get; set; }

    }
}
