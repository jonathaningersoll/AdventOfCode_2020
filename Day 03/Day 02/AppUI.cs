using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_02
{
    class AppUI
    {
        private readonly IPasswordPhilosophyService _service;
        private readonly IDayTwoInput _input;

        public AppUI(IPasswordPhilosophyService service, IDayTwoInput input)
        {
            _input = input;
            _service = service;
        }
        public void Run()
        {
            ConsoleInterface();
        }

        private void ConsoleInterface()
        {
            Console.WriteLine("Please select the puzzle part you wish to complete: \n" +
                "1. Part 1\n" +
                "2. Part 2\n" +
                "3. Exit");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    {
                        PasswordPhilosophyPartOne();
                        break;
                    }
                case "2":
                    {
                        PasswordPhilosophyPartTwo();
                        break;
                    }
            }
        }

        public void PasswordPhilosophyPartOne()
        {
            Console.WriteLine(_service.CountValidPasswords(_input.Input));
        }


        public void PasswordPhilosophyPartTwo()
        {
            Console.WriteLine(_service.CountValidPasswordsNewPolicy(_input.Input));
        }





//  --- Day 2: Password Philosophy ---

//  For example, suppose you have the following list:
//          1-3 a: abcde
//          1-3 b: cdefg
//          2-9 c: ccccccccc
//  Each line gives the password policy and then the password.The password policy indicates
//      the lowest and highest number of times a given letter must appear for the password to be valid.
//      For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.

//  In the above example, 2 passwords are valid.The middle password, cdefg, is not; it contains no
//  instances of b, but needs at least 1. The first and third passwords are valid: they contain one a
//  or nine c, both within the limits of their respective policies.

//  How many passwords are valid according to their policies?

//  Your puzzle answer was 591.

//--- Part Two ---
//  While it appears you validated the passwords correctly, they don't seem to be what the Official Toboggan Corporate Authentication System is expecting.
//  The shopkeeper suddenly realizes that he just accidentally explained the password policy rules from his old job at the sled rental place down the street! The Official Toboggan Corporate Policy actually works a little differently.
//  Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter.Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
//  Given the same example list from above:
//          1-3 a: abcde is valid: position 1 contains a and position 3 does not.
//          1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
//          2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.
//  How many passwords are valid according to the new interpretation of the policies?


        //Old Code:
        //private void ConsoleInterface()
        //{
        //    // Read all the lines of the input file into a string array:
        //    string[] inputLines = File.ReadAllLines(@"./input.txt");

        //    // Set a variable to keep track of all valid passwords.
        //    int validPasswords = 0;

        //    // This foreach iterates through each line in the file and separates
        //    //  the necessary values into their own variables.
        //    foreach (string line in inputLines)
        //    {
        //        // Split each line at each space
        //        string[] phrase = line.Split(' ');
        //        // Now I have an array of one of the lines in the file.
        //        // At phrase[0] is the requirements (1-3).
        //        // At phrase[1] is the required character (a).
        //        // At phrase[2] is the actual password (abcde).

        //        // Split the phrase into three sections: Requirements(reqs), Required Character(reqChar), and the Password (pass)

        //        int[] reqs = GetParams(phrase[0].Split('-')); //DONE
        //        char reqChar = phrase[1][0]; // DONE
        //        string pass = phrase[2].ToString(); // DONE

        //        // So now I have three variables: reqs, an int array; reqChar, a char; and pass, a string.
        //        // Now I must validate each line.

        //        if (Validate(reqs, reqChar, pass))
        //        {
        //            validPasswords++;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid pw");
        //        }
        //        Console.WriteLine(validPasswords);
        //    }
        //    Console.ReadKey();
        //}


        // Takes a string array and outputs an int array.
        // The purpose of this method is to build an array of numbers.
        // The number at GetParams()[0] is the minimum amount of times a given character must be present in the password.
        // The number at GetParams()[1] is the maximum amount of times a given character must be present in the password.
        public int[] GetParams(string[] phrase)
        {
            return new int[] {
                Int32.Parse(phrase[0]),
                Int32.Parse(phrase[1])
                    };
        }


        // Validate() takes
        // - the min/max times a character must be present in a password,
        // - the character that needs to be present,
        // - the actual password
        // and returns true if the password is valid, false if invalid.
        public bool Validate(int[] reqs, char c, string pass)
        {

            // Does the password actually contain the required character? If not, return false, if so, evaluate if the
            // password is still within required parameters using the WithinParams() method.
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


        // This method takes a char and a string and returns the number of times the char
        // appears within the string.
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


        // This method takes two parameters:
        //      (1) int[] reqs holds the min/max times a character can appear in a password
        //      (2) int length holds holds the amount of times a character actually appears in a password
        // and returns true if the amount of times a character appears in a password is within the reqs min/max.
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
