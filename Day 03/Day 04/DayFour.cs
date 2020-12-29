using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day_04
{
    public class DayFour
    {
        public void App()
        {
            UI();
        }
        private void UI()
        {
            List<string> input = File.ReadAllLines(@"./input.txt").Select(n => n).ToList();


            // read through each line.
            // add each line to an array.
            // once you hit a null line, operate on the array, then delete everything from input and start over.

            // read input[i]
            //  > evaluate if it is < : if it is, submit the items in the array

            var validPassports = 0;
            var fields = new List<string>();

            for (int i=0; i < input.Count(); i++)
            {
                if (input[i].Length < 1)
                {

                    var passport = new Dictionary<string, string>();

                    foreach (string item in fields)
                    {
                        passport.Add(item.Split(':')[0], item.Split(':')[1]);
                    }

                    if (ValidPassportFieldsAndContent(passport))
                    {
                        Console.WriteLine("Valid passport");
                        validPassports++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid passport");
                    }

                    // Part One:
                    //var passportProperties = new List<string>();
                    //foreach (string item in fields)
                    //{
                    //    passportProperties.Add(item.Split(':')[0]);
                    //}

                    //if (IsValidPassport(passportProperties))
                    //{
                    //    Console.WriteLine("Valid passport");
                    //    validPassports++;
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Invalid passport!");
                    //}

                    // dump list
                    fields.Clear();
                }
                else
                {
                    List<string> builtPassport = input[i].Split(' ').ToList();
                    builtPassport.ForEach(x => fields.Add(x));
                }
                
            }

            Console.WriteLine("\n" +
                "****************\n" +
                "Valid passports: " + validPassports + "\n" +
                "****************");
        }

        //pass the fields list to ValidPassportContent since it is a potential valid passport.
        public bool ValidPassportFieldsAndContent(Dictionary<string, string> passport)
        {

            bool validContent;

            // First, validate it.
            if (IsValidPassport(passport))
            {
                bool byr = false;
                bool iyr = false;
                bool eyr = false;
                bool hgt = false;
                bool hcl = false;
                bool ecl = false;
                bool pid = false;

                // Then, for each item in passport,
                foreach (KeyValuePair<string, string> item in passport)
                {
                    switch (item.Key)
                    {
                        case "byr":
                            {
                                byr = ValidateByr(Int32.Parse(item.Value));
                                
                                break;
                            }
                        case "iyr":
                            {
                                iyr = ValidateIyr(Int32.Parse(item.Value));
                                
                                break;
                            }
                        case "eyr":
                            {
                                eyr = ValidateEyr(Int32.Parse(item.Value));
                                
                                break;
                            }
                        case "hgt":
                            {
                                hgt = ValidateHgt(item.Value);
                                
                                break;
                            }
                        case "hcl":
                            {
                                hcl = ValidateHcl(item.Value);
                                
                                break;
                            }
                        case "ecl":
                            {
                                ecl = ValidateEcl(item.Value);

                                break;
                            }
                        case "pid":
                            {
                                pid = ValidatePid(item.Value);

                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }

                if (byr && iyr && eyr && eyr && hgt && hcl && ecl && pid)
                {
                    validContent = true;
                }
                else
                {
                    validContent = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid passport");
                validContent = false;
            }

            return validContent;
        }

        public bool IsValidPassport(Dictionary<string, string> passport)
        {
            if (
                passport.ContainsKey("byr")
                && passport.ContainsKey("iyr")
                && passport.ContainsKey("eyr")
                && passport.ContainsKey("hgt")
                && passport.ContainsKey("hcl")
                && passport.ContainsKey("ecl")
                && passport.ContainsKey("pid")
                )
            {
                return true;
            }
            return false;
        }
        public bool ValidateByr(int byr)
        {
            if (byr >= 1920 && byr <= 2002)
            {
                return true;
            }
            else { return false; }
        }
        public bool ValidateIyr(int iyr)
        {
            if (iyr >= 2010 && iyr <= 2020)
            {
                return true;
            }
            else { return false; }
        }
        public bool ValidateEyr(int eyr)
        {
            if (eyr >= 2020 && eyr <= 2030)
            {
                return true;
            }
            else { return false; }
        }
        public bool ValidateHgt(string hgt)
        {
            // New regex:
            Regex hgtInRg = new Regex(@"\b([6][0-9]|[5][9]|[7][0-6])[i][n]$");
            Match hgtInMatch = hgtInRg.Match(hgt);

            Regex hgtCmRg = new Regex(@"\b[1]([5-8][0-9]|[9][0-3])[c][m]$");
            Match hgtCmMatch = hgtCmRg.Match(hgt);

            if (hgtInMatch.Success || hgtCmMatch.Success) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateHcl(string hcl)
        {
            Regex hclRg = new Regex(@"^[#]([a-f]|[0-9]){6}\b");
            Match hclMatch = hclRg.Match(hcl);

            if (hclMatch.Success)
            {
                return true;
            }
            else { return false; }
        }
        public bool ValidateEcl(string ecl)
        {
            Regex eclRg = new Regex(@"^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth");
            Match eclMatch = eclRg.Match(ecl);

            if (eclMatch.Success)
            {
                return true;
            }
            else { return false; }
        }
        public bool ValidatePid(string pid)
        {
            Regex pidRg = new Regex(@"\b[0-9]{9}\b");
            Match pidMatch = pidRg.Match(pid);

            if (pidMatch.Success)
            {
                return true;
            }
            else { return false; }
        }
    }
}
