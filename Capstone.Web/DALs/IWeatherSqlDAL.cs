using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
    public interface IWeatherSqlDAL
    {
		IList<Weather> GetAllWeather(string parkCode);
    }
}
