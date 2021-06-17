using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day_04
{
    public class Passport
    {

        public Passport(string byr, string iyr, string eyr, string hgt, string hcl, string ecl, string pid, string cid)
        {
            Byr = new PassportElement() { Value = byr, IsValid = ValidateByr(byr)};
            Iyr = new PassportElement() { Value = iyr, IsValid = ValidateIyr(iyr)};
            Eyr = new PassportElement() { Value = eyr, IsValid = ValidateEyr(eyr)};
            Hgt = new PassportElement() { Value = hgt, IsValid = ValidateHgt(hgt)};
            Hcl = new PassportElement() { Value = hcl, IsValid = ValidateHcl(hcl)};
            Ecl = new PassportElement() { Value = ecl, IsValid = ValidateEcl(ecl)};
            Pid = new PassportElement() { Value = pid, IsValid = ValidatePid(pid)};
            Cid = new PassportElement() { Value = cid};
            IsValid = ValidatePassportElements();
        }

        public PassportElement Byr { get; set; }
        public PassportElement Iyr { get; set; }
        public PassportElement Eyr { get; set; }
        public PassportElement Hgt { get; set; }
        public PassportElement Hcl { get; set; }
        public PassportElement Ecl { get; set; }
        public PassportElement Pid { get; set; }
        public PassportElement Cid { get; set; }
        public bool IsValid { get; set; } = false;

        private bool ValidatePassportElements()
        {
            return Byr.IsValid &&
                Iyr.IsValid &&
                Eyr.IsValid &&
                Hgt.IsValid &&
                Hcl.IsValid &&
                Ecl.IsValid &&
                Pid.IsValid;
        }
        private bool ValidateByr(string byr)
        {
            if (byr != null)
            {
                return (Int32.Parse(byr) >= 1920 && Int32.Parse(byr) <= 2002);
            }
                return false;
        }

        private bool ValidateIyr(string iyr)
        {
            if(iyr != null)
            {
                return (Int32.Parse(iyr) >= 2010 && Int32.Parse(iyr) <= 2020);
            }
            return false;
        }

        private bool ValidateEyr(string eyr)
        {
            if (eyr != null)
            {
                return (Int32.Parse(eyr) >= 2020 && Int32.Parse(eyr) <= 2030);
            }
            return false;
        }

        private bool ValidateHgt(string hgt)
        {
            if (hgt != null)
            {
                Regex hgtInRg = new Regex(@"\b([6][0-9]|[5][9]|[7][0-6])[i][n]$");
                Match hgtInMatch = hgtInRg.Match(hgt);
                Regex hgtCmRg = new Regex(@"\b[1]([5-8][0-9]|[9][0-3])[c][m]$");
                Match hgtCmMatch = hgtCmRg.Match(hgt);

                return (hgtInMatch.Success || hgtCmMatch.Success);
            }
            return false;
        }

        private bool ValidateHcl(string hcl)
        {
            if(hcl != null)
            {
                Regex hclRg = new Regex(@"^[#]([a-f]|[0-9]){6}\b");
                Match hclMatch = hclRg.Match(hcl);
                return (hclMatch.Success);
            }
            return false;
        }

        private bool ValidateEcl(string ecl)
        {
            if (ecl != null)
            {
                Regex eclRg = new Regex(@"^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth");
                Match eclMatch = eclRg.Match(ecl);
                return eclMatch.Success;
            }
            return false;
        }

        private bool ValidatePid(string pid)
        {
            if (pid != null)
            {
                Regex pidRg = new Regex(@"\b[0-9]{9}\b");
                Match pidMatch = pidRg.Match(pid);
                return pidMatch.Success;
            }
            return false;
        }

        
    }
}
