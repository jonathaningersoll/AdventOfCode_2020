using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_06
{
    public class CustomCustomsRepository : ICustomCustoms
    {

        public List<Group> Groups { get; set; } = new List<Group>();
        public List<IndividualAnswers> Answers { get; set; } = new List<IndividualAnswers>();


        public List<List<char>> GroupAnswers { get; set; } = new List<List<char>>();
        public List<char> IndividualAnswers { get; set; } = new List<char>();
        public int Number { get; set; }

        public int BuildGroups()
            {
            List<string> input = File.ReadAllLines(@"./input.txt").Select(n => n).ToList();

            List<char> answers = new List<char>();
            List<List<char>> groupList = new List<List<char>>();
            
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




        public void ReportGroup(List<char> answers)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Unique Characters:");
            answers.ForEach(x => Console.Write(x));
            Console.WriteLine();
            Console.WriteLine("Total unique characters:");
            Console.WriteLine(answers.Count());
        }



        public int DidEveryoneAnswerAnyQuestion()
        {
            List<string> input = File.ReadAllLines(@"./input.txt").Select(n => n).ToList();


            for(int i = 0; i < input.Count(); i++)
            {
                if (input[i].Length > 0)                            // Builds the GroupAnswers property for each line
                {
                    foreach (char c in input[i])
                    {
                        IndividualAnswers.Add(c);
                    }
                    GroupAnswers.Add(IndividualAnswers.ToList());
                    IndividualAnswers.Clear();
                }
                else
                {
                    Number += EvaluateGroup(GroupAnswers);
                    GroupAnswers.Clear();
                }
            }
            return Number;
        }

        public int EvaluateGroup(List<List<char>> group)
        {
            int trueCounter = 0;
            var topGroup = group[0];
            group.RemoveAt(0);
            foreach (char c in topGroup)
            {
                if(EvaluateCharacter(group, c))
                {
                    trueCounter++;
                }
            }
            return trueCounter;
        }


        public bool EvaluateCharacter(List<List<char>> group, char c)
        {
            List<bool> allContainsTheCharacter = new List<bool>();
            foreach(List<char> person in group)
            {
                if (person.Contains(c))
                {
                    allContainsTheCharacter.Add(true);
                }
                else
                {
                    allContainsTheCharacter.Add(false);
                }
            }

            if (allContainsTheCharacter.Contains(false)){
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
