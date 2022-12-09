using System;

namespace GradingSystem
{
    //Start Program
    class Program
    {
        //Main Method, Required to Run Program
        static void Main(string[] args)
        {
            bool showmenu = true;   //Menu is a Boolean so requires to be in While Loop
            App app = new App();    //Create a new instance of App

            while (showmenu)        //Initialise Loop
            {
                showmenu = app.menu();      //show the app menu
            }
        }
    }
}
