﻿using System;

namespace StudentGradeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showmenu = true;
            Student student = new Student();
            Grade grade = new Grade();
            gradeProfile gp = new gradeProfile();
            MainMenu mm = new MainMenu();

            while (showmenu)
            {
                showmenu = mm.menu(student, grade, gp);
            }
        }
    }
}
