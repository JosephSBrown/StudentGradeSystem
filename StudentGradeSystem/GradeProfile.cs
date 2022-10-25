using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace StudentGradeSystem
{
	class gradeProfile
	{
		public string moduleName;
		public int averageMark;
		public int overallMark;
		Grade grade = new Grade();

		public void calcAvg(Grade grade)
		{
            Console.Clear();
            List<string> breakdown = new List<string>();
            List<int> marks = new List<int>();
            foreach (KeyValuePair<int, Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>>> i in grade.grades)
            {
                foreach (KeyValuePair<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>> sid in i.Value)
                {                    
                    foreach (KeyValuePair<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>> yr in sid.Value)
                    {
                        foreach (KeyValuePair<string, Dictionary<int, Dictionary<string, int>>> mod in yr.Value)
                        {
                            if (!breakdown.Contains(mod.Key))
                            {
                                moduleName = mod.Key;
                                breakdown.Add(moduleName);
                                foreach (KeyValuePair<int, Dictionary<string, int>> element in mod.Value)
                                {
                                    foreach (KeyValuePair<string, int> type in element.Value)
                                    {
                                        var check = new Dictionary<string, int> { { type.Key, type.Value } };
                                        if (check.ContainsKey("Mark"))
                                        {
                                            marks.Add(check["Mark"]);
                                            Console.WriteLine(check["Mark"]);
                                        }
                                        else if (check.ContainsKey("Weight"))
                                        {
                                        }
                                        else
                                        {
                                            Console.WriteLine("Does Not Contain Assigned Keys");
                                        }
                                    }
                                }
                            }
                            else if (breakdown.Contains(mod.Key))
                            {
                                foreach (KeyValuePair<int, Dictionary<string, int>> element in mod.Value)
                                {
                                    foreach (KeyValuePair<string, int> type in element.Value)
                                    {
                                        var check = new Dictionary<string, int> { { type.Key, type.Value } };
                                        if (check.ContainsKey("Mark"))
                                        {
                                            marks.Add(check["Mark"]);
                                            Console.WriteLine(check["Mark"]);
                                        }
                                        else if (check.ContainsKey("Weight"))
                                        {
                                        }
                                        else
                                        {
                                            Console.WriteLine("Does Not Contain Assigned Keys");
                                        }
                                    }
                                }
                            }
                        }
                                
                    }
                }
            }
            foreach (var moddy in breakdown)
            {
                Console.WriteLine(moddy);
            }

            int total = marks.Sum();
            overallMark = total / marks.Count();
            Console.WriteLine($"Average Grade for the Year: {total}%");

            Thread.Sleep(20000);
        }
	}
}
