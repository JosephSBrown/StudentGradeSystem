using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Text;

namespace GradingSystem
{
    //Start App Class
    class App
    {
        bool entered = false;   //Bool for Testing if Hard Coded Data is Already in Or Not
        private Dictionary<int, Student> students = new Dictionary<int, Student>();     //Initialise a Dictionary for Students containing the Dictionary Key as Student ID and Dictionary Value as a new Student

        public bool menu()
        {
            if (entered == false)   //If the Student Data hasn't already been added
            { 
                students.Add(12345, new Student(12345, "Johnny Appleseed", "Computing", 2021, 2));                  //Adds a Student as Test Data

                students[12345].Grading.Grades.Add(new Grade(2022, "Object Oriented Programming", 1, 60, 0.2f));    //Adds a Students Grade as Test Data
                students[12345].Grading.Grades.Add(new Grade(2022, "Object Oriented Programming", 2, 65, 0.8f));    //Adds a Students Grade as Test Data
                students[12345].Grading.Grades.Add(new Grade(2022, "Independent Learning Module", 1, 55, 0.6f));    //Adds a Students Grade as Test Data
                students[12345].Grading.Grades.Add(new Grade(2022, "Object Oriented Programming", 2, 65, 0.4f));    //Adds a Students Grade as Test Data
                students[12345].Grading.Grades.Add(new Grade(2022, "Interactive Web", 1, 65, 0.5f));                //Adds a Students Grade as Test Data
                students[12345].Grading.Grades.Add(new Grade(2022, "Interactive Web", 2, 65, 0.5f));                //Adds a Students Grade as Test Data
                students[12345].Grading.Grades.Add(new Grade(2022, "Advanced Database", 1, 65, 0.5f));              //Adds a Students Grade as Test Data
                students[12345].Grading.Grades.Add(new Grade(2022, "Advanced Database", 2, 65, 0.5f));              //Adds a Students Grade as Test Data

                students.Add(24574, new Student(24574, "Barry Speed", "Forensics", 2022, 3));                       //Adds a Student as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Forensic Module", 1, 45, 0.5f));                //Adds a Students Grade as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Forensic Module", 2, 55, 0.5f));                //Adds a Students Grade as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Another Forensic Module", 1, 55, 0.6f));        //Adds a Students Grade as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Another Forensic Module", 2, 65, 0.4f));        //Adds a Students Grade as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Third Forensics", 1, 85, 0.3f));                //Adds a Students Grade as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Third Forensics", 2, 75, 0.7f));                //Adds a Students Grade as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Forenny Mod", 1, 68, 0.8f));                    //Adds a Students Grade as Test Data
                students[24574].Grading.Grades.Add(new Grade(2022, "Forenny Mod", 2, 41, 0.2f));                    //Adds a Students Grade as Test Data
                entered = true;                                                                                 //Set Entered Data to True
            }
                

            Console.Clear();        //Clear the Menu Every Time It's Loaded

            //WriteLine Draws Out the Menu
            Console.WriteLine(@$"Welcome to Student Grading System
Please Choose an Option Below...
1. Create a New Student
2. View an Existing Student
3. Add a New Grade
4. Create a Report Card
5. Exit");

            ConsoleKeyInfo key = Console.ReadKey(true);     //Menu Choices Determined This by Read Key

            //All Values in Switch Case Must Return True as Boolean Menu
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:            //If Numpad1 Pressed
                case ConsoleKey.D1:                 //Or Regular 1
                    createStudent();                //Load Create Student Method
                    return true;
                case ConsoleKey.NumPad2:            //If Numpad2 Pressed
                case ConsoleKey.D2:                 //Or Regular 2
                    viewStudent();                  //Load View Student Method
                    return true;
                case ConsoleKey.NumPad3:            //If Numpad3 Pressed
                case ConsoleKey.D3:                 //Or Regular 3
                    createGrade();                  //Load Create Grade Method
                    return true;
                case ConsoleKey.NumPad4:            //If Numpad4 Pressed
                case ConsoleKey.D4:                 //Or Regular 4
                    viewReportCard();               //Load Report Grade Method
                    return true;
                case ConsoleKey.NumPad5:            //If Numpad5 Pressed
                case ConsoleKey.D5:                 //Or Regular 5
                    exit();                         //Run Exit Method
                    return true;
                default:                            //swicth case must have a default case to fall through
                    return true;
            }
        }

