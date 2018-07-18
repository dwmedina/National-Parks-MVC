using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
    public interface IParkSqlDAL
    {
		IList<Park> GetAllParks();

		Park GetPark(string parkCode);
    }
}
