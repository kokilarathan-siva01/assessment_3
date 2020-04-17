using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_3
{
    public enum WordOrigin { Removed, Old, New }
    public class Parser
    {

        public List<ParsedWord> Comparer(String value1, String value2)
        {
            List<ParsedWord> final = new List<ParsedWord>();
            List<String> v1 = new List<String>(value1.Split(" "));
            List<String> v2 = new List<String>(value2.Split(" "));

            List<String> tmp = new List<String>();
            String currentWord = String.Empty;
            Int32 ii = 0, tmpIndex = 0;

            for (Int32 i = 0; i < v1.Count; i++)
            {
                tmpIndex = v2.IndexOf(v1[i], ii);

                // This means the word already exists in the same sequence
                if (tmpIndex == ii)
                {
                    final.Add(new ParsedWord(v1[i], WordOrigin.Old));
                    ii++;
                }
                else
                {
                    // This means that we found 2 of the same words next to each other
                    // So lets assume this is where the old text picks up again
                    if (tmpIndex != -1 && v2.IndexOf(v1[i + 1], tmpIndex) == tmpIndex + 1)
                    {
                        // Insert all the words in the second string up to the place
                        // where we found the similar word that was in the original string.
                        for (Int32 x = ii; x < tmpIndex; x++)
                            final.Add(new ParsedWord(v2[x], WordOrigin.New));

                        // This is the first old word we found
                        final.Add(new ParsedWord(v2[tmpIndex], WordOrigin.Old));

                        // Update the new position in the second string
                        ii = tmpIndex + 1;
                    }
                    // This means the word wasn't found and we should remove it
                    else
                        final.Add(new ParsedWord(v1[i], WordOrigin.Removed));

                }
            }

            return final;
        }
    }
    
    public class ParsedWord
    {
        public ParsedWord(String word, WordOrigin origin)
        {
            Word = word;
            Origin = origin;
        }

        public String Word;
        public WordOrigin Origin;
    }
   
}
