using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace GradingSystem
{
    class App
    {

        private Dictionary<int, Student> students = new Dictionary<int, Student>();

        public bool menu()
        {

            //Console.Write("Attempting to Load Data...");
            //if (File.Exists(@"students.json"))
            //{
            //    string studentList;
            //    using (StreamReader dataread = new StreamReader(@"students.json", Encoding.Default))
            //    {
            //        studentList = dataread.ReadToEnd();
            //    }
            //    students = JsonConvert.DeserializeObject<Dictionary<int, Student>>(studentList);
            //}
            //else 
            //{
            //    students = new Dictionary<int, Student>();
            //}

            Console.Clear();
            Console.WriteLine(@$"Welcome to Student Grading System
Please Choose an Option Below...
1. Create a New Student
2. View an Existing Student
3. Add a New Grade
4. Create a Report Card
5. Exit");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    createStudent();
                    return true;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    viewStudent();
                    return true;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    createGrade();
                    return true;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.WriteLine("4");
                    viewReportCard();
                    return true;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    exit();
                    return true;
                default:
                    return true;
            }
        }

        public void exit() 
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);

            using (StreamWriter file = File.CreateText(@"students.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, json);
            }

            Console.WriteLine("Saving...");
            Environment.Exit(0);
        }

        public void createStudent()
        {
            Console.Clear();
            int sid = Convert.ToInt32(infoGet("Please Enter a New Student ID: "));
            string name = infoGet("Please Enter the Student's Name: ");
            string course = infoGet("Please Enter the Student's Course: ");
            int enrol = Convert.ToInt32(infoGet("Please Enter Enrolment Year: "));
            int cyos = Convert.ToInt32(infoGet("Please Enter Current Year of Study: "));


            students.Add(sid, new Student(sid, name, course, enrol, cyos));

            Console.WriteLine($"Press Enter to Return...");

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    return;
                default:
                    return;
            }

        }

        public void createGrade()
        {
            Console.Clear();
            int sid = Convert.ToInt32(infoGet("Please Enter the Student's ID: "));
            int year = Convert.ToInt32(infoGet("Please Enter the Year of Completion: "));
            string module = infoGet("Please Enter the Module Name: ");
            int assignment = Convert.ToInt32(infoGet("Please Enter Assignment Number: "));
            float mark = float.Parse(infoGet("Please Enter Assignment Mark: "));
            float weight = float.Parse(infoGet("Please Enter Assignment Weighting: "));

            if (students.ContainsKey(sid))
            {
                students[sid].Grading.Grades.Add(new Grade(year, module, assignment, mark, weight));
            }


            Console.WriteLine($"Press Enter to Return...");

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    return;
                default:
                    return;
            }

        }

        public void viewStudent()
        {
            Console.Clear();

            DataTable studentT = new DataTable();
            studentT.Columns.Add("Student ID", typeof(int));
            studentT.Columns.Add("Name", typeof(string));
            studentT.Columns.Add("Course", typeof(string));
            studentT.Columns.Add("Enrolment Year", typeof(int));
            studentT.Columns.Add("Current Year of Study", typeof(int));

            foreach (KeyValuePair<int, Student> s in students)
            {
                studentT.Rows.Add(new object[] { s.Value.StudentID, s.Value.Name, s.Value.Course, s.Value.EnrolmentYear, s.Value.CurrentYearOfStudy });
            }

            foreach (DataColumn col in studentT.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow r in studentT.Rows)
            {
                foreach (DataColumn col in studentT.Columns)
                {
                    Console.Write("{0,-14}", r[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine(@$"Press Enter to Return...
Press Space to Search for a Specific Student's Grades...");

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    return;
                case ConsoleKey.Spacebar:
                    viewGrades();
                    return;
                default:
                    return;
            }

        }

        public void viewGrades()
        {
            Console.Clear();

            Console.Write("Input Desired Student ID: ");

            string searchTerm = Console.ReadLine();

            DataTable gradet = new DataTable();
            gradet.Columns.Add("Year", typeof(int));
            gradet.Columns.Add("Module", typeof(string));
            gradet.Columns.Add("Assignment", typeof(int));
            gradet.Columns.Add("Mark", typeof(float));
            gradet.Columns.Add("Weight", typeof(float));

            foreach (KeyValuePair<int, Student> s in students)
            {
                if (default(KeyValuePair<int, Student>).Equals(searchTerm))
                {
                    foreach (Grade g in s.Value.Grading.Grades)
                    {
                        gradet.Rows.Add(new object[] { g.Year, g.Module, g.Assignment, g.Mark, g.Weight });
                    }
                    
                }
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

            Console.WriteLine(@$"Press Enter to Return...
Press Space to Search Again for a Specific Student's Grades...");

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    return;
                case ConsoleKey.Spacebar:
                    viewGrades();
                    return;
                default:
                    return;
            }

        }

        public void viewReportCard()
        {
            Console.Clear();

            Console.Write("Input Desired Student ID: ");

            string searchTerm = Console.ReadLine();

            if (default(KeyValuePair<int, Student>).Equals(searchTerm))
            {
                Console.Write($@"---- REPORT CARD ----
Student Name: {students[Convert.ToInt32(searchTerm)].Name}
Current Year: {students[Convert.ToInt32(searchTerm)].CurrentYearOfStudy}
Year of Enrolment: {students[Convert.ToInt32(searchTerm)].EnrolmentYear}
");
                GradeProfile.calcAvg(students, searchTerm);

                DataTable reportT = new DataTable();
                reportT.Columns.Add("Year", typeof(int));
                reportT.Columns.Add("Module", typeof(string));
                reportT.Columns.Add("Assignment", typeof(int));
                reportT.Columns.Add("Mark", typeof(float));
                reportT.Columns.Add("Weight", typeof(float));
                reportT.Columns.Add("Mark Towards Final", typeof(float));

                foreach (KeyValuePair<int, Student> s in students)
                {
                    if (default(KeyValuePair<int, Student>).Equals(searchTerm))
                    {
                        foreach (Grade g in s.Value.Grading.Grades)
                        {
                            reportT.Rows.Add(new object[] { g.Year, g.Module, g.Assignment, g.Mark, g.Weight});
                        }

                    }
                }

                Console.WriteLine($"Press Enter to Return...");

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        return;
                    default:
                        return;
                }
            }
        }

        private string infoGet(string info)
        {
            Console.Write(info);
            return Console.ReadLine();
        }

    }
}
