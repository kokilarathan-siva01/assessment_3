using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assessment_3
{
    class Difference_Checker
    {
        // This class will manually check the difference between two given files.

        public bool Different_Not = true; // creating variables to store boolean.
        public string[] first_file;
        public string[] second_file;
        public List<int> Line_Track = new List<int>();
        public string one_string_1;
        public string one_string_2;
        public List<string> SingleString_1=new List<string>();
        public List<string> SingleString_2 = new List<string>();
        

        public int x { get; set; }
        public int k { get; set; }
        public int temp { get; set; }
        public  Difference_Checker(string[] File_1, string[] File_2) // objects for retriving the files from the main program.
        {
            first_file = File_1;
            second_file = File_2;
            


        }

        // method to check for differences.
        public bool Checker()
        {

            if (first_file.Length == second_file.Length)
            {
                int i = 0;
                //as long as the files are comparing the same and the index is within the length of file a
                while (i < first_file.Length && i < second_file.Length)
                {
                    if (first_file[i] != second_file[i])
                    {
                        return Different_Not = true;
                    }
                    else
                    {
                        //if the element at the current index is not the same, it is not the same file
                         Different_Not = false;
                    }

                    i++;
                }
            }
            else
            {
                return Different_Not = false;
            }

            // Returns the final boolean value for validation in the main program.
            return Different_Not;
        }

        // This method will return the line number which are not the same.
        public List<int> Line_Tracking()
        {
            int i = 0;

            while (i < first_file.Length && i < second_file.Length)
            {

                if (first_file[i] != second_file[i])
                {
                    Line_Track.Add(i);
                }

                i++;


            }
            return Line_Track;
        }

        public List<string> comparison()
        {
            
            List<string> final = new List<string>();
            int i = 0;
            while (i < first_file.Length && i < second_file.Length)
            {
                List<string> words = first_file[i].Split(" ").ToList();
                List<string> words2 = second_file[i].Split(" ").ToList();
                for (int p = 0; p < words.Count; p++)
                {
                    if (words[p] != words2[p])
                    {
                        final.Add(words[p]);
                        //Jumper(words, words2);


                    }
                }
                i++;
            }
            return final;
        }


        public void Jumper(List<string> file1, List<string> file2)
        {
           
            bool found = false;
            temp = x;

            while (temp < file1.Count && found == false)
            {
                if (file1[temp] == file2[k])
                {
                    found = true;
                    x = temp;
                }
                else if (file1[temp] == file2[k + 1])
                {
                    found = true;
                    x = temp;

                    k += 1;
                }
                temp++;

            }
            temp = k;
            while (temp < file2.Count && found == false)
            {
                if (file2[temp] == file1[x])
                {
                    found = true;
                    k = temp;
                }
                else if (file2[temp] == file1[x + 1])
                {
                    found = true;
                    k = temp;

                    x = x + 1;
                }
                temp++;
            }
        }



    }
}
