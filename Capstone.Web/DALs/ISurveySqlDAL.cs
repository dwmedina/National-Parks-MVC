using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
    public interface ISurveySqlDAL
    {
		Dictionary<string, int> GetFavoriteParkBySurveys();

		void SaveNewSurvey(Survey survey);
    }
}
