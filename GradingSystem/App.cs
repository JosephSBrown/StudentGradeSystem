using System;
using System.Collections.Generic;

namespace GradingSystem
{
    class App
    {
        private List<Student> students = new List<Student>();

        public App()
        {

        }
        public bool menu()
        {
            Console.Clear();
            Console.WriteLine(@$"Welcome to Student Grading System
Please Choose an Option Below...
1. Create a New Student
2. Add a New Student
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
                    Console.WriteLine("2");
                    return true;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.WriteLine("3");
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

            interactiveMenu("Return");

        }

        public void viewStudent()
        {
            foreach (Student s in students)
            {
                Console.Write("{0}\t", s.ToString());
            }
            Console.WriteLine();
        }

        private string infoGet(string info)
        {
            Console.Write(info);
            return Console.ReadLine();
        }

        private void interactiveMenu(string input)
        {
            Console.WriteLine($"Press Enter to {input}...");

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
}
