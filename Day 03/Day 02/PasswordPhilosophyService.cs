using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Day_02
{
    class PasswordPhilosophyService : IPasswordPhilosophyService
    {
        public int CountValidPasswords(string[] input)
        {
            int validPasswords = 0;

            foreach (string line in input)
            {
                string[] phrase = line.Split(' ');

                string[] characterFrequency = phrase[0].Split('-');
                char requiredCharacter = phrase[1][0];
                string password = phrase[2].ToString();

                if (password.Contains(requiredCharacter)){
                    if(ValidatePassword(characterFrequency, requiredCharacter, password))
                    {
                        validPasswords++;
                    }
                }
            }
            return validPasswords;
        }



        public bool ValidatePassword(string[] characterFrequency, char requiredCharacter, string password)
        {
            if(!ValidateFrequencyOfCharacter(characterFrequency, requiredCharacter, password))
            {
                return false;
            }
            return true;
        }



        public bool ValidateFrequencyOfCharacter(string[] characterFrequency, char requiredCharacter, string password)
        {
            var matchedChars = new List<char>();
            foreach(char c in password)
            {
                if(c == requiredCharacter)
                {
                    matchedChars.Add(requiredCharacter);
                }
            }
            if(!(matchedChars.Count >= Int32.Parse(characterFrequency[0]) && matchedChars.Count <= Int32.Parse(characterFrequency[1])))
            {
                return false;
            }
            return true;
        }



        public int CountValidPasswordsNewPolicy(string[] input)
        {
            int validPasswords = 0;

            foreach (string line in input)
            {
                string[] phrase = line.Split(' ');

                string[] charLocations = phrase[0].Split('-');
                char requiredCharacter = phrase[1][0];
                string password = phrase[2];             // 3) Get the password

                if (!(password[Int32.Parse(charLocations[0]) - 1] == requiredCharacter && password[Int32.Parse(charLocations[1]) - 1] == requiredCharacter))
                {
                    if (password[Int32.Parse(charLocations[0]) - 1] == requiredCharacter || password[Int32.Parse(charLocations[1]) - 1] == requiredCharacter)
                    {
                        validPasswords++;
                    }
                }
            }
            return validPasswords;
        }
    }
}
