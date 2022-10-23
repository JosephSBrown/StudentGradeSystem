using System;
using System.Collections.Generic;

namespace StudentGradeSystem
{
	class Student
	{
		public string name;
		public string address;
		public int studentId;
		public string course;
		public Dictionary<int, Dictionary<string, string>> students = new Dictionary<int, Dictionary<string, string>>();

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Address
		{
			get { return address; }
			set { address = value; }
		}

		public int StudentId
		{
			get { return studentId; }
			set { studentId = value; }
		}

		public string Course
		{
			get { return course; }
			set { course = value; }
		}

	}
}
