using System;

namespace GradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showmenu = true;
            App app = new App();

            while (showmenu)
            {
                showmenu = app.menu();
            }
        }
    }
}
