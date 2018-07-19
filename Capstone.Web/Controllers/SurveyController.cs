using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DALs;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
		private ISurveySqlDAL dal;
		private IParkSqlDAL parkDal;
		public SurveyController(ISurveySqlDAL dal, IParkSqlDAL parkDal)
		{
			this.dal = dal;
			this.parkDal = parkDal;
		}
		
		[HttpGet]
        public IActionResult NewSurvey()
        {
			var parks = parkDal.GetAllParks();

			var parkOptions = parks.Select(p => new SelectListItem() { Text = p.ParkCode, Value = p.ParkCode });

			ViewBag.Options = parkOptions;

			return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult NewSurvey(Survey survey)
		{
			dal.SaveNewSurvey(survey);

			return RedirectToAction("results", "survey");
		}
    }
}