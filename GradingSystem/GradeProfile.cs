using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace GradingSystem
{
    //Start of  GradeProfile Class
    class GradeProfile
    { 
        public List<Grade> Grades = new List<Grade>(); //Initialising a List Instance of Grades
        
        //Method for Calculating the Grade Average
        public static void calcAvg(Dictionary<int, Student> students, string searchTerm)
        {

            if (students.ContainsKey(Convert.ToInt32(searchTerm))) //If Student Dictionary Contains Search Term
            {
                foreach (KeyValuePair<int, Student> s in students)  //For Each Item In Dictionary
                {
                    if (s.Key == Convert.ToInt32(searchTerm))       //If the Dictionary Key is Exactly Equal to the Search Term
                    { 
                        List < Grade > sortedGrades = s.Value.Grading.Grades.OrderBy(o => o.Module).ToList();   //Sort All of the Grades into a List
                        float mark = sortedGrades.Sum(sg => sg.Mark * sg.Weight);       //Sum all of the Grades as Mark * Weight
                        float total = mark / sortedGrades.Count() * 2;              //Total Mark Divided by the Count of Grades Multiplied By 2
                        //Below Writes the Mark to Line With Space Underneath
                        Console.WriteLine(@$"Total Mark Average: {total}            

");
                    }
                        
                }
            }

        }

        //Method for Calculating the Individual Average of Every Grade
        public static void calcIndividualAvg(Dictionary<int, Student> students, string searchTerm)
        {

            DataTable ig = new DataTable(); //create a new data table for individual grades
            ig.Columns.Add("Module", typeof(string));   //add a new column for Modules as a String
            ig.Columns.Add("Overall Grade", typeof(int));     //add a new column to table for Overall Module Grade  

            if (students.ContainsKey(Convert.ToInt32(searchTerm)))          //If Student Dictionary Contains Search Term
            {
                foreach (KeyValuePair<int, Student> s in students)      //For Each Item In Dictionary
                {   
                    if (s.Key == Convert.ToInt32(searchTerm))       //If the Dictionary Key is Exactly Equal to the Search Term
                    { 
                        List<Grade> sortedGrades = s.Value.Grading.Grades.OrderBy(o => o.Module).ToList();      //Order All the Grades By Module into a List
                        var individualTotal = sortedGrades.GroupBy(g => g.Module).Select(m => new { Key = m.Key, Value = (int)m.Sum(s => s.Mark * s.Weight)});      //Group All the Grades and Sort Select Each Grade By Module, Summing the Mark and Weight
                        foreach (var group in individualTotal)              //for each grouped value in the list
                        {
                            ig.Rows.Add(group.Key, group.Value);            //write a new row to the table with the Modules Title and Grade
                        }
                    }
                        
                }
            }

            foreach (DataColumn col in ig.Columns)          //For Each Column in the Table
            {
                Console.Write("{0,-20}", col.ColumnName);       //Write the Column Name to Line
            }
            Console.WriteLine();                //Separating Line

            foreach (DataRow r in ig.Rows)          //For Each Row in Table
            {
                foreach (DataColumn col in ig.Columns)          //For Each Column in the Table
                {       
                    Console.Write("{0,-20}", r[col]);           //Write the Row's Column Value in Order Left to Right
                }
                Console.WriteLine();        //Write Line for Separation
            }
            Console.WriteLine();            //Write Line for Separation

        }

    }
}
