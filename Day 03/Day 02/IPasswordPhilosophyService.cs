using System;
using System.Collections.Generic;
using System.Text;

namespace Day_02
{
    interface IPasswordPhilosophyService
    {
        int CountValidPasswords(string[] file);

        bool ValidatePassword(string[] characterFrequency, char requiredCharacter, string password);

        bool ValidateFrequencyOfCharacter(string[] characterFrequency, char requiredCharacter, string password);

        int CountValidPasswordsNewPolicy(string[] input);
    }
}
