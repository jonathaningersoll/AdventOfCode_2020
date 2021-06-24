using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_06
{
    public class CustomCustomsRepository : ICustomCustoms
    {
        public int BuildGroups()
            {
            List<string> input = File.ReadAllLines(@"./input.txt").Select(n => n).ToList();

            List<char> answers = new List<char>();
            
            int finalAnswerCount = 0;

            // Loop through the entire list of strings
            for(int i = 0; i < input.Count(); i++)
            {
                // Check if the app should continue adding to the group
                if (input[i].Length > 0)
                {
                    foreach(char c in input[i])
                    {
                        // If the group.Answers doesn't already contain the character, add it to the list of answers.
                        if (!answers.Contains(c))
                        {
                            answers.Add(c);
                        }
                    }
                }
                else
                {
                    ReportGroup(answers);
                    Console.WriteLine();
                    finalAnswerCount += answers.Count();
                    Console.WriteLine("Current count: " + finalAnswerCount);
                    answers.Clear();
                }
            }
            
            return finalAnswerCount;
        }

        // Create group based on grouped list items

        public void ReportGroup(List<char> answers)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Unique Characters:");
            answers.ForEach(x => Console.Write(x));
            Console.WriteLine();
            Console.WriteLine("Total unique characters:");
            Console.WriteLine(answers.Count());
        }
    }
}
