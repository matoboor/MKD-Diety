/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 09.10.2017
 * Time: 9:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MKD_Diety
{
	/// <summary>
	/// Description of Stop.
	/// </summary>
	public class Stop
	{
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public TimeSpan FromTime { get; set; }
		public TimeSpan ToTime { get; set; }
		public String Place { get; set; }
		public String Country { get; set; }
		public Double Duration 
		{
			get
			{
				return (ToTime-FromTime).TotalHours;
			}
			set
			{
				
			}
		}
		public Double? Price { get; set; }
		public String Currency { get; set; }
		
		public Stop(DateTime FromDate,DateTime ToDate, TimeSpan FromTime, TimeSpan ToTime, String Place)
		{
			this.FromDate = FromDate;
			this.ToDate = ToDate;
			this.FromTime = FromTime;
			this.ToTime = ToTime;
			this.Place = Place;
			this.Country = Place.Substring(0, 3);
			this.Duration = (ToTime-FromTime).TotalHours;
			this.Price = null;
			this.Currency = String.Empty;
		}
	}
}
