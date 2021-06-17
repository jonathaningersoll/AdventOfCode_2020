using System;
using System.Collections.Generic;
using System.Text;

namespace Day_04
{
    interface IPassportProcessingService
    {
        public List<Passport> ValidatePassports(List<string> input);
        public string[] BuildPassport(List<string> rawPassport);
        public bool PassportHasNecessaryElements(Passport p);
        public int ValidatePassportElements(List<Passport> validPassports);
    }
}
