using System;

namespace GradingSystem
{
	class Student
	{

		public string Name { get; set; }
		public string Course { get; set; }
		public int EnrolmentYear { get; set; }
		public int CurrentYearOfStudy { get; set; }

		public Student(string name, string course ,int enrol, int cyos)
		{

			Name = name;
			Course = course;
			EnrolmentYear = enrol;
			CurrentYearOfStudy = cyos;

		}

	}
}
