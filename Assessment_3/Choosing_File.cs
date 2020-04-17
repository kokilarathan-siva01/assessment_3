using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assessment_3
{
    class Choosing_File
    {   // retrive and stores all of the files from the main program.
        public List<string[]> all_files { get; set; }
        // stores the number of files avaliable to select, for error handling purpose.
        public int total_files { get; set; }
        
        public Choosing_File(List<string[]> files, int number_of_files) // Creating an object, to retrive the files.
        {
            all_files = files;
            total_files = number_of_files - 1;

        }

        public string[] file_output() // A method for displaying. it will be used for selecting the file for checking.
        {
            int Choice = user_choice();

            // an if statement, that will re-interate a loop when the user's entered number is not within the limit and asks the user to input a value again. 
            if (Choice >= 0 && Choice <= total_files)
            {
                string[] file =all_files[Choice] ;
                return file;
            }
            else if (Choice==-1)
            {
                Console.WriteLine("Error!!!" + "Please Select an integer instead of a string value to proceeed.");
                return file_output();
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Sorry! Please select a valid number to proceeed.", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;
                return file_output(); // this statement will allow the program to re-interate a loop. 
                // The above statement can be a form of error handling method

            }


           
        }

        public int user_choice()
        {
            try
            {
                // Asking the using to choose what text file they want to compare.
                Console.WriteLine("Please Enter a number to select which files to check: -->" + "\n" +
                       "0 -> Text File 1a " + "\n" +
                       "1 -> Text file 1b " + "\n" +
                       "2 -> Text File 2a " + "\n" +
                       "3 -> Text File 2b " + "\n" +
                       "4 -> Text File 3a " + "\n" +
                       "5 -> Text File 3b ");
                string user_option = Console.ReadLine();
                int Choice = Convert.ToInt32(user_option);
                return Choice;
            }
            catch (Exception)
            {

                return -1;
            }


        }
    }
}
