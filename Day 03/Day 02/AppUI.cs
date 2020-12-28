using System;
using System.Collections.Generic;
using System.Text;

namespace Day_02
{
    class AppUI
    {
        public void Run()
        {
            ConsoleInterface();
        }

        private void ConsoleInterface()
        {
            string[] inputLines = File.ReadAllLines(@"./input.txt");
            int validPasswords = 0;
            // each inputLines[n] is a phrase
            // foreach phrase, split at ' ' and put it in its own array


            // This foreach iterates through each line in the file. It leverages
            //      the GetParams(), GetRequiredCharacter(), and GetPassPhrase() methods
            //      in order to separate the necessary values into their own variables.
            foreach (string line in inputLines)
            {
                string[] phrase = line.Split(' ');
                // Now I have an array of one of the lines in the file.
                // at phrase[0] is the requirements.
                // at phrase[1] is the required character
                // at phrase[2] is the actual password.

                // Split the phrase into three sections: Requirements(reqs),
                //  Required Character(reqChar), and the Password (pass)

                int[] reqs = GetParams(phrase[0].Split('-')); //DONE

                char reqChar = GetRequiredCharacter(phrase[1]); // DONE

                string pass = GetPassPhrase(phrase[2]); // DONE

                // So now I have three variables: reqs, an int array; reqChar, a char; and pass, a string.
                //  Now I must validate each line.

                if (Validate(reqs, reqChar, pass))
                {
                    validPasswords++;
                }
                else
                {
                    Console.WriteLine("Invalid pw");
                }
                Console.WriteLine(validPasswords);
            }
            Console.ReadKey();
        }

        public int[] GetParams(string[] phrase)
        {
            return new int[] {
                Int32.Parse(phrase[0]),
                Int32.Parse(phrase[1])
                    };
        }

        public char GetRequiredCharacter(string reqCharCol)
        {
            return reqCharCol[0];
        }

        public string GetPassPhrase(string phrase)
        {
            return phrase;
        }

        public bool Validate(int[] reqs, char c, string pass)
        {

            if (!pass.Contains(c))
            {
                Console.WriteLine("Error! Password does not contain the required character!");
                return false;
            }
            else
            {
                return WithinParams(reqs, numMatchingChars(c, pass));
            }
        }

        public int numMatchingChars(char c, string pass)
        {
            // For each character in pass, evaluate whether it equates to c or not.
            // if it does, add a number to the list.
            // Count the length of the list.
            List<char> matchedChars = new List<char>();
            foreach (char n in pass)
            {
                if (n == c)
                {
                    matchedChars.Add(n);
                }
                else
                {
                    Console.WriteLine("Error! No character in pw meets the char criteria!");
                }
            }
            return matchedChars.Count;
        }

        public bool WithinParams(int[] reqs, int length)
        {
            if (length >= reqs[0] && length <= reqs[1])
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error! These characters are not within parameters!");
                return false;
            }
        }
    }
}
