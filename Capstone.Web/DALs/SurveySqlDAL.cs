using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
	public class SurveySqlDAL : ISurveySqlDAL
	{
		private readonly string connectionString;

		public SurveySqlDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public Dictionary<string, int> GetFavoriteParkBySurveys()
		{
			throw new NotImplementedException();
		}

		public void SaveNewSurvey(Survey survey)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
					cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
					cmd.Parameters.AddWithValue("@state", survey.State);
					cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

					cmd.ExecuteNonQuery();
				}
			}
			catch (SqlException ex)
			{
				throw;
			}
		}
	}
}
