using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace GradingSystem
{
    class App
    {
        private List<Student> students = new List<Student>();

        public bool menu()
        {
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
            Environment.Exit(0);
        }

        public void createStudent()
        {
            Console.Clear();
            string name = infoGet("Please Enter the Student's Name: ");
            string course = infoGet("Please Enter the Student's Course: ");
            int enrol = Convert.ToInt32(infoGet("Please Enter Enrolment Year: "));
            int cyos = Convert.ToInt32(infoGet("Please Enter Current Year of Study: "));

            students.Add(new Student(name, course, enrol, cyos));

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

            GradeProfile.Grades.Add(new Grade(sid, year, module, assignment, mark, weight));

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
            studentT.Columns.Add("Name", typeof(string));
            studentT.Columns.Add("Course", typeof(string));
            studentT.Columns.Add("Enrolment Year", typeof(int));
            studentT.Columns.Add("Current Year of Study", typeof(int));

            foreach (Student s in students)
            {
                studentT.Rows.Add(new object[] { s.Name, s.Course, s.EnrolmentYear, s.CurrentYearOfStudy });
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
            gradet.Columns.Add("Student ID", typeof(int));
            gradet.Columns.Add("Year", typeof(int));
            gradet.Columns.Add("Module", typeof(string));
            gradet.Columns.Add("Assignment", typeof(int));
            gradet.Columns.Add("Mark", typeof(float));
            gradet.Columns.Add("Weight", typeof(float));

            foreach (Grade g in GradeProfile.Grades)
            {
                gradet.Rows.Add(new object[] { g.Sid, g.Year, g.Module, g.Assignment, g.Mark, g.Weight });
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

        private string infoGet(string info)
        {
            Console.Write(info);
            return Console.ReadLine();
        }

    }
}
