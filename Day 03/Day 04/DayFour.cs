using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_04
{
    public class DayFour
    {
        private readonly IPassportProcessingService _service;
        private readonly IPassportProcessingInput _input;
        public List<Passport> ValidPassports { get; set; }
        public bool uiContinue { get; set; } = true;

        private DayFour(IPassportProcessingService service, IPassportProcessingInput input)
        {
            _service = service;
            _input = input;
        }

        public static DayFour FactoryMethod()
        {
            return new DayFour(new PassportProcessingService(), new PassportProcessingInput());
        }

        public void App()
        {
            while (uiContinue)
            {
                uiContinue = UI();
            }
        }
        private bool UI()
        {
            ValidPassports = _service.ValidatePassports(_input.PuzzleInput);
            Console.Clear();
            Console.WriteLine("Select an option: \n" +
                "1. Report valid passports\n" +
                "2. Validate all passports and their elements\n" +
                "3. Exit program");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Valid passports: " + ValidPassports.Count());
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        Console.WriteLine("Passports with valid elements: " + _service.ValidatePassportElements(ValidPassports));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case "3":
                    {
                        return false;
                    }
            }
            return true;
        }
    }
}
