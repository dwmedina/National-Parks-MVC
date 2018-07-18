using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
    public class WeatherSqlDAL : IWeatherSqlDAL
    {
		private readonly string connectionString;

		public WeatherSqlDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public IList<Weather> GetAllWeather(string parkCode)
		{
			IList<Weather> weather = new List<Weather>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = $"SELECT * FROM weather WHERE parkCode = '{parkCode}';";

					SqlCommand cmd = new SqlCommand(sql, conn);
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						weather.Add(MapToWeather(reader));
					}
				}
			}
			catch (SqlException ex)
			{
				throw;
			}

			return weather;
		}

		private Weather MapToWeather(SqlDataReader reader)
		{
			Weather newWeather = new Weather();

			return new Weather()
			{
				ParkCode = Convert.ToString(reader["parkCode"]),
				FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
				Low = Convert.ToInt32(reader["low"]),
				High = Convert.ToInt32(reader["high"]),
				Forecast = Convert.ToString(reader["forecast"])
			};
		}
	}
}
