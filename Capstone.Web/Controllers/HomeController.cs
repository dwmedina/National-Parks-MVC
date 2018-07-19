using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DALs;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        // pull our data from the db
		private IParkSqlDAL dal;
		private IWeatherSqlDAL weatherDal;

        
		public HomeController(IParkSqlDAL dal, IWeatherSqlDAL weatherDal)
		{
			this.dal = dal;
			this.weatherDal = weatherDal;
		}

        [HttpGet]
        public IActionResult Index()
        {
			var parks = dal.GetAllParks();

            return View(parks);
        }

        [HttpGet]
		public IActionResult Detail(string parkCode)
		{
            // get the park by its unique code
            // within the park, get all of its weather
            // find out what the user preferences are
			var park = dal.GetPark(parkCode);
			var weather = weatherDal.GetAllWeather(parkCode);
			string pref = HttpContext.Session.GetString("pref");

			if (pref == null)
			{
				pref = "F";
				HttpContext.Session.SetString("pref", pref);
			}
            // need to check if it's Fahrenheit so that we can toggle between types
            else if (pref == "fahrenheit")
            {
                pref = "F";
            }
			else
			{
				pref = "C";
			}

			var model = new ParkWeatherModel(park, weather);

			model.TempPref = pref;
            
            // pass our ViewModel back into our View
			return View(model);
		}
		
		public IActionResult ToggleTemp(string parkCode, string preference)
		{
			HttpContext.Session.SetString("pref", preference);

			return RedirectToAction("Detail", "Home", new { parkCode });
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
