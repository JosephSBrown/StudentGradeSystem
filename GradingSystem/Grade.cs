using System;

namespace GradingSystem
{
	//Start Grade Class
	class Grade
	{
		public int Year { get; set; }	//Get and Set the Year Field of Object
		public string Module { get; set; }  //Get and Set the Module Field of Object
		public int Assignment { get; set; } //Get and Set the Assignment Field of Object
		public float Mark { get; set; }     //Get and Set the Mark Field of Object
		public float Weight { get; set; }       //Get and Set the Weight Field of Object

		//Set the Properties of the new Grade when called
		public Grade(int year, string module, int assignment, float mark, float weight)		//Parameters equivalent to the body, Use the Parameters to Set the new Grade
		{
			Year = year;
			Module = module;
			Assignment = assignment;
			Mark = mark;
			Weight = weight;
		}

	}
}
