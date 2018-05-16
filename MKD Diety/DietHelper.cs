/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 11.10.2017
 * Time: 8:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MKD_Diety
{
	/// <summary>
	/// Description of DietHelper.
	/// </summary>
	public class DietHelper
	{
		public string Country { get; set; }
		public double Hours { get; set; }
		
		public DietHelper(string country, double hours)
		{
			this.Country = country;
			this.Hours = hours;
		}
	}
}
