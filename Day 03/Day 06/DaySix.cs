using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_06
{
    public class DaySix
    {
        private readonly ICustomCustoms _repo = new CustomCustomsRepository();
        public DaySix(ICustomCustoms repo)
        {
            _repo = repo;
        }
        public void App()
        {
            UI();
        }

        private void UI()
        {
            _repo.BuildGroups();











            List<string> input = File.ReadAllLines(@"./sampleinput.txt").Select(n => n).ToList();
            var answerSum = new List<int>();
            
            var personAnswer = new List<char[]>();
            //var groupAnswers = new List<char>();

            for(int i = 0; i< input.Count(); i++)
            {
                // Check if the line is not null
                if(input[i].Any())
                {
                    // Now, if it's not null, I want to add it to the list of persons' answers.
                    personAnswer.Add(NewArray(input[i]));
                }else // if input[i] is NULL:
                {
                    var groupAnswers = personAnswer[0];
                    // Evaluate the stuff
                    for(int index = 0; i < personAnswer.Count(); index++)
                    {

                        var group = personAnswer[0].Intersect(personAnswer[index]);
                    }
                    //Console.WriteLine(personAnswer[0]);
                    personAnswer.Clear();

                }
            }

            char[] answers = new char[0];

            // What I'm going to do is foreach row, I'm going to make a new array of that row, then set the value
            // of answers to the intersection of the two arrays.

            // For every line in the input...
            //for(int i = 0; i < input.Count(); i++)
            //{
            //    // Check if the line is empty:
            //    if (input[i] != null)
            //    {
            //        // If the line is occupied, AND answers.Length == 0, then it is a new answer group.
            //        if (answers == null)
            //        {
            //            Console.WriteLine("New answer group");
            //            // Now I want to take input[i], run it through "NewArray" and assign it to answers
            //            answers = NewArray(input[i]);
            //        }else if (answers.Any())
            //        {
            //            var intersect = answers.Intersect(NewArray(input[i]));
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("end of message");
            //    }
            //}

            //for (int i = 0; i < input.Count(); i++)
            //{
            //    if (input[i] != null)
            //    {
            //        if(answers.Length < 1)
            //        {
            //            Console.WriteLine("New answer group");
            //            answers = NewArray(input[i]);
            //        } else if(answers.Length > 0)
            //        {
            //            char[] ansList = NewArray(input[i]);
            //            var intersect = answers.Intersect(ansList);
            //            foreach (char res in intersect)
            //            {
            //                Console.WriteLine(res);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        foreach(char res in answers)
            //        {
            //            Console.WriteLine(res);
            //        }
            //        answers = Array.Empty<char>();
            //    }
            //}
        }

        // What I need is a function that takes in a string and spits out an array of chars

        public char[] NewArray(string answer)
        {
            char[] answerList = new char[answer.Length];
            for (int i = 0; i < answer.Length; i++)
            {
                answerList[i] = answer[i];
            }

            return answerList;
        }
    }
}
