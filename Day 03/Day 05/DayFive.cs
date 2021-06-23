using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_05
{
    class DayFive
    {
        private readonly BinaryBoardingService _service;
        private readonly BinaryBoardingInput _input;
        private List<BoardingPass> BoardingPasses;
        // private readonly BinaryBoardingService _service;

        public bool ContinueRunning { get; set; } = true;
        //public DayFive(BinaryBoardingService service)
        //{
        //    _service = service;
        //}

        public DayFive()
        {
            _input = new BinaryBoardingInput();
            _service = new BinaryBoardingService();
        }

        public void App()
        {
            while (ContinueRunning)
            {
                UI();
            }
        }
        
        private void UI()
        {
            Console.WriteLine("Please select an option: \n" +
                "1. Determine the highest seat ID on all the boarding passes?\n" +
                "2. What's is the ID of your seat?\n" +
                "3. Load Passports\n" +
                "4. Delete Passports\n" +
                "5. View Passport Count\n" +
                "6. Exit");
            switch (Console.ReadLine())
            {
                case "1": // GET Highest Boarding Pass Seat ID
                    {
                        Console.Clear();
                        if (BoardingPasses != null)
                        {
                            BoardingPasses = _service.GetBoardingPasses();
                            Console.WriteLine(_service.GetHighestSeatId(BoardingPasses));
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Boarding Pass list is empty");
                            Console.ReadKey();
                            break;
                        }
                    }
                case "2": // GET missing seat ID
                    {
                        Console.Clear();
                        if(BoardingPasses != null)
                        {
                            Console.WriteLine(_service.GetMissingSeatId(BoardingPasses));
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No boarding passes have been created!");
                        }
                        Console.ReadKey();
                        break;
                    }
                case "3": // CREATE Boarding Pass List
                    {
                        if (_service.CreateBoardingPasses(_input.Input))
                        {
                            Console.Clear();
                            BoardingPasses = _service.GetBoardingPasses();
                            Console.WriteLine("Boarding pass list created!");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error loading boarding passes");
                            Console.ReadKey();
                            break;
                        }
                    }
                case "4": // DELETE Boarding Passes
                    {
                        if (_service.DeleteBoardingPasses())
                        {
                            Console.Clear();
                            Console.WriteLine("Boarding pass list deleted!");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error deleting boarding passes");
                            Console.ReadKey();
                            break;
                        }
                    }
                case "5": // GET Boarding Pass Count
                    {
                        if(BoardingPasses != null)
                        {
                            Console.WriteLine(BoardingPasses.Count());
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Boarding pass list is empty!");
                            break;
                        }
                    }
                case "6":
                    {
                        ContinueRunning = false;
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Please select a valid option");
                        break;
                    }
            }
        }
    }
}
