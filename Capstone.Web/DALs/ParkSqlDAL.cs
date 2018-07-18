using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
	public class ParkSqlDAL : IParkSqlDAL
	{
		private readonly string connectionString;

		public ParkSqlDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}
		public IList<Park> GetAllParks()
		{
			IList<Park> parks = new List<Park>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "SELECT * FROM park;";

					SqlCommand cmd = new SqlCommand(sql, conn);
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						parks.Add(MapToPark(reader));
					}
				}
			}
			catch (SqlException ex)
			{
				throw;
			}

			return parks;
		}

		public Park GetPark(string parkCode)
		{
			throw new NotImplementedException();
		}

		public Park MapToPark(SqlDataReader reader)
		{
			Park park = new Park();

			return new Park()
			{
				ParkCode = Convert.ToString(reader["parkCode"]),
				ParkName = Convert.ToString(reader["parkName"]),
				State = Convert.ToString(reader["state"]),
				Acreage = Convert.ToInt32(reader["acreage"]),
				ElevationInFt = Convert.ToInt32(reader["elevationInFeet"]),
				MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
				NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
				Climate = Convert.ToString(reader["climate"]),
				YearFounded = Convert.ToInt32(reader["yearFounded"]),
				AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]),
				InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
				QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
				Description = Convert.ToString(reader["parkDescription"]),
				EntryFee = Convert.ToDecimal(reader["entryFee"]),
				NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
			};
		}
	}
}
