using System;

namespace BloodSugarTracker.Core.Components
{
	public class Reading
	{
		public double ReadingVal { get; set; }
		public string ReadingString { get; set; }
		public string Timestamp { get; set; }
		//constructors
		public Reading()
		{
			ReadingVal = 0.0;
			Timestamp = DateTime.Now.ToString();
			ReadingString = ReadingVal.ToString();
		}
		public Reading(double val)
		{
			ReadingVal = val;
			Timestamp = DateTime.Now.ToString();
			ReadingString = val.ToString();
		}
		public Reading(double val, string time)
		{
			ReadingVal = val;
			Timestamp = time;
			ReadingString = val.ToString();
		}
	}
}
