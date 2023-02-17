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
        //private readonly string _filePath = "../../Speed_Dating_Data.csv";
        private readonly string _filePath = "../../Speed_Dating_clean.csv";

        List<Participant> participants = new List<Participant>();
        List<Participant> maleParticipants = new List<Participant>();
        List<Participant> femaleParticipants = new List<Participant>();

        List<Participant> maleParticipants_all = new List<Participant>();
        List<Participant> femaleParticipants_all = new List<Participant>();

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
                var headers = headerLine.Split(';');
                int iidIndex = Array.IndexOf(headers, "iid");
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
                int tvSportIndex = Array.IndexOf(headers, "tvsports");
                int theaterIndex = Array.IndexOf(headers, "theater");
                int moviesIndex = Array.IndexOf(headers, "movies");
                int concertsIndex = Array.IndexOf(headers, "concerts");
                int musicIndex = Array.IndexOf(headers, "music");
                int shoppingIndex = Array.IndexOf(headers, "shopping");
                int yogaIndex = Array.IndexOf(headers, "yoga");
               
                int attrIndex = Array.IndexOf(headers, "attr5_1");
                int sincIndex = Array.IndexOf(headers, "sinc5_1");
                int intelIndex = Array.IndexOf(headers, "intel5_1");
                int funIndex = Array.IndexOf(headers, "fun5_1");
                int ambIndex = Array.IndexOf(headers, "amb5_1");

                int attrLookingIndex = Array.IndexOf(headers, "attr4_1");
                int sincLookingIndex = Array.IndexOf(headers, "sinc4_1");
                int intelLookingIndex = Array.IndexOf(headers, "intel4_1");
                int funLookingIndex = Array.IndexOf(headers, "fun4_1");
                int ambLookingIndex = Array.IndexOf(headers, "amb4_1");

                int imprIndex = Array.IndexOf(headers, "imprace");
                int ageIndex = Array.IndexOf(headers, "age_o");

                while (!reader.EndOfStream)
                {
                    
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var iid = int.TryParse(values[iidIndex], out int iidValue) ? iidValue : -1;
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
                    var attractiveness = int.TryParse(values[attrIndex], out int attrValue) ? attrValue : -1;
                    var sincerity = int.TryParse(values[sincIndex], out int sincValue) ? sincValue : -1;
                    var intelligence = int.TryParse(values[intelIndex], out int intelValue) ? intelValue : -1;
                    var humour = int.TryParse(values[funIndex], out int funValue) ? funValue : -1;
                    var ambition = int.TryParse(values[ambIndex], out int ambValue) ? ambValue : -1;
                    var imprace = int.TryParse(values[ambIndex], out int impraceValue) ? impraceValue : -1;
                    var tvsport = int.TryParse(values[ambIndex], out int tvsports) ? impraceValue : -1;
                    var attractivenessLooking = int.TryParse(values[attrLookingIndex], out int attrLooValue) ? attrValue : -1;
                    var sincerityLooking = int.TryParse(values[sincLookingIndex], out int sincLooValue) ? sincValue : -1;
                    var intelligenceLooking = int.TryParse(values[intelLookingIndex], out int intelLooValue) ? intelValue : -1;
                    var humourLooking = int.TryParse(values[funLookingIndex], out int funLooValue) ? funValue : -1;
                    var ambitionLooking = int.TryParse(values[ambLookingIndex], out int ambLooValue) ? ambValue : -1;
                    var age = int.TryParse(values[ageIndex], out int agevalue) ? agevalue : -1;


                    Participant p = new Participant
                    {
                        Iid = iid,
                        Gender = gender,
                        Age = age,
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
                        Yoga = yoga,
                        Attractiveness = attractiveness,
                        Sincerity = sincerity,
                        Intelligence = intelligence,
                        Humour = humour,
                        Ambition = ambition,
                        Imprace = imprace,
                    };

                    p.SelfPerception = new List<int>() ;
                    p.SelfPerception.Add(attractiveness);
                    p.SelfPerception.Add(sincerity);
                    p.SelfPerception.Add( intelligence);
                    p.SelfPerception.Add( humour);
                    p.SelfPerception.Add( ambition);

                    p.CriteriaInterest = new List<int>();
                    p.CriteriaInterest.Add(attractivenessLooking);
                    p.CriteriaInterest.Add(sincerityLooking);
                    p.CriteriaInterest.Add(intelligenceLooking);
                    p.CriteriaInterest.Add(humourLooking);
                    p.CriteriaInterest.Add(ambitionLooking);

                    p.Hobbies = new List<int>();
                    p.Hobbies.Add(sports);
                    p.Hobbies.Add(tvsport);
                    p.Hobbies.Add(exercise);
                    p.Hobbies.Add(dining);
                    p.Hobbies.Add(museums);
                    p.Hobbies.Add(art);
                    p.Hobbies.Add(hiking);
                    p.Hobbies.Add(gaming);
                    p.Hobbies.Add(clubbing);
                    p.Hobbies.Add(reading);
                    p.Hobbies.Add(tv);
                    p.Hobbies.Add(theater);
                    p.Hobbies.Add(movies);
                    p.Hobbies.Add(concerts);
                    p.Hobbies.Add(music);
                    p.Hobbies.Add(shopping);
                    p.Hobbies.Add(yoga);
                    
                    participants.Add(p);
                }
            }

            maleParticipants = participants.Where(p => p.Gender == "Male")
                               .Distinct(new IIDComparer())
                               .ToList();

            femaleParticipants = participants.Where(p => p.Gender == "Female")
                              .Distinct(new IIDComparer())
                              .ToList();

            maleParticipants_all = participants.Where(p => p.Gender == "Male")
                               .ToList();

            femaleParticipants_all = participants.Where(p => p.Gender == "Female")
                              .ToList();

            Console.WriteLine("mal : " + maleParticipants.Count() + " femal : " + femaleParticipants.Count());

    }

    // Question 1 
    private void DisplayGenderRaceChart()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            double[] yMale = new double[MyDictionary.Race.Count()];
            double[] yFemale = new double[MyDictionary.Race.Count()];
            List<String> race = MyDictionary.Race.Values.ToList();
            int i = 0;

            foreach (var pair in MyDictionary.Race)
            {
                string[] x = { "male", "female" };

                int[] y = { maleParticipants.Where(s => s.Race == pair.Key).Count()
                        , femaleParticipants.Where(s => s.Race == pair.Key).Count()
                                                                                };
                yMale[i] = maleParticipants.Where(s => s.Race == pair.Key).Count();
                yFemale[i] = femaleParticipants.Where(s => s.Race == pair.Key).Count();
                i = i + 1;


                Series series = new Series(pair.Value);
                series.ChartType = SeriesChartType.StackedBar;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x, y);
                chart1.Series.Add(series);

                /*Series series2 = new Series(pair.Value);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);*/

            }

                Series series_male = new Series("male");
                series_male.ChartType = SeriesChartType.Column;
                series_male.IsValueShownAsLabel = true;
                series_male.Points.DataBindXY(race, yMale);
                chart2.Series.Add(series_male);

                Series series_female = new Series("female");
                series_female.ChartType = SeriesChartType.Column;
                series_female.IsValueShownAsLabel = true;
                series_female.Points.DataBindXY(race, yFemale);
                chart2.Series.Add(series_female);
            

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
            List<String> goal = MyDictionary.Goal.Values.ToList();
            double[] yMale = new double[MyDictionary.Goal.Count()];
            double[] yFemale = new double[MyDictionary.Goal.Count()];
            int i = 0; 

            foreach (var pair in MyDictionary.Goal)
            {
                string[] x = { "male", "female" };
                int[] y = { maleParticipants.Where(s => s.Goal == pair.Key).Count(), femaleParticipants.Where(s => s.Goal == pair.Key).Count() };
                yMale[i] = maleParticipants.Where(s => s.Goal == pair.Key).Count();
                yFemale[i] = femaleParticipants.Where(s => s.Goal == pair.Key).Count();
                i++;

                Series series1 = new Series(pair.Value);
                
                series1.ChartType = SeriesChartType.StackedBar;
                series1.IsValueShownAsLabel = true;
                series1.Points.DataBindXY(x, y);
                chart1.Series.Add(series1);

                /*Series series2 = new Series(pair.Value);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);*/

            }
            Series series_male = new Series("male");
            series_male.ChartType = SeriesChartType.Column;
            series_male.IsValueShownAsLabel = true;
            series_male.Points.DataBindXY(goal, yMale);
            chart2.Series.Add(series_male);

            Series series_female = new Series("female");
            series_female.ChartType = SeriesChartType.Column;
            series_female.IsValueShownAsLabel = true;
            series_female.Points.DataBindXY(goal, yFemale);
            chart2.Series.Add(series_female);


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

            List<String> datetype = MyDictionary.Date.Values.ToList();
            double[] yMale = new double[MyDictionary.Date.Count()];
            double[] yFemale = new double[MyDictionary.Date.Count()];
            int i = 0;


            foreach (var pair in MyDictionary.Date)
            {
                string[] x = { "male", "female" };

                int[] y = { maleParticipants.Where(s => s.Date == pair.Key).Count(), femaleParticipants.Where(s => s.Date == pair.Key).Count() };

                yMale[i] = maleParticipants.Where(s => s.Date == pair.Key).Count();
                yFemale[i] = femaleParticipants.Where(s => s.Date == pair.Key).Count();
                i++;

                Series series = new Series(pair.Value);
                series.ChartType = SeriesChartType.StackedBar;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x, y);
                chart1.Series.Add(series);

                /*Series series2 = new Series(pair.Value);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);*/
            }

            Series series_male = new Series("male");
            series_male.ChartType = SeriesChartType.Column;
            series_male.IsValueShownAsLabel = true;
            series_male.Points.DataBindXY(datetype, yMale);
            chart2.Series.Add(series_male);

            Series series_female = new Series("female");
            series_female.ChartType = SeriesChartType.Column;
            series_female.IsValueShownAsLabel = true;
            series_female.Points.DataBindXY(datetype, yFemale);
            chart2.Series.Add(series_female);

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
            List<String> hobbies = MyDictionary.Hobbies.Values.ToList();
            double[] ymale = new double[hobbies.Count];
            double[] yfemale = new double[hobbies.Count];

            string[] xmale = MyDictionary.Hobbies.Values.ToArray();
            string[] xfemale = MyDictionary.Hobbies.Values.ToArray();

            // Count the number of male and female participants for each hobby
            foreach (var pair in MyDictionary.Hobbies)
            {
                //yMale[i] = maleParticipants.Where(p => p.GetType().GetProperty(hobbies[i]).GetValue(p, null).ToString() == "1").Count();
                ymale[pair.Key] = Math.Round(maleParticipants.Where(s => s.Hobbies[pair.Key] != -1).Average(s => s.Hobbies[pair.Key]), 1);
                yfemale[pair.Key] = Math.Round(femaleParticipants.Where(s => s.Hobbies[pair.Key] != -1).Average(s => s.Hobbies[pair.Key]), 1);
                

            }

            Array.Sort(ymale, xmale);
            Array.Sort(yfemale);
            xmale = xmale.Skip(12).ToArray();
            ymale = ymale.Skip(12).ToArray();
            

            // Create a list to store the sum of male and female participants for each hobby
            /*List<Tuple<string, int, int>> hobbyTotals = new List<Tuple<string, int, int>>();
        for (int i = 0; i < hobbies.Length; i++)
        {
            hobbyTotals.Add(new Tuple<string, double, double>(hobbies[i], yMale[i], yFemale[i]));
        }

        // Sort the list in descending order based on the sum of male and female participants
        hobbyTotals.Sort((x2, y) => (x2.Item2 + x2.Item3).CompareTo(y.Item2 + y.Item3));
        hobbyTotals.Reverse();

        // Take only the top 5 hobbies
        hobbyTotals = hobbyTotals.Take(5).ToList();

            
            foreach (var hobby in hobbyTotals)
            {
                string[] x1 = { "male", "female" };
                int[] y = { hobby.Item2, hobby.Item3 };

                Series series = new Series(hobby.Item1);
                series.ChartType = SeriesChartType.StackedBar;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x1, y);
                chart1.Series.Add(series);
            }*/

            //string[] x_male = hobbyTotals.Select(h => h.Item1).ToArray();
            

            Series seriesH = new Series("male");
            seriesH.ChartType = SeriesChartType.Column;
            seriesH.IsValueShownAsLabel = true;
            seriesH.Points.DataBindXY(xmale, ymale);
            chart1.Series.Add(seriesH);

            Array.Sort(yfemale, xfemale);
            Array.Sort(yfemale);
            xfemale = xfemale.Skip(12).ToArray();
            yfemale = yfemale.Skip(12).ToArray();

            Series seriesF = new Series("female");
            seriesF.ChartType = SeriesChartType.Column;
            seriesF.IsValueShownAsLabel = true;
            seriesF.Points.DataBindXY(xfemale, yfemale);
            chart2.Series.Add(seriesF);

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Favourite activities of participants Male");
            chart1.DataBind();

            // Add title to the chart
            chart2.Titles.Clear();
            chart2.Titles.Add("Favourite activities of participants Female");
            chart2.DataBind();
        }


        //Question 5 
        private void button4_Click(object sender, EventArgs e)
        {
            DisplayHobbiesGenderChart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void DisplaySelfPerceptionChart()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            // Define the criteria as an array
            string[] criteria = { "Attractiveness", "Sincerity", "Intelligence", "Humour", "Ambition" };
            double[] yMale = new double[criteria.Length];
            double[] yFemale = new double[criteria.Length];

            // Count the average self-perception of male and female participants for each criteria
            for (int i = 0; i < criteria.Length; i++)
            {
                yMale[i] = Math.Round(maleParticipants.Where(p => p.SelfPerception[i] != -1).Average(p => p.SelfPerception[i]),1);
                yFemale[i] = Math.Round(femaleParticipants.Where(p => p.SelfPerception[i] != -1).Average(p => p.SelfPerception[i]),1);
            }

            // Create a series for each criteria
            for (int i = 0; i < criteria.Length; i++)
            {
                string[] x = { "male", "female" };
                double[] y = { yMale[i], yFemale[i] };

                Series series = new Series(criteria[i]);
                series.ChartType = SeriesChartType.StackedBar;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x, y);
                chart1.Series.Add(series);

                Series series2 = new Series(criteria[i]);
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(x, y);
                chart2.Series.Add(series2);
            }

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Self-perception of participants according to their gender");
            chart1.DataBind();

            // Add title to the chart
            chart2.Titles.Clear();
            chart2.Titles.Add("Self-perception of participants according to their gender");
            chart2.DataBind();
        }


        private void DisplaySelfPerceptionChart2()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            // Define the criteria as an array
            string[] criteria = { "Attractiveness", "Sincerity", "Intelligence", "Humour", "Ambition" };
            double[] yMale = new double[criteria.Length];
            double[] yFemale = new double[criteria.Length];

            // Count the average self-perception of male and female participants for each criteria
            for (int i = 0; i < criteria.Length; i++)
            {
                yMale[i] = Math.Round(maleParticipants.Where(p => p.SelfPerception[i] != -1).Average(p => p.SelfPerception[i]), 1);
                yFemale[i] = Math.Round(femaleParticipants.Where(p => p.SelfPerception[i] != -1).Average(p => p.SelfPerception[i]), 1);
            }

                string[] x = criteria;
            Series series_male = new Series("male");
            series_male.ChartType = SeriesChartType.Column;
            series_male.IsValueShownAsLabel = true;
            series_male.Points.DataBindXY(x, yMale);
            chart1.Series.Add(series_male);

            Series series_female = new Series("female");
            series_female.ChartType = SeriesChartType.Column;
            series_female.IsValueShownAsLabel = true;
            series_female.Points.DataBindXY(x, yFemale);
            chart1.Series.Add(series_female);

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Self-perception of participants according to their gender");
            chart1.DataBind();
            /*chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.ChartAreas[0].AxisY.Minimum = chart1.ChartAreas[0].AxisY.Minimum;
            chart1.ChartAreas[0].AxisY.Maximum = 10;*/

            // Add title to the chart
            chart2.Titles.Clear();
            chart2.Titles.Add("Self-perception of participants according to their gender");
            chart2.DataBind();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            DisplaySelfPerceptionChart2();
        }

        //Question 6
        private void DisplayImportanceOfRaceChart()
        {
            
            chart1.Series.Clear();
            chart2.Series.Clear();

            double[] yMale = new double[MyDictionary.Race.Count()];
            double[] yFemale = new double[MyDictionary.Race.Count()];
            List<string> v = MyDictionary.Race.Values.ToList();

            foreach (var pair in MyDictionary.Race)
            {

                string[] x = { "male", "female" };
                
                var male_filtre = maleParticipants.Where(p => p.Race == pair.Key && p.Imprace != -1);
                var female_filtre = femaleParticipants.Where(p => p.Race == pair.Key && p.Imprace != -1);

                if (male_filtre.Any()) { yMale[pair.Key-1] = Math.Round(male_filtre.Average(p => p.Imprace), 1); }
                if (female_filtre.Any()) { yFemale[pair.Key-1] = Math.Round(female_filtre.Average(p => p.Imprace), 1); }

                double[] y = { yMale[pair.Key-1], yFemale[pair.Key-1] };

                Series series = new Series(pair.Value);
                series.ChartType = SeriesChartType.StackedColumn;
                series.IsValueShownAsLabel = true;
                series.Points.DataBindXY(x, y);
                chart1.Series.Add(series);

            }

            Series seriesH = new Series("male");
            seriesH.ChartType = SeriesChartType.Column;
            seriesH.IsValueShownAsLabel = true;
            seriesH.Points.DataBindXY(v, yMale);
            chart2.Series.Add(seriesH);

            Series series2 = new Series("female");
                series2.ChartType = SeriesChartType.Column;
                series2.IsValueShownAsLabel = true;
                series2.Points.DataBindXY(v, yFemale);
                chart2.Series.Add(series2);
            

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Importance of having the same racial/ethnic background according to gender");
            chart1.DataBind();
            

            chart2.Titles.Clear();
            chart2.Titles.Add("Importance of having the same racial/ethnic background according to gender");
            chart2.DataBind();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisplayImportanceOfRaceChart();
        }

        private void CriteriaInterest()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            // Define the criteria as an array
            string[] criteria = MyDictionary.criteria.Values.ToArray();
            double[] yMale = new double[criteria.Length];
            double[] yFemale = new double[criteria.Length];

            // Count the average self-perception of male and female participants for each criteria
            /*for (int i = 0; i < criteria.Length; i++)
            {
                yMale[i] = Math.Round(maleParticipants.Where(p => p.CriteriaInterest[i] != -1).Average(p => p.CriteriaInterest[i]), 1);
                yFemale[i] = Math.Round(femaleParticipants.Where(p => p.CriteriaInterest[i] != -1).Average(p => p.CriteriaInterest[i]), 1);
     
            }*/

            foreach (var pair in MyDictionary.criteria)
            {
                var filtered_male = maleParticipants.Where(s => s.CriteriaInterest[pair.Key] != -1);
                var filtered_female = femaleParticipants.Where(s => s.CriteriaInterest[pair.Key] != -1);
                if (filtered_male.Any())
                    yMale[pair.Key] = Math.Round(filtered_male.Average(s => s.CriteriaInterest[pair.Key]), 1);
                if (filtered_female.Any())
                    yFemale[pair.Key] = Math.Round(filtered_female.Average(s => s.CriteriaInterest[pair.Key]), 1);
            }

            string[] x = criteria;
            Series series_male = new Series("male");
            series_male.ChartType = SeriesChartType.Column;
            series_male.IsValueShownAsLabel = true;
            series_male.Points.DataBindXY(x, yMale);
            chart1.Series.Add(series_male);

            Series series_female = new Series("female");
            series_female.ChartType = SeriesChartType.Column;
            series_female.IsValueShownAsLabel = true;
            series_female.Points.DataBindXY(x, yFemale);
            chart1.Series.Add(series_female);

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Criteria Interest according to their gender");
            chart1.DataBind();
            /*chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.ChartAreas[0].AxisY.Minimum = chart1.ChartAreas[0].AxisY.Minimum;
            chart1.ChartAreas[0].AxisY.Maximum = 10;*/

            // Add title to the chart
            chart2.Titles.Clear();
            chart2.Titles.Add("Criteria Interest according to their gender");
            chart2.DataBind();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            CriteriaInterest();
        }

        private void BonusAge()
        {
            chart1.Series.Clear();

            int[] x = new int[10];

            //On créer un tableau de 18 à 18+15 ans
            for (int i = 0; i < x.Length; i++)
                x[i] = 19 + i;

            double[] y_male = new double[x.Length];
            double[] y_female = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                y_male[i] = maleParticipants.Where(s => s.Age == 19 + i).Count();
                y_female[i] = femaleParticipants.Where(s => s.Age == 19 + i).Count();
            }

            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            Series male_series = new Series("male");
            male_series.ChartType = SeriesChartType.Column;
            male_series.IsValueShownAsLabel = true;
            male_series.Points.DataBindXY(x, y_male);
            chart1.Series.Add(male_series);

            Series female_series = new Series("female");
            female_series.ChartType = SeriesChartType.Column;
            female_series.IsValueShownAsLabel = true;
            female_series.Points.DataBindXY(x, y_female);
            chart1.Series.Add(female_series);

            // Add title to the chart
            chart1.Titles.Clear();
            chart1.Titles.Add("Age and Gender by Participant");
            chart1.DataBind();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BonusAge();
        }
    }


    public class IIDComparer : IEqualityComparer<Participant>
    {
        public bool Equals(Participant x, Participant y)
        {
            return x.Iid == y.Iid;
        }

        public int GetHashCode(Participant obj)
        {
            return obj.Iid.GetHashCode();
        }
    }

}
