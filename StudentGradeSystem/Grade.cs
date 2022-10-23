using System;
using System.Collections.Generic;

namespace StudentGradeSystem
{
    class Grade
    {
        public Dictionary<int, Dictionary<string, Dictionary<int, Tuple<int, float>>>> grades = new Dictionary<int, Dictionary<string, Dictionary<int, Tuple<int, float>>>>();
    }
}