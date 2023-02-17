using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Speed_Dating
{
    class MyDictionary
    {
        public static Dictionary<int, string> Field = new Dictionary<int, string>
            {
                { 1, "Law" },
                { 2, "Math" },
                { 3, "Social Science, Psychologist" },
                { 4, "Medical Science, Pharmaceuticals, and Bio Tech" },
                { 5, "Engineering" },
                { 6, "English/Creative Writing/ Journalism" },
                { 7, "History/Religion/Philosophy" },
                { 8, "Business/Econ/Finance" },
                { 9, "Education, Academia" },
                { 10, "Biological Sciences/Chemistry/Physics" },
                { 11, "Social Work" },
                { 12, "Undergrad/undecided" },
                { 13, "Political Science/International Affairs" },
                { 14, "Film" },
                { 15, "Fine Arts/Arts Administration" },
                { 16, "Languages" },
                { 17, "Architecture" },
                { 18, "Other" }
            };

        public static Dictionary<int, string> Race = new Dictionary<int, string>
        {
            
            {1, "Black/African American"},
            {2, "European/Caucasian-American"},
            {3, "Latino/Hispanic American"},
            {4, "Asian/Pacific Islander/Asian-American"},
            {5, "Native American"},
            {6, "Other"}
        };

        public static Dictionary<int, string> Goal = new Dictionary<int, string>()
        {
            { 1, "Seemed like a fun night out" },
            { 2, "To meet new people" },
            { 3, "To get a date" },
            { 4, "Looking for a serious relationship" },
            { 5, "To say I did it" },
            { 6, "Other" }
        };

        public static Dictionary<int, string> Date = new Dictionary<int, string>()
        {
            {1, "Several times a week"},
            {2, "Twice a week"},
            {3, "Once a week"},
            {4, "Twice a month"},
            {5, "Once a month"},
            {6, "Several times a year"},
            {7, "Almost never"}
        };

        public static Dictionary<int, string> Hobbies = new Dictionary<int, string>
            {
                { 0, "sports" },
                { 1, "tvsports" },
                { 2, "excersice" },
                { 3, "dining" },
                { 4, "museums" },
                { 5, "art" },
                { 6, "hiking" },
                { 7, "gaming" },
                { 8, "clubbing" },
                { 9, "reading" },
                { 10, "tv" },
                { 11, "theater" },
                { 12, "movies" },
                { 13, "concerts" },
                { 14, "music" },
                { 15, "shopping" },
                { 16, "yoga" }
            };

        public static Dictionary<int, string> criteria = new Dictionary<int, string>
            {
                { 0, "attractiveness" },
                { 1, "sincerity" },
                { 2, "intelligence" },
                { 3, "humour" },
                { 4, "ambition" },
                //{ 5, "shared hobbies" }
            };

    }
}
