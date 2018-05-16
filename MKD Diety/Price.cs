/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 11.10.2017
 * Time: 8:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MKD_Diety
{
	/// <summary>
	/// Description of Price.
	/// </summary>
	public class Price
	{
		public string Country { get; set; }
		public string Currency { get; set; }
		public double Small { get; set; }
		public double Medium { get; set; }
		public double Big { get; set; }
		
		public Price(string country, string currency, double small, double medium, double big)
		{
			this.Country = country;
			this.Currency = currency;
			this.Small = small;
			this.Medium = medium;
			this.Big = big;
		}
	}
}
