/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 05.10.2017
 * Time: 15:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Excel;
using System.IO;

namespace MKD_Diety
{
	class Program
	{
		public static List<Stop> stops = new List<Stop>();
		public static List<Day> Days = new List<Day>();
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new Form1());
		}
	}
}