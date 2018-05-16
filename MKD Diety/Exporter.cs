/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 11.10.2017
 * Time: 12:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace MKD_Diety
{
	/// <summary>
	/// Description of Exporter.
	/// </summary>
	public class Exporter
	{
		static Workbook MyBook = null; 
		static Application MyApp = null;
		static Worksheet MySheet = null;
		static Worksheet OriginalSheet = null;
		
		public int lastRow;
		public int sheetsNum = 1;
		
		static string templatePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\diet_template.xls"));
		static string tempFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp\\diety.xls"));
		
		
		public Exporter()
		{
			File.Copy(templatePath, tempFilePath, true);
			MyApp = new Application();
			MyApp.Visible = false;
			MyBook = MyApp.Workbooks.Open(tempFilePath); //TODO> release object somewhere
			OriginalSheet = MyBook.Sheets[1] as Worksheet;
//			lastRow = MySheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
		}
		
		public void Close()
		{
			MyApp.Workbooks.Close();
		}
		
		public void AddSheet()
		{
			sheetsNum++;
			MyBook.Sheets.Add(After: MyBook.Sheets[MyBook.Sheets.Count]);
			MySheet = MyBook.Sheets[sheetsNum] as Worksheet;
		}
		
		
		//should make number of copies of original as is needed for count of stops
		public void CopyDietSheet(int numberOfEntries)
		{
			Range source2 = OriginalSheet.Range["A1:K64"] as Range;
			Range dest2 = MySheet.Range["A1"] as Range;
			source2.Copy(dest2);
			
			int num = (numberOfEntries / 26)+1;
			int akt = 1;
			bool first = true;
			
			Console.WriteLine("copy " + num);
			if (num > 1) {
				for (int i = 1; i < num; i++) {
					if (first) {
						Range source = OriginalSheet.Range["A1:K64"] as Range;
						Range dest = MySheet.Range["A" + (65 * akt)] as Range;
						source.Copy(dest);
						akt++;
						first = false;
						continue;
					} else {
						Range source1 = OriginalSheet.Range["A1:K64"] as Range;
						Range dest1 = MySheet.Range["A" + ((64 * akt) + 1)] as Range;
						source1.Copy(dest1);
						akt++;
					}
				}
			}
		}
		
		public void WriteDietSheet(List<Day> days, string name, string Spz)
		{
			MyApp.Visible = true;
			
			int stops = 0;
			
			foreach(Day d in days)
			{
				stops = stops + d.Stops.Count;
			}
			
			int startRow = 7;
			int akt = 0;
			
			Console.WriteLine(stops);
			CopyDietSheet(stops);
			
			MySheet.Name = Spz;
			
			
			foreach(Day d in days)
			{
				MySheet.Cells[1, 10] = Spz;
				MySheet.Cells[2, 7] = name;
				bool w = false;
				foreach(Stop s in d.Stops)
				{
					
					MySheet.Cells[startRow, 1] = s.FromDate;
					MySheet.Cells[startRow, 2] = s.Place;
					MySheet.Cells[startRow, 3] = s.FromTime.ToString();
					MySheet.Cells[(startRow + 1), 3] = s.ToTime.ToString();
					MySheet.Cells[startRow, 4] = s.Duration;
					if(s.Country==d.DietCountry && !w)
					{
						if (d.DietCurrency == "EUR") {
							MySheet.Cells[startRow, 5] = d.DietPrice.ToString();
						}
						if (d.DietCurrency == "CZK") {
							MySheet.Cells[startRow, 6] = d.DietPrice.ToString();
						}
						if (d.DietCurrency == "CHF") {
							MySheet.Cells[startRow, 7] = d.DietPrice.ToString();
						}
						w = true;
					}
					akt++;
					if(akt==26)
					{
						startRow = startRow + 12;
					}
					startRow = startRow + 2;
					
				}
			}
			
		}
	}
}
