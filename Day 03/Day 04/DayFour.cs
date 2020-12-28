using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                    var passportProperties = new List<string>();
                    foreach (string item in fields)
                    {
                        passportProperties.Add(item.Split(':')[0]);
                    }

                    if (IsValidPassport(passportProperties))
                    {
                        Console.WriteLine("Valid passport");
                        validPassports++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid passport!");
                    }

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

        public bool IsValidPassport(List<string> passport)
        {
            if (
                passport.Contains("byr")
                && passport.Contains("iyr")
                && passport.Contains("eyr")
                && passport.Contains("hgt")
                && passport.Contains("hcl")
                && passport.Contains("ecl")
                && passport.Contains("pid")
                )
            {
                return true;
            }
            return false;
        }

    }

    public class Passport
    {
        int byr;
        int iyr;
        int eyr;
        string hgt;
        string hcl;
        string ecl;
        int pid;

    }

}
