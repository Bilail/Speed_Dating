using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Speed_Dating
{
    public partial class Form1 : Form
   {
        private readonly string _filePath = "../../Speed_Dating_Data.csv";
        private List<SpeedDatingData> _speedDatingData;

        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(_filePath))
            {
                MessageBox.Show("The file specified in _filePath could not be found.");
                return;
            }
            LoadData();
            DrawChart_Age_Average();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            DrawChart_genderCount();
        }

        private void LoadData()
        {
            _speedDatingData = File.ReadAllLines(_filePath)
                .Skip(1)
                .Select(line => line.Split(','))
                .Select(columns => new SpeedDatingData
                {
                    Gender = columns[2] == "0" ? "Female" : "Male",
                    Age = int.TryParse(columns[15], out int age) ? age : default(int),
                    AgeDifference = int.TryParse(columns[16], out int ageDifference) ? ageDifference : default(int),
                    Attractive = int.TryParse(columns[18], out int attractive) ? attractive : default(int),
                    Sincere = int.TryParse(columns[20], out int sincere) ? sincere : default(int),
                    Intelligent = int.TryParse(columns[21], out int intelligent) ? intelligent : default(int),
                    Fun = int.TryParse(columns[22], out int fun) ? fun : default(int),
                    Ambitious = int.TryParse(columns[24], out int ambitious) ? ambitious : default(int),
                    SharedInterests = int.TryParse(columns[25], out int sharedInterests) ? sharedInterests : default(int)
                })
                .ToList();
            
            foreach (var data in _speedDatingData)
            {
                
                Console.WriteLine("Age :" + data.Age);
            }
            
        }

        private void DrawChart_Age_Average()
        {
            var groupedData = _speedDatingData
                .GroupBy(data => data.Gender)
                .Select(group => new
                {
                    Gender = group.Key,
                    AverageAge = group.Average(data => data.Age)
                });
            
            Chart chart1 = new Chart();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();

            ChartArea chartArea1 = new ChartArea();
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);

            Series series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.Bar;
            series.XValueType = ChartValueType.String;
            series.YValueType = ChartValueType.Int32;
            
            chart1.Series.Add(series);
            chart1.Titles.Add("Speed Dating Results");
            chart1.Parent = this;
            
            foreach (var data in groupedData)
            {
                series.Points.AddXY(data.Gender, data.AverageAge);
            }
            panel1.Controls.Add(chart1);
            chart1.Dock = DockStyle.Fill;
        }
        
        private void DrawChart_genderCount()
        {
            var groupedData = _speedDatingData
                .GroupBy(data => data.Gender)
                .Select(group => new
                {
                    Gender = group.Key,
                });
            
            Chart chart1 = new Chart();
            
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();

            ChartArea Gender_Count = new ChartArea();
            Gender_Count.Name = "Gender Count";
            chart1.ChartAreas.Add(Gender_Count);

            Series series = new Series();
            series.Name = "Gender Count";
            series.ChartType = SeriesChartType.Bar;
            series.XValueType = ChartValueType.String;
            series.YValueType = ChartValueType.Int32;
            
            chart1.Series.Add(series);
            chart1.Titles.Add("Speed Dating Results");
            chart1.Parent = this;
            
            foreach (var data in groupedData)
            {
                series.Points.AddXY(data.Gender, groupedData.Count());
            }
            panel1.Controls.Add(chart1);
            chart1.Dock = DockStyle.Fill;
        }
    }

    public class SpeedDatingData
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public int AgeDifference { get; set; }
        public int Attractive { get; set; }
        public int Sincere { get; set; }
        public int Intelligent { get; set; }
        public int Fun { get; set; }
        public int Ambitious { get; set; }
        public int SharedInterests { get; set; }
    }
}