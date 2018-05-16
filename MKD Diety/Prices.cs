/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 11.10.2017
 * Time: 8:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace MKD_Diety
{
	/// <summary>
	/// Description of Prices.
	/// </summary>
	public class Prices
	{
		public List<Price> PriceList;
		
		public Prices()
		{
			PriceList = new List<Price>();
			PriceList.Add(new Price("BEL", "EUR", 11.25, 22.5, 45));
			PriceList.Add(new Price("FRA", "EUR", 11.25, 22.5, 45));
			PriceList.Add(new Price("ESP", "EUR", 10.75, 21.5, 43));
			PriceList.Add(new Price("PT", "EUR", 10.75, 21.5, 43));
			PriceList.Add(new Price("NLD", "EUR", 11.25, 22.5, 45));
			PriceList.Add(new Price("LUX", "EUR", 12.5, 25, 50));
			PriceList.Add(new Price("ITA", "EUR", 11.25, 22.5, 45));
			PriceList.Add(new Price("CHE", "CHF", 20, 40, 80));
			PriceList.Add(new Price("DEU", "EUR", 11.25, 22.5, 45));
			PriceList.Add(new Price("AUT", "EUR", 11.25, 22.5, 45));
			PriceList.Add(new Price("CZE", "CZK", 150, 300, 600));
			PriceList.Add(new Price("HUN", "EUR", 9.75, 19.5, 39));
			PriceList.Add(new Price("PL", "EUR", 9.25, 18.5, 37));
			PriceList.Add(new Price("SI", "EUR", 9.5, 19, 38));
			PriceList.Add(new Price("SVK", "EUR", 4.5, 6.7, 10.3));
		}
		
		public double GetPrice(string country, double hours)
		{
			if(country.Equals("SVK"))
			{
				if(hours>=5 && hours<=12)
				{
					return PriceList.First(p => p.Country == "SVK").Small;
				}
				if(hours>12 && hours<=18)
				{
					return PriceList.First(p => p.Country == "SVK").Medium;
				}
				if(hours>18)
				{
					return PriceList.First(p => p.Country == "SVK").Medium;
				}
			}
			if(hours<=6)
			{
				return PriceList.First(p => p.Country == country).Small;
			}
			if(hours>6 && hours<=12)
			{
				return PriceList.First(p => p.Country == country).Medium;
			}
			if(hours>12)
			{
				return PriceList.First(p => p.Country == country).Big;
			}
			else
			{
				return 0;
			}
		}
		
		public string GetCurrency(string country)
		{
			return PriceList.First(p => p.Country == country).Currency;
		}
	}
}
