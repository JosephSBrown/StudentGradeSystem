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

            foreach (KeyValuePair<int, Student> s in students)
            {
                if (students.ContainsKey(Convert.ToInt32(searchTerm)))
                {
                    List < Grade > sortedGrades = s.Value.Grading.Grades.OrderBy(o => o.Module).ToList();
                    float total = sortedGrades.Sum(sg => (sg.Mark * sg.Weight) / sortedGrades.Count());
                    Console.WriteLine($"Total Mark Average: {total}");
                }
            }

        }
    }
}
