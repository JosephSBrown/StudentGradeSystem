using System;
using System.Collections.Generic;
using System.Linq;

namespace GradingSystem
{
    class GradeProfile
    { 
        public List<Grade> Grades = new List<Grade>();

        public static void calcAvg(Dictionary<int, Student> students, string searchTerm)
        {

            if (students.ContainsKey(Convert.ToInt32(searchTerm)))
            {
                foreach (KeyValuePair<int, Student> s in students)
                {
                    List < Grade > sortedGrades = s.Value.Grading.Grades.OrderBy(o => o.Module).ToList();
                    float marktotal = sortedGrades.Sum(sg => sg.Mark);
                    float weighttotal = sortedGrades.Sum(sg => sg.Weight);
                    float total = (marktotal * weighttotal) / sortedGrades.Count();
                    Console.WriteLine(@$"Total Mark Average: {total}

");
                }
            }

        }
    }
}
