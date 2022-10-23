using System;

namespace StudentGradeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showmenu = true;
            Student student = new Student();
            MainMenu mm = new MainMenu();

            while (showmenu)
            {
                showmenu = mm.menu(student);
            }
        }
    }
}
