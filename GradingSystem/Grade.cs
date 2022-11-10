using System;

namespace GradingSystem
{
	class Grade
	{
		public int Sid { get; set; }
		public int Year { get; set; }
		public string Module { get; set; }
		public int Assignment { get; set; }
		public float Mark { get; set; }
		public float Weight { get; set; }

		public Grade(int sid, int year, string module, int assignment, float mark, float weight)
		{
			Sid = sid;
			Year = year;
			Module = module;
			Assignment = assignment;
			Mark = mark;
			Weight = weight;
		}

	}
}
