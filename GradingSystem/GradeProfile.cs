using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

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

        public static void calcIndividualAvg(Dictionary<int, Student> students, string searchTerm)
        {

            DataTable ig = new DataTable();
            ig.Columns.Add("Module", typeof(string));
            ig.Columns.Add("Overall Grade", typeof(int));

            if (students.ContainsKey(Convert.ToInt32(searchTerm)))
            {
                foreach (KeyValuePair<int, Student> s in students)
                {
                    List<Grade> sortedGrades = s.Value.Grading.Grades.OrderBy(o => o.Module).ToList();
                    var individualTotal = sortedGrades.GroupBy(g => g.Module).Select(m => new { Key = m.Key, Value = (int)m.Sum(s => s.Mark * s.Weight)});
                    foreach (var group in individualTotal)
                    {
                        ig.Rows.Add(group.Key, group.Value);
                    }
                }
            }

            foreach (DataColumn col in ig.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow r in ig.Rows)
            {
                foreach (DataColumn col in ig.Columns)
                {
                    Console.Write("{0,-14}", r[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

    }
}
