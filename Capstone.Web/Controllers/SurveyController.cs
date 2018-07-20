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
            // get our parks
            IList<Park> parks = parkDal.GetAllParks();

            // create a new survey
            Survey model = new Survey()
            {
                AllParks = ListIntoSelectList(parks)
            };

            // pass in our model
			return View(model);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult NewSurvey(Survey survey)
		{
            // validate and redirect the user
			dal.SaveNewSurvey(survey);

			return RedirectToAction("results", "survey");
		}

		public IActionResult Results()
		{
			Dictionary<string, int> surveyResults = dal.GetFavoriteParkBySurveys();

			SurveyResultViewModel results = new SurveyResultViewModel()
			{
				Results = surveyResults,
				Parks = parkDal.GetAllParks()
			};
			

			return View(results);
		}

        public List<SelectListItem> ListIntoSelectList(IList<Park> parks)
        {
            List<SelectListItem> parkList = new List<SelectListItem>();

            foreach (var park in parks)
            {
                // for each park that we have
                SelectListItem temp = new SelectListItem()
                {
                    // take its name and its code and add it as a possible selection
                    Text = park.ParkName, Value = park.ParkCode
                };

                parkList.Add(temp);
            }

            return parkList;
        }

    }
}