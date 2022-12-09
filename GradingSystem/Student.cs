using System;
using System.Collections.Generic;

namespace GradingSystem
{
	//Start Student Class
	class Student
	{
		public int StudentID { get; set; }  //Get and Set the Student ID Field of Object
		public string Name { get; set; }        //Get and Set the Name Field of Object
		public string Course { get; set; }      //Get and Set the Course Field of Object
		public int EnrolmentYear { get; set; }      //Get and Set the Enrolment Year Field of Object
		public int CurrentYearOfStudy { get; set; }     //Get and Set the Current Year of Study Field of Object
		public GradeProfile Grading = new GradeProfile();       //Create a New Instance of GradeProfile

		//Set the Properties of the new Student when called
		public Student(int sid, string name, string course ,int enrol, int cyos)        //Parameters equivalent to the body, Use the Parameters to Set the new Student
		{

			StudentID = sid;
			Name = name;
			Course = course;
			EnrolmentYear = enrol;
			CurrentYearOfStudy = cyos;

		}

	}
}
