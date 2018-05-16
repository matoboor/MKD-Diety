/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 09.10.2017
 * Time: 9:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace MKD_Diety
{
	/// <summary>
	/// Description of Day.
	/// </summary>
	public class Day
	{
		
		public DateTime Date { get; set; }
		public IList<Stop> Stops { get; set; }
		
		public double DietTime { get; set; }
		public string DietCountry { get; set; }
		public double DietPrice { get; set; }
		public string DietCurrency { get; set; }
		
		public Prices calculator { get; set; }
		
		public Day()
		{
			Stops = new List<Stop>();
			calculator = new Prices();
		}
		
		public void Calculate()
		{
			List<DietHelper> c = new List<DietHelper>();
			
			foreach(Stop s in Stops)
			{
				if(c.Find(a => a.Country==s.Country)!=null)
				{
					var h = c.Find(a => a.Country == s.Country);
					h.Hours += s.Duration;
				}
				else
				{
					c.Add(new DietHelper(s.Country,s.Duration));
				}
			}
			Double max = c.Max(a => a.Hours);
			var res = c.First(a => a.Hours == max);
			this.DietCountry = res.Country;
			this.DietTime = res.Hours;
			this.DietPrice = calculator.GetPrice(this.DietCountry, this.DietTime);
			this.DietCurrency = calculator.GetCurrency(this.DietCountry);
			
			foreach(Stop s in Stops)
			{
				if(s.Country == this.DietCountry)
				   {
					s.Price = this.DietPrice;
					s.Currency = this.DietCurrency;
					break;
				   }
			}
			
		}
	}
}
