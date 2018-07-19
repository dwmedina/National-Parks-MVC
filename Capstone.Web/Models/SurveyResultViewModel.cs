using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class SurveyResultViewModel
	{
		public Dictionary<string, int> Results { get; set; }
		public IList<Park> Parks { get; set; }
    }
}
