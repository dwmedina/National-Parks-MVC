using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DALs;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
		private IParkSqlDAL dal;
		private IWeatherSqlDAL weatherDal;

		public HomeController(IParkSqlDAL dal, IWeatherSqlDAL weatherDal)
		{
			this.dal = dal;
			this.weatherDal = weatherDal;
		}

        public IActionResult Index()
        {
			var parks = dal.GetAllParks();

            return View(parks);
        }

		public IActionResult Detail(string parkCode)
		{
			var park = dal.GetPark(parkCode);
			var weather = weatherDal.GetAllWeather(parkCode);

			return View();
		}

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