        //Method to Exit the Program
        public void exit() 
        {
            Environment.Exit(0);        //Exit Environment with Reason 0
        }

        //Create a Student Method
        public void createStudent()
        {
            Console.Clear();    //Clear the Console for a Fresh Screen
            int sid = Convert.ToInt32(infoGet("Please Enter a New Student ID: "));              //Get User Input for an Int for Student ID
            string name = infoGet("Please Enter the Student's Name: ");                         //Get User Input for a string for Student Name
            string course = infoGet("Please Enter the Student's Course: ");                     //Get User Input for an string for Student Course
            int enrol = Convert.ToInt32(infoGet("Please Enter Enrolment Year: "));              //Get User Input for an int for Student Enrolment Year
            int cyos = Convert.ToInt32(infoGet("Please Enter Current Year of Study: "));        //Get User Input for an Int for Student Year of Study


            students.Add(sid, new Student(sid, name, course, enrol, cyos));                     //Add Student to List and Create a Student with the User Input Parameters

            Console.WriteLine($"Press Enter to Return...");                                     //Call to Action

            ConsoleKeyInfo key = Console.ReadKey();     //Menu Choices Determined This by Read Key

            //switch case must have a return to be able to fall through the cases
            switch (key.Key)
            {
                case ConsoleKey.Enter:  //If the Key Pressed Is Enter Return
                    return;
                default:                //must end on a default
                    return;
            }

        }

        //Method to Create a Grade
        public void createGrade()
        {
            Console.Clear();
            int sid = Convert.ToInt32(infoGet("Please Enter the Student's ID: "));              //Get User Input for an Int for Student ID
            int year = Convert.ToInt32(infoGet("Please Enter the Year of Completion: "));       //Get User Input for an int for Grades Year
            string module = infoGet("Please Enter the Module Name: ");                          //Get User Input for a string for Module Name
            int assignment = Convert.ToInt32(infoGet("Please Enter Assignment Number: "));      //Get User Input for an int for Assignment Number
            float mark = float.Parse(infoGet("Please Enter Assignment Mark: "));                //Get User Input for an Float for Assignment Mark
            float weight = float.Parse(infoGet("Please Enter Assignment Weighting: "));         //Get User Input for an Float for Assignment Weight

            if (students.ContainsKey(sid))      //If 
            {
                students[sid].Grading.Grades.Add(new Grade(year, module, assignment, mark, weight));        //Add Grade to Specific Student with the User Input Parameters
            }


            Console.WriteLine($"Press Enter to Return..."); //Call to Action

            ConsoleKeyInfo key = Console.ReadKey();         //Menu Choices Determined This by Read Key

            //switch case must have a return to be able to fall through the cases
            switch (key.Key)
            {
                case ConsoleKey.Enter:      //If the Key Pressed Is Enter Return
                    return;
                default:                    //must end on a default
                    return;
            }

        }


