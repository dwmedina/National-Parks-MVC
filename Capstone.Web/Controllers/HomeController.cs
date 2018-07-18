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

		public HomeController(IParkSqlDAL dal)
		{
			this.dal = dal;
		}

        public IActionResult Index()
        {
			var parks = dal.GetAllParks();

            return View(parks);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
