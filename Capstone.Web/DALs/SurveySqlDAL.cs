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
			Dictionary<string, int> output = new Dictionary<string, int>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "SELECT COUNT(*) AS votes, parkCode FROM survey_result GROUP BY parkCode ORDER BY votes DESC, parkCode;";
					SqlCommand cmd = new SqlCommand(sql, conn);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						string parkCode = Convert.ToString(reader["parkCode"]);
						int votes = Convert.ToInt32(reader["votes"]);

						output.Add(parkCode, votes);
					}
				}
			}
			catch (SqlException ex)
			{
				throw;
			}

			return output;

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
