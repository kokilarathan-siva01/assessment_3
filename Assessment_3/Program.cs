using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Assessment_3
{
   
    class Program
    {
        static void Main(string[] args)
        {
            // This is used to store the text file into an string array variable.
            string[] text_file_1a = File.ReadAllLines("GitRepositories_1a.txt");
            string[] text_file_1b = File.ReadAllLines("GitRepositories_1b.txt");
            string[] text_file_2a = File.ReadAllLines("GitRepositories_2a.txt");
            string[] text_file_2b = File.ReadAllLines("GitRepositories_2b.txt");
            string[] text_file_3a = File.ReadAllLines("GitRepositories_3a.txt");
            string[] text_file_3b = File.ReadAllLines("GitRepositories_3b.txt");

            // a list to store all of the files, so that it can be retrived when selecting the files
            List<string[]> all_files = new List<string[]> {text_file_1a,text_file_1b,text_file_2a,text_file_2b,text_file_3a,text_file_3b };

            int total_files = all_files.Count; // this number can be used to create a error message when the user is selecting a file.
            // I used a class, so that i can re-interate the program to ask the user again, if the number is invalid.
            Choosing_File select_file = new Choosing_File(all_files, total_files);
            string[] Text_file1 = select_file.file_output() ;// initating the method to ask the user for a file.
            string[] Text_file2 = select_file.file_output();

            string one = "my name is rathan";
            string two = "my name is kokilarathan";
            List<string> difference = Text_file1.Except(Text_file2).ToList();
            List<string> difference2 = Text_file2.Except(Text_file1).ToList();
            Difference_Checker D_Check = new Difference_Checker(Text_file1, Text_file2);
            bool Final_Check = D_Check.Checker();
            List<int> Lines_Track = D_Check.Line_Tracking();

            List<string> final = D_Check.comparison();

            foreach (var line in final)
            {
                Console.WriteLine(line);
            }

            
            






            Console.ReadLine();
       
           
        }
       
        //This method is used to check if the files are same or not, then display the output.
        public static void Checking_displaying(bool checker)
        {
            // An if statement to display the message according to the results.
            if (checker == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Text file a and b are not different.", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Text file a and b are different.", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }


        public static string[] Strinarr_file(string[] file1, string[] file2)
        {
            int i = 0;
            List<int> index_return = new List<int>();

            string[] difference = file1.Except(file2).ToArray();
            string[] difference2 = file2.Except(file1).ToArray();

            while (i< file1.Length && i< file2.Length)
            {
                if (file1[i] != file2[i])
                {
                    index_return.Add(i);
                }
                i++;
            }

            return difference2;
       
        }
        

        static List<int> final_output(string[] file1, string[] file2)
        {
            
            List<int> index_return = new List<int>();

            var bothfile = file1.Zip(file2, (x, y) => new { first = x, second = y });

            foreach (var lines in bothfile)
            {
                string[] words1 = lines.first.Split(" ");
                string[] words2 = lines.second.Split(" ");
                int i = 0;
                while (i < words1.Length && i< words2.Length )
                {
                    if (words1[i] != ( words2[i]))
                    {
                        index_return.Add(i);
                    }
                }
            }


            return index_return;
        }

        static int number(string[] file1, string[] file2)
        {
            var bothfile = file1.Zip(file2, (x, y) => new { first = x, second = y });

            int number = file1.Length;

            return number;
        }

        static  string output_colour(string text)
        {
            
                Console.ForegroundColor = ConsoleColor.Red;
                return text;
           
        }

        
        
        
        static void finding_diff(string[] file1, string[] file2)
        {
            // make all of the words into a list and then bring it useing the parameters.

            // follow the path of the jumper
            int index = 0;
            while (index < file1.Length && index<file2.Length)
            {
                

            }

        }






    }
}