        //Method to View a Student
        public void viewStudent()
        {
            Console.Clear();        //Clear Console When Loading Student Table

            DataTable studentT = new DataTable();                           //Create a New Data Table
            studentT.Columns.Add("Student ID", typeof(int));                //Create a Column for Student ID
            studentT.Columns.Add("Name", typeof(string));                   //Create a Column for Student Name
            studentT.Columns.Add("Course", typeof(string));                 //Create a Column for Student Course
            studentT.Columns.Add("Enrolment Year", typeof(int));            //Create a Column for Student Enrolment Year
            studentT.Columns.Add("Current Year of Study", typeof(int));     //Create a Column for Student Current Year of Study

            foreach (KeyValuePair<int, Student> s in students)              //For Each Key and Value in Dictionary
            {
                studentT.Rows.Add(new object[] { s.Value.StudentID, s.Value.Name, s.Value.Course, s.Value.EnrolmentYear, s.Value.CurrentYearOfStudy });     //Create a Row of Each Entry's Student Properties
            }

            foreach (DataColumn col in studentT.Columns)        //For Each Column in the Table
            {
                Console.Write("{0,-14}", col.ColumnName);       //Write the Column Name to Line
            }
            Console.WriteLine();                                //Separating Line

            foreach (DataRow r in studentT.Rows)                //For Each Row in Table
            {
                foreach (DataColumn col in studentT.Columns)    //For Each Column in the Table
                {
                    Console.Write("{0,-14}", r[col]);           //Write the Row's Column Value in Order Left to Right
                }
                Console.WriteLine();                            //Write Line for Separation
            }
            Console.WriteLine();                                //Write Line for Separation

            //Menu Choices for User Input
            Console.WriteLine(@$"Press Enter to Return...
Press Space to Search for a Specific Student's Grades...");

            ConsoleKeyInfo key = Console.ReadKey();         //Menu Choices Determined This by Read Key

            //switch case must have a return to be able to fall through the cases
            switch (key.Key)
            {
                case ConsoleKey.Enter:                  //If the Key Pressed Is Enter Return
                    return;
                case ConsoleKey.Spacebar:               //If the Key Pressed Is Space Return
                    viewGrades();       
                    return;
                default:                                //must end on a default
                    return;
            }

        }

        //Method to Display a Student's Grades
        public void viewGrades()
        {
            Console.Clear();        //Clear the Console From Previous Every Time IT's Called

            Console.Write("Input Desired Student ID: ");        //Write Call To Action

            string searchTerm = Console.ReadLine();             //Take User Input

            Console.Clear();                                    //Clear the Console

            //Below is a WriteLine in order to Display Minor Student Information
            Console.WriteLine($@"Name: {students[Convert.ToInt32(searchTerm)].Name}         
Course: {students[Convert.ToInt32(searchTerm)].Course}
Current: {students[Convert.ToInt32(searchTerm)].CurrentYearOfStudy}
");

            DataTable gradet = new DataTable();                 //Create New Data Table
            gradet.Columns.Add("Year", typeof(int));            //Add Column for Grade's Year
            gradet.Columns.Add("Module", typeof(string));        //Add Column for Grade's Module
            gradet.Columns.Add("Assignment", typeof(int));      //Add Column for Grade's Assignment Number
            gradet.Columns.Add("Mark", typeof(float));          //Add Column for Grade's Mark
            gradet.Columns.Add("Weight", typeof(float));        //Add Column for Grade's Weighting

            foreach (KeyValuePair<int, Student> s in students)      //For Each Entry into Students
            {
                if (students.ContainsKey(Convert.ToInt32(searchTerm)))      //If the Dictionary Contains the Key from the Search Term
                {
                    foreach (Grade g in s.Value.Grading.Grades)             //For Each Grade in Student
                    {
                        gradet.Rows.Add(new object[] { g.Year, g.Module, g.Assignment, g.Mark, g.Weight });         //Add a Row with All Required Grade Parameters
                    }
                    
                }
            }

            foreach (DataColumn col in gradet.Columns)              //For Each Column in the Table
            {
                Console.Write("{0,-14}", col.ColumnName);           //Write the Column Name to Line
            }
            Console.WriteLine();                                    //Separating Line

            foreach (DataRow r in gradet.Rows)                      //For Each Row in Table
            {
                foreach (DataColumn col in gradet.Columns)          //For Each Column in the Table
                {
                    Console.Write("{0,-14}", r[col]);               //Write the Row's Column Value in Order Left to Right
                }
                Console.WriteLine();                                //Write Line for Separation
            }
            Console.WriteLine();                                    //Write Line for Separation

            //Call to Action Menu Choices
            Console.WriteLine(@$"Press Enter to Return...
Press Space to Search Again for a Specific Student's Grades...");

            ConsoleKeyInfo key = Console.ReadKey();             //Menu Choices Determined This by Read Key

            //switch case must have a return to be able to fall through the cases
            switch (key.Key)
            {
                case ConsoleKey.Enter:              //If the Key Pressed Is Enter Return
                    return;
                case ConsoleKey.Spacebar:           //If the Key Pressed Is Space Return
                    viewGrades();
                    return;
                default:                            //must end on a default
                    return;
            }

        }

        //Method to View a Student's Report Card
        public void viewReportCard()
        {
            Console.Clear();        //Clear the Console From Previous Every Time IT's Called

            Console.Write("Input Desired Student ID: ");            //Call to Action

            string searchTerm = Console.ReadLine();             //User Input

            Console.Clear();            //Clear the Console of Previous

            if (students.ContainsKey(Convert.ToInt32(searchTerm)))          //If the Search Term is Found in the Dictionary
            {
                //The Below Writes All the Required Student Information to the Window
                Console.Write($@"---- REPORT CARD ----
Student Name: {students[Convert.ToInt32(searchTerm)].Name}
Student Course: {students[Convert.ToInt32(searchTerm)].Course}
Current Year: {students[Convert.ToInt32(searchTerm)].CurrentYearOfStudy}
Year of Enrolment: {students[Convert.ToInt32(searchTerm)].EnrolmentYear}

");
                GradeProfile.calcAvg(students, searchTerm);             //Call to the Calculated Grade Average

                GradeProfile.calcIndividualAvg(students, searchTerm);       //Call to the Calculated Grade Average of Every Module

                DataTable reportT = new DataTable();                        //Create a New Data Table
                reportT.Columns.Add("Year", typeof(int));                   //Create a Column for the Grades Year
                reportT.Columns.Add("Module", typeof(string));              //Create a Column for the Grades Module
                reportT.Columns.Add("Assignment", typeof(int));             //Create a Column for the Grades Assignment
                reportT.Columns.Add("Mark", typeof(float));                 //Create a Column for the Grades Mark
                reportT.Columns.Add("Weight", typeof(float));               //Create a Column for the Grades Weight

                foreach (KeyValuePair<int, Student> s in students)          //For Each Student in the Dictionary
                {
                    if (students.ContainsKey(Convert.ToInt32(searchTerm)))  //If the User Input is a Key Within the Dictionary
                    {
                        foreach (Grade g in s.Value.Grading.Grades)         //For Each Grade in the Students Properties
                        {
                            if (s.Key == Convert.ToInt32(searchTerm))       //If the Key is Exactly Equal to the Search Term
                            { 
                                reportT.Rows.Add(new object[] { g.Year, g.Module, g.Assignment, g.Mark, g.Weight});         //Add a Row with All Required Grade Parameters
                            }
                            
                        
                        }

                    }
                }

                foreach (DataColumn col in reportT.Columns)                 //For Each Column in the Table
                {   
                    Console.Write("{0,-14}", col.ColumnName);               //Write the Column Name to Line
                }
                Console.WriteLine();                                        //Separating Line

                foreach (DataRow r in reportT.Rows)                         //For Each Row in Table
                {
                    foreach (DataColumn col in reportT.Columns)             //For Each Column in the Table
                    {
                        Console.Write("{0,-14}", r[col]);                   //Write the Row's Column Value in Order Left to Right
                    }
                    Console.WriteLine();                                    //Write Line for Separation
                }   
                Console.WriteLine();                                        //Write Line for Separation

                Console.WriteLine($"Press Enter to Return...");     //Call to Action

                ConsoleKeyInfo key = Console.ReadKey();         //Menu Choices Determined This by Read Key

                //switch case must have a return to be able to fall through the cases
                switch (key.Key)
                {
                    case ConsoleKey.Enter:          //If the Key Pressed Is Enter Return
                        return;
                    default:                        //must end on a default
                        return;
                }
            }
        }

        //Easy Method in Order to Write a Question to Line and Get User Input, Very Reusable
        private string infoGet(string info)     //Takes string as Parameter
        {   
            Console.Write(info);                //Parameter is Question asked by App
            return Console.ReadLine();          //This Returns the Users Response
        }

    }
}
