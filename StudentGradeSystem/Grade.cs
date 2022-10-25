using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Data;

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
                    Thread.Sleep(2000);
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

        public void displayStudentsGrades(Student student)
        {
            DataTable gradet = new DataTable("Grades");
            DataColumn column;
            DataRow row;

            //Year
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Year";
            column.Caption = "Year";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            gradet.Columns.Add(column);

            //Module
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Module";
            column.Caption = "Module";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            gradet.Columns.Add(column);

            //Element
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Element";
            column.Caption = "Element";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            gradet.Columns.Add(column);

            //Mark
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Mark";
            column.Caption = "Mark";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            gradet.Columns.Add(column);

            //Weight
            column = new DataColumn();
            column.DataType = typeof(float);
            column.ColumnName = "Weight";
            column.Caption = "Weight";
            column.AutoIncrement = false;
            column.ReadOnly = true;
            column.Unique = false;
            gradet.Columns.Add(column);

            Console.Write("Please Enter Student ID: ");
            int stuid = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            foreach (KeyValuePair<int, Dictionary<string, string>> sid in student.students) //sid is reference to an abbreviated version of student id
            {
                var check = new Dictionary<int, Dictionary<string, string>> { { sid.Key, sid.Value } };
                if (check.ContainsKey(stuid))
                {
                    Console.WriteLine($"Student ID: {sid.Key}");
                    foreach (KeyValuePair<string, string> detail in sid.Value) //detail is reference to personal details kept within the nested dictionary
                    {
                        if (detail.Key == "Name") //if the key value in the nested dictionary is exactly equal to "Name" write it within the console
                        {
                            Console.WriteLine($"Name: {detail.Value}");
                        }
                        else if (detail.Key == "Course") //if the key value in the nested dictionary is exactly equal to "Course" write it within the console
                        {
                            Console.WriteLine(@$"Course: {detail.Value}

");
                        }
                    }
                }
            }

            foreach (KeyValuePair<int, Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>>> i in grades)
            {
                row = gradet.NewRow();
                foreach (KeyValuePair<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>> sid in i.Value)
                {
                    var check = new Dictionary<int, Dictionary<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>>> { { sid.Key, sid.Value} };
                    if (check.ContainsKey(stuid))
                    { 
                        foreach (KeyValuePair<int, Dictionary<string, Dictionary<int, Dictionary<string, int>>>> yr in sid.Value)
                        {
                        row["Year"] = yr.Key;
                            foreach (KeyValuePair<string, Dictionary<int, Dictionary<string, int>>> mod in yr.Value)
                            {
                                row["Module"] = mod.Key;
                                foreach (KeyValuePair<int, Dictionary<string, int>> element in mod.Value)
                                {
                                    row["Element"] = element.Key;
                                    foreach (KeyValuePair<string, int> type in element.Value)
                                    {
                                        if (type.Key == "Mark")
                                        {
                                            row["Mark"] = type.Value;
                                        }
                                        else if (type.Key == "Weight")
                                        {
                                            row["Weight"] = (float)type.Value / 100;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }
                gradet.Rows.Add(row);
            }

            foreach (DataColumn col in gradet.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow r in gradet.Rows)
            {
                foreach (DataColumn col in gradet.Columns)
                {
                    Console.Write("{0,-14}", r[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            ConsoleKeyInfo key = Console.ReadKey();
            Console.Write("Press Enter To Continue...");

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    return;
                default:
                    return;
            }

        }
    }
}