using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_04
{
    public class PassportProcessingService : IPassportProcessingService
    {
        public List<Passport> ValidatePassports(List<string> input)
        {
            var passportElementList = input;

            var validPassports = new List<Passport>();
            var unlabelledPassportElements = new List<string>();

            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i].Length < 1)
                {
                    var organizedPassport = BuildPassport(unlabelledPassportElements);
                    Passport passport = new Passport(
                        organizedPassport[0],
                        organizedPassport[1],
                        organizedPassport[2],
                        organizedPassport[3],
                        organizedPassport[4],
                        organizedPassport[5],
                        organizedPassport[6],
                        organizedPassport[7]);

                    if (PassportHasNecessaryElements(passport))
                    {
                        validPassports.Add(passport);
                    }
                    unlabelledPassportElements.Clear();
                }
                else
                {
                    List<string> prePassport = input[i].Split(' ').ToList();
                    prePassport.ForEach(x => unlabelledPassportElements.Add(x));
                }
            }
            
            return validPassports;
        }

        public string[] BuildPassport(List<string> rawPassport)
        {
            string[] passportList = new string[8];

            foreach (string line in rawPassport)
            {
                switch (line.Split(":")[0])
                {
                    case "byr":
                        {
                            passportList[0] = line.Split(":")[1];
                            break;
                        }
                    case "iyr":
                        {
                            passportList[1] = line.Split(":")[1];
                            break;
                        }
                    case "eyr":
                        {
                            passportList[2] = line.Split(":")[1];
                            break;
                        }
                    case "hgt":
                        {
                            passportList[3] = line.Split(":")[1];
                            break;
                        }
                    case "hcl":
                        {
                            passportList[4] = line.Split(":")[1];
                            break;
                        }
                    case "ecl":
                        {
                            passportList[5] = line.Split(":")[1];
                            break;
                        }
                    case "pid":
                        {
                            passportList[6] = line.Split(":")[1];
                            break;
                        }
                    case "cid":
                        {
                            passportList[7] = line.Split(":")[1];
                            break;
                        }
                }
            }
            return passportList;
        }

        public bool PassportHasNecessaryElements(Passport p)
        {
            return (
                p.Byr.Value != null &&
                p.Iyr.Value != null &&
                p.Eyr.Value != null &&
                p.Hgt.Value != null &&
                p.Hcl.Value != null &&
                p.Ecl.Value != null &&
                p.Pid.Value != null
                );
        }

        public int ValidatePassportElements(List<Passport> validPassports)
        {
            return validPassports.FindAll(p => p.IsValid.Equals(true)).Count();
        }
    }
}
