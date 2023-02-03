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
        
        List<Participant> participants = new List<Participant>();
        List<Participant> maleParticipants = new List<Participant>();
        List<Participant> femaleParticipants = new List<Participant>();

        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(_filePath))
            {
                MessageBox.Show("The file specified in _filePath could not be found.");
                return;
            }
            LoadData();
            
            //DrawChart_Age_Average();
        }

        private void LoadData()
        {
            
            using (var reader = new StreamReader(_filePath))
            {
                var headerLine = reader.ReadLine();
                var headers = headerLine.Split(',');

                int genderIndex = Array.IndexOf(headers, "gender");
                int raceIndex = Array.IndexOf(headers, "race");
                int goalIndex = Array.IndexOf(headers, "goal");
                int dateIndex = Array.IndexOf(headers, "date");
                int goOutIndex = Array.IndexOf(headers, "go_out");
                int sportsIndex = Array.IndexOf(headers, "sports");
                int exerciseIndex = Array.IndexOf(headers, "exercise");
                int diningIndex = Array.IndexOf(headers, "dining");
                int museumsIndex = Array.IndexOf(headers, "museums");
                int artIndex = Array.IndexOf(headers, "art");
                int hikingIndex = Array.IndexOf(headers, "hiking");
                int gamingIndex = Array.IndexOf(headers, "gaming");
                int clubbingIndex = Array.IndexOf(headers, "clubbing");
                int readingIndex = Array.IndexOf(headers, "reading");
                int tvIndex = Array.IndexOf(headers, "tv");
                int theaterIndex = Array.IndexOf(headers, "theater");
                int moviesIndex = Array.IndexOf(headers, "movies");
                int concertsIndex = Array.IndexOf(headers, "concerts");
                int musicIndex = Array.IndexOf(headers, "music");
                int shoppingIndex = Array.IndexOf(headers, "shopping");
                int yogaIndex = Array.IndexOf(headers, "yoga");

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var gender = values[genderIndex] == "0" ? "Female" : "Male";
                    var race = int.TryParse(values[raceIndex], out int raceValue) ? raceValue : -1;
                    var goal = int.TryParse(values[goalIndex], out int goalValue) ? goalValue : -1;
                    var date = int.TryParse(values[dateIndex], out int dateValue) ? dateValue : -1;
                    var goOut = int.TryParse(values[goOutIndex], out int goOutValue) ? goOutValue : -1;
                    var sports = int.TryParse(values[sportsIndex], out int sportsValue) ? sportsValue : -1;
                    var exercise = int.TryParse(values[exerciseIndex], out int exerciseValue) ? exerciseValue : -1;
                    var dining = int.TryParse(values[diningIndex], out int diningValue) ? diningValue : -1;
                    var museums = int.TryParse(values[museumsIndex], out int museumsValue) ? museumsValue : -1;
                    var art = int.TryParse(values[artIndex], out int artValue) ? artValue : -1;
                    var hiking = int.TryParse(values[hikingIndex], out int hikingValue) ? hikingValue : -1;
                    var gaming = int.TryParse(values[gamingIndex], out int gamingValue) ? gamingValue : -1;
                    var clubbing = int.TryParse(values[clubbingIndex], out int clubbingValue) ? clubbingValue : -1;
                    var reading = int.TryParse(values[readingIndex], out int readingValue) ? readingValue : -1;
                    var tv = int.TryParse(values[tvIndex], out int tvValue) ? tvValue : -1;
                    var theater = int.TryParse(values[theaterIndex], out int theaterValue) ? theaterValue : -1;
                    var movies = int.TryParse(values[moviesIndex], out int moviesValue) ? moviesValue : -1;
                    var concerts = int.TryParse(values[concertsIndex], out int concertsValue) ? concertsValue : -1;
                    var music = int.TryParse(values[musicIndex], out int musicValue) ? musicValue : -1;
                    var shopping = int.TryParse(values[shoppingIndex], out int shoppingValue) ? shoppingValue : -1;
                    var yoga = int.TryParse(values[yogaIndex], out int yogaValue) ? yogaValue : -1;



                    participants.Add(new Participant
                    {
                        Gender = gender,
                        Race = race,
                        Goal = goal,
                        Date = date,
                        GoOut = goOut,
                        Sports = sports,
                        Exercise = exercise,
                        Dining = dining,
                        Museums = museums,
                        Art = art,
                        Hiking = hiking,
                        Gaming = gaming,
                        Clubbing = clubbing,
                        Reading = reading,
                        TV = tv,
                        Theater = theater,
                        Movies = movies,
                        Concerts = concerts,
                        Music = music,
                        Shopping = shopping,
                        Yoga = yoga
                    });
                }
            }

            maleParticipants = participants.Where(p => p.Gender == "Male").ToList();
            femaleParticipants = participants.Where(p => p.Gender == "Female").ToList();


        }

        // Question 1 
        private void DisplayGenderRaceChart()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            foreach (var pair in MyDictionary.Race)
            {
                string[] x = { "male", "female" };
                int[] y = { maleParticipants.Where(s => s.Race == pair.Key).Count(), femaleParticipants.Where(s => s.Race == pair.Key).Count() };
                Console.WriteLine(pair.Value);
                Console.WriteLine(y[1]);
                Series series = new Series(pair.Value);
                series.ChartType = SeriesChartType.StackedBar;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x, y);
                chart1.Series.Add(series);

                Series series2 = new Series(pair.Value);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);
            }

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Race of participants according to their gender");
            chart1.DataBind();
        }
    

        //Question 2
        private void DisplayGoalGenderChart()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            foreach (var pair in MyDictionary.Goal)
            {
                string[] x = { "male", "female" };
                int[] y = { maleParticipants.Where(s => s.Goal == pair.Key).Count(), femaleParticipants.Where(s => s.Goal == pair.Key).Count() };
                Console.WriteLine(pair.Value);
                Console.WriteLine(y[1]);
                Series series1 = new Series(pair.Value);
                
                series1.ChartType = SeriesChartType.StackedBar;
                series1.IsValueShownAsLabel = true;
                series1.Points.DataBindXY(x, y);
                chart1.Series.Add(series1);

                Series series2 = new Series(pair.Value);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);

            }

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Goal of participants according to their gender");
            chart1.DataBind();

            // Add title to the chart
            chart2.Titles.Clear();
            chart2.Titles.Add("Goal of participants according to their gender");
            chart2.DataBind();
        }


        //Question 3
        private void DisplayDateGenderChart()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();


            foreach (var pair in MyDictionary.Date)
            {
                string[] x = { "male", "female" };
                int[] y = { maleParticipants.Where(s => s.Date == pair.Key).Count(), femaleParticipants.Where(s => s.Date == pair.Key).Count() };
                Console.WriteLine(pair.Value);
                Console.WriteLine(y[1]);
                Series series = new Series(pair.Value);
                series.ChartType = SeriesChartType.StackedBar;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x, y);
                chart1.Series.Add(series);

                Series series2 = new Series(pair.Value);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);
            }

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Date of participants according to their gender");
            chart1.DataBind();

            // Add title to the chart
            chart2.Titles.Clear();
            chart2.Titles.Add("Date of participants according to their gender");
            chart2.DataBind();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DisplayGenderRaceChart();
        }

        
        private void button2_Click_1(object sender, EventArgs e)
        {
            DisplayGoalGenderChart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayDateGenderChart();
        }


        private void DisplayHobbiesGenderChart()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            // Define the hobbies as an array
            string[] hobbies = { "GoOut", "Sports", "Exercise", "Dining", "Museums", "Art", "Hiking", "Gaming", "Clubbing", "Reading", "TV", "Theater", "Movies", "Concerts", "Music", "Shopping", "Yoga" };
            int[] yMale = new int[hobbies.Length];
            int[] yFemale = new int[hobbies.Length];

            // Count the number of male and female participants for each hobby
            for (int i = 0; i < hobbies.Length; i++)
            {
                yMale[i] = maleParticipants.Where(p => p.GetType().GetProperty(hobbies[i]).GetValue(p, null).ToString() == "1").Count();
                yFemale[i] = femaleParticipants.Where(p => p.GetType().GetProperty(hobbies[i]).GetValue(p, null).ToString() == "1").Count();
            }

            // Create a series for each hobby
            for (int i = 0; i < hobbies.Length; i++)
            {
                string[] x = { "male", "female" };
                int[] y = { yMale[i], yFemale[i] };

                Series series = new Series(hobbies[i]);
                series.ChartType = SeriesChartType.StackedBar;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x, y);
                chart1.Series.Add(series);

                Series series2 = new Series(hobbies[i]);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);
            }

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Favourite activities of participants according to their gender");
            chart1.DataBind();

            // Add title to the chart
            chart2.Titles.Clear();
            chart2.Titles.Add("Favourite activities of participants according to their gender");
            chart2.DataBind();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            DisplayHobbiesGenderChart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /*
        private void DrawChart_Age_Average()
        {
            var groupedData = _speedDatingData
                .GroupBy(data => data.Gender)
                .Select(group => new
                {
                    Gender = group.Key,
                    AverageAge = group.Average(data => data.Age)
                });
            
            
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
            
        }*/
        /*
        private void DrawChart_genderCount()
        {
            var groupedData = _speedDatingData
                .GroupBy(data => data.Gender)
                .Select(group => new
                {
                    Gender = group.Key,
                });
            
            
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
            
        }*/


    }

    
}