using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace StudentGradeSystem
{
    class Grade
    {
        public Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>>> grades = new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>>>();
        public int studentid;
        public int year;
        public string module;
        public int assignment;
        public int mark;
        public int weight;
        int NextIndex = 0;

        public void createGrade()
        {
            Console.Clear();
            Console.Write("Please Enter a Student ID: ");
            studentid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please Write Year of Grade Completion: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please Enter the Module Name: ");
            module = Console.ReadLine();
            Console.Write("Please Enter Assignment Number: ");
            assignment = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please Enter the Assignment Mark: ");
            mark = Convert.ToInt32(Console.ReadLine());
            Console.Write(@"Please Enter the Assignment Weighting
(Write This As a Whole Number e.g. 50 or 70): ");
            weight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($@"Please Check the Following Is Correct:

Student ID: {studentid}
Completion Year: {year}
Module Title: {module}
Assignment Number: {assignment}
Mark: {mark}
Weighting: {weight}

If This is Correct, Please Press Enter To Continue, To Start Again, Please Press Escape: ");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    addGrade(grades, studentid, year, module, assignment, mark, weight);
                    Console.WriteLine("Student's Grade Added... ");
                    selectAllGrades();
                    Thread.Sleep(20000);
                    return;
                case ConsoleKey.Escape:
                    return;
                default:
                    return;
            }

        }

        public void addGrade(Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>>> grades, int studentid, int year, string module, int assignment, int mark, int weight)
        {

            Dictionary<string, int> type = new Dictionary<string, int>();
            Dictionary<int, Dictionary<string, int>> element = new Dictionary<int, Dictionary<string, int>>();
            Dictionary<string, Dictionary<int, Dictionary<string, int>>> mod = new Dictionary<string, Dictionary<int, Dictionary<string, int>>>();
            Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>> yr = new Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>();
            Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>> sid = new Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>>();
            type.Add("Mark", mark);
            type.Add("Weight", weight);
            element.Add(assignment, type);
            mod.Add(module, element);
            yr.Add(year, mod);
            sid.Add(studentid, yr);
            int currentIndex = NextIndex;
            grades.Add(currentIndex, sid);
            NextIndex = grades.Keys.Max() + 1;

        }

        public void selectAllGrades()
        {
            Console.WriteLine("Year | Module       | Element | Mark | Weight");
            foreach (KeyValuePair<int, Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>>> i in grades)
            {
                foreach (KeyValuePair<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>> sid in i.Value)
                {
                    foreach (KeyValuePair<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>> yr in sid.Value)
                    {
                        foreach (KeyValuePair<string, Dictionary<int, Dictionary<string, int>>> mod in yr.Value)
                        {
                            foreach (KeyValuePair<int, Dictionary<string, int>> element in mod.Value)
                            { 
                                foreach (KeyValuePair<string, int> type in element.Value)
                                {
                                    Console.Write($"{yr.Key} | {mod.Key} | {element.Key} | ");
                                    if (type.Key == "Mark")
                                    {
                                        Console.Write($"{type.Value} | ");
                                    }
                                    else if (type.Key == "Weight")
                                    {
                                        Console.WriteLine($"{type.Value}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}