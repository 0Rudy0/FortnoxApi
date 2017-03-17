using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FortnoxAPI
{
	public static class DAL
	{
		public static string GetActiveToken(string userID)
		{
			try
			{
				string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
				string token = "";
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand("getActiveToken", conn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@userID", userID));
					using (SqlDataReader rdr = cmd.ExecuteReader())
					{
						rdr.Read();
						token = rdr["value"].ToString();
					}

					conn.Close();
				}
				return token.Trim();
			}
			catch
			{
				return "";
			}
		}

		public static bool InsertNewToken(string tokenValue, string userID)
		{
			try
			{
				string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand("InsertNewToken", conn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@tokenValue", tokenValue));
					cmd.Parameters.Add(new SqlParameter("@userID", userID));
					cmd.ExecuteNonQuery();

					conn.Close();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

	}
}