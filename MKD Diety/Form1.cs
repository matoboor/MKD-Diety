/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 13.10.2017
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using Excel;
using System.IO;

namespace MKD_Diety
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		public static List<Stop> stops = new List<Stop>();
		public static List<Day> Days = new List<Day>();
		string sourceFilePath = @"C:\MKD\maly.xlsx";
		public string name = "";
		public string SPZ = "";
		Exporter ex;
		
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			nameLabel.Text = "Meno";
			spzLabel.Text = "ŠPZ";
			dietButton.Enabled = false;

			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
				sourceFilePath = openFileDialog1.FileName;
            }
			Logic();
			dietButton.Enabled = true;
		}
		
		
		public void Logic()
		{
			stops = new List<Stop>();
			Days = new List<Day>();
			DataSet result = new DataSet();
			DataTable table = new DataTable();
			FileStream fs = File.Open(sourceFilePath, FileMode.Open, FileAccess.Read);
			IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
			result = reader.AsDataSet();
			table = result.Tables[0];		
			
			name = "";
			SPZ = "";
			
			bool firstLine = true; //hlavička
			
			foreach (DataRow dr in table.Rows) {
				if (firstLine)
				{
					firstLine=false;
					continue;
				}
								
				DateTime startDate = DateTime.Parse(dr[6].ToString());
				DateTime endDate = DateTime.Parse(dr[5].ToString()); 
				
				TimeSpan startTime =DateTime.Parse(dr[4].ToString()).TimeOfDay; 
				TimeSpan endTime = DateTime.Parse(dr[3].ToString()).TimeOfDay; 
				
				String place = dr[17].ToString();
				
				name = dr[26].ToString();
				SPZ = dr[21].ToString();
				
				if(endDate.Date==startDate.Date)
				{
					Stop s = new Stop(startDate, endDate, startTime, endTime, place);
					stops.Add(s);
				}
				else
				{
					Stop s = new Stop(startDate, endDate, startTime, endTime, place);
					AddStops(s);
				}
			}
			
			fs.Close();
			
			Days = GroupToDays(stops);
			
			foreach(Day d in Days)
			{
				d.Calculate();
			}
			
			BindingSource src = new BindingSource();
			foreach(Day d in Days)
			{
				foreach(Stop s in d.Stops)
				{
					src.Add(s);
				}
				
			}
			dataGridView1.DataSource = src;
			nameLabel.Text = name;
			spzLabel.Text = SPZ;
			
			
			
			//Exporter ex = new Exporter();
			//ex.WriteDietSheet(Days,name,SPZ);
			//Application.Exit();
		}
		
		public static List<Day> GroupToDays(List<Stop> stops)
		{
			DateTime currentDate = new DateTime();
			Day currentDay = null;
			List<Day> result = new List<Day>();
			
			foreach(Stop s in stops)
			{
				if(s.FromDate != currentDate)
				{
					if(currentDay!=null)
					{
						result.Add(currentDay);
					}
					currentDate = s.FromDate;
					currentDay = new Day();
					currentDay.Date = currentDate;
					currentDay.Stops.Add(s);
				}
				else
				{
					currentDay.Stops.Add(s);
				}
			}
				result.Add(currentDay);
			return result;
		}
		
		public static void AddStops(Stop stop)
		{
			int n = (stop.ToDate - stop.FromDate).Days;
			DateTime t = stop.FromDate;
			
			for (int i = 0; i <= n; i++) {
				if(i==0)
				{
					Stop s = new Stop(stop.FromDate, t, stop.FromTime, new TimeSpan(24, 00, 00), stop.Place);
					stops.Add(s);
					t=t.AddDays(1);
					continue;
				}
				if(i==n)
				{
					Stop s = new Stop(t, stop.ToDate, new TimeSpan(0, 0, 0), stop.ToTime, stop.Place);
					stops.Add(s);
				}
				else
				{
					Stop s = new Stop(t, t, new TimeSpan(0, 0, 0), new TimeSpan(24, 00, 00), stop.Place);
					stops.Add(s);
					t=t.AddDays(1);
				}
			}
		}
		void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = dataGridView1.FirstDisplayedCell.RowIndex;
			stops = new List<Stop>();
			foreach(DataGridViewRow row in dataGridView1.Rows)
			{
				Stop s = row.DataBoundItem as Stop;
				stops.Add(s);
			}
			Days = GroupToDays(stops);
			foreach(Day d in Days)
			{
				d.Calculate();
			}
			BindingSource src = new BindingSource();
			foreach(Day d in Days)
			{
				foreach(Stop s in d.Stops)
				{
					src.Add(s);
				}
				
			}
			dataGridView1.DataSource = src;
			dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
		}
		void DietButtonClick(object sender, EventArgs e)
		{
			if(ex==null)
			{
				ex = new Exporter();
			}
			ex.AddSheet();
			ex.WriteDietSheet(Days,name,SPZ);
			dietButton.Enabled = false;
			//Application.Exit();
		}
		void Form1FormClosing(object sender, FormClosingEventArgs e)
		{
			if (ex != null) {
				ex.Close();
			}
		}
		
	}
}
