using System;
using System.Collections.Generic;
using System.Data;

namespace StudentGradeSystem
{
	class MainMenu
	{
		public bool menu(Student student, Grade grade)
		{
			Console.Clear();
			Console.WriteLine("----Welcome to the Student Directory----");
			Console.WriteLine("Please Choose an Option: ");
			Console.WriteLine("1. Create a Student");
			Console.WriteLine("2. View an Existing Student");
			Console.WriteLine("3. Add Grade to Existing Student");
			Console.WriteLine("4. Exit Program");

			ConsoleKeyInfo key = Console.ReadKey(true);

			switch (key.Key)
			{
				case ConsoleKey.NumPad1:
				case ConsoleKey.D1:
					createStudent(student, grade);
					return true;
				case ConsoleKey.NumPad2:
				case ConsoleKey.D2:
					viewStudent(student, grade);
					return true;
				case ConsoleKey.NumPad3:
				case ConsoleKey.D3:
					grade.createGrade();
					return true;
				case ConsoleKey.NumPad4:
				case ConsoleKey.D4:
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

		public void menuinteractivity()
		{

			Console.WriteLine("Press Enter to Continue...");

			//On Page Interactivity = Going back to the previous menu
			ConsoleKeyInfo key = Console.ReadKey();

			switch (key.Key)
			{
				case ConsoleKey.Enter:
					return;
				default:
					return;
			}
		}

		public void createStudent(Student student, Grade grade)
		{
			Console.Clear(); //clears the menu to begin the function
			Console.WriteLine("----Create A New Student----"); //page header
			Console.Write("Please Enter a Name: "); 
			student.Name = Console.ReadLine();
			Console.Write("Please Enter an Address: ");
			student.Address = Console.ReadLine();
			Console.Write("Please Enter a Course Title: ");
			student.Course = Console.ReadLine();

			foreach (KeyValuePair<int, Dictionary<string, string>> sid in student.students) //sid is reference to an abbreviated version of student id
			{
				bool match = true;
				while (match)
				{
					Random rnum = new Random();
					int num = rnum.Next(100000, 999999);
					Console.WriteLine(num);
					if (sid.Key != num)
					{
						student.StudentId = num;
						match = false;
					}
					else if (sid.Key == num)
					{
						Console.WriteLine("There Was An Error Generating Student ID, Please Try Again...");
						return;
					}
					else
					{
						match = true;
					}
				}
			}

			Console.WriteLine($"Creating Student Profile for {student.Name} as Student Number: {student.StudentId}");
			Dictionary<string, string> details = new Dictionary<string, string>();
			details.Add("Name", student.Name);
			details.Add("Address", student.Address);
			details.Add("Course", student.Course);
			student.students.Add(student.StudentId, details);

			menuinteractivity();

		}

        public void viewStudent(Student student, Grade grade)
        {
            Console.Clear();

			DataTable studentt = new DataTable("Students");
			DataColumn column;
			DataRow row;

			//Column for StudentID
			column = new DataColumn();
			column.DataType = typeof(int);
			column.ColumnName = "StudentID";
			column.Caption = "StudentID";
			column.AutoIncrement = false;
			column.ReadOnly = false;
			column.Unique = false;
			studentt.Columns.Add(column);

			//Column for Student Name
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = "Name";
			column.Caption = "Name";
			column.AutoIncrement = false;
			column.ReadOnly = false;
			column.Unique = false;
			studentt.Columns.Add(column);

			//Column for Course
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = "Course";
			column.Caption = "Course";
			column.AutoIncrement = false;
			column.ReadOnly = false;
			column.Unique = false;
			studentt.Columns.Add(column);

			foreach (KeyValuePair <int, Dictionary<string, string>> sid in student.students) //sid is reference to an abbreviated version of student id
			{
				row = studentt.NewRow();
				row["StudentID"] = sid.Key;
				foreach (KeyValuePair<string, string> detail in sid.Value) //detail is reference to personal details kept within the nested dictionary
				{
					if (detail.Key == "Name") //if the key value in the nested dictionary is exactly equal to "Name" write it within the console
					{
						row["Name"] = detail.Value;
					}
					else if (detail.Key == "Course") //if the key value in the nested dictionary is exactly equal to "Course" write it within the console
					{
						row["Course"] = detail.Value;
					}
				}
				studentt.Rows.Add(row);
			}

			foreach (DataColumn col in studentt.Columns)
			{
				Console.Write("{0,-14}", col.ColumnName);
			}
			Console.WriteLine();

			foreach (DataRow r in studentt.Rows)
			{
				foreach (DataColumn col in studentt.Columns)
				{
					Console.Write("{0,-14}", r[col]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			//On Page Interactivity = Going back to the previous menu
			Console.WriteLine("Press Enter to Search and Go to a Student's Profile...");
			Console.WriteLine("Press Escape to Go Back...");

			ConsoleKeyInfo key = Console.ReadKey();

			switch (key.Key)
			{
				case ConsoleKey.Enter:
					return;
				case ConsoleKey.Escape:
					return;
				default:
					return;
			}

		}

    }
}
