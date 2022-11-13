using System;
using System.Collections.Generic;

namespace GradingSystem
{
	class Student
	{
		public int StudentID { get; set; }
		public string Name { get; set; }
		public string Course { get; set; }
		public int EnrolmentYear { get; set; }
		public int CurrentYearOfStudy { get; set; }
		public GradeProfile Grading = new GradeProfile();

		public Student(int sid, string name, string course ,int enrol, int cyos)
		{

			StudentID = sid;
			Name = name;
			Course = course;
			EnrolmentYear = enrol;
			CurrentYearOfStudy = cyos;

		}

	}
}
