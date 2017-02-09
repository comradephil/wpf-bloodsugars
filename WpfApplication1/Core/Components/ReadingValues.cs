using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BloodSugarTracker.Core.Components;

namespace BloodSugarTracker
{
	public class ReadingValues
	{
		public List<Reading> Readings { get; set; } = new List<Reading>();

		public bool ProcessExistingData()
		{
			SqlConnection con = new SqlConnection();

			con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pb\\Documents\\Visual Studio 2015\\Projects\\WpfApplication1\\WpfApplication1\\bloodsugar.mdf\";Integrated Security=True;Connect Timeout=30";
			//attach everything to the ReadingValues list

			string sqlquery = "SELECT * FROM readings;";
			SqlCommand command = new SqlCommand(sqlquery, con);

			using (con)
			{
				con.Open();
				
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						AddToList(new Reading(Convert.ToDouble(reader["reading"]), Convert.ToString(reader["timestamp"])));
					}
				}
				con.Close();
			}
			return true;
		}
				

		public bool AddToDatabase(Reading reading)
		{
			AddToList(reading);
			SqlConnection con = new SqlConnection();

			con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pb\\Documents\\Visual Studio 2015\\Projects\\WpfApplication1\\WpfApplication1\\bloodsugar.mdf\";Integrated Security=True;Connect Timeout=30";
			string sqlquery = "INSERT INTO readings (reading) VALUES ('"+ reading.ReadingString + "')";
			SqlCommand command = new SqlCommand(sqlquery, con);
			con.Open();
			SqlDataReader reader = command.ExecuteReader();
			con.Close();
			return true;
		}

		public bool AddToList(Reading reading)
		{
			Readings.Add(reading);
			return true;
		}

	}
}
