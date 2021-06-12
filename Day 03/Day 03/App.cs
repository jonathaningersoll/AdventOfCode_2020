using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_03
{
    public class App
    {
        private readonly ITobogganTrajectoryService _service;
        private readonly ITobogganTrajectoryInput _input;
        public App(ITobogganTrajectoryService service, ITobogganTrajectoryInput input)
        {
            _input = input;
            _service = service;
        }
        public void RunUI()
        {
            Run();
        }

        private void Run()
        {
            Ui();
        }


        // UI for selecting which part of the puzzle to run
        public void Ui()
        {
            Console.WriteLine("Would you like to calculate how many trees you would hit given a particular trajectory?\n" +
                "1. Yes\n" +
                "2. No");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        bool runProgram = true;
                        while (runProgram)
                        {
                            runProgram = TobogganTrajectory();
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Exiting. Press any key to continue...");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please select option 1 or 2");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
            }
        }


        public bool TobogganTrajectory()
        {
            bool cont = false;
            Console.WriteLine("How far to the right do you need to travel for every line?");
            int rise = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How many lines down would you like to go?");
            int run = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Total trees: {_service.TreeCalculator(_input.Input, rise, run)}.");
            Console.WriteLine("Would you like to run the program again [y/n]?");
            switch (Console.ReadLine())
            {
                case "y":
                    {
                        cont = true;
                        break;
                    }
                case "n":
                    {
                        cont = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter y or n...");
                        break;
                    }
            }
            return cont;
        }










        // OLD CODE:
        public bool TreesPartTwo()
        {
            bool cont = false;
            Console.WriteLine("How far to the right do you need to travel for every line?");
            int run = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How many lines down would you like to go?");
            int rise = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Total trees: {TreeCalculator(rise,run)}.");
            Console.WriteLine("Would you like to run the program again [y/n]?");
            switch (Console.ReadLine())
            {
                case "y":
                    {
                        cont = true;
                        break;
                    }
                case "n":
                    {
                        cont = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter y or n...");
                        break;
                    }
            }
            return cont;
        }


        public bool TreesPartOneOld()
        {
            bool cont = false;
            // read the file into a list
            List<string> input = File.ReadAllLines(@"./input.txt").Select(l => l).ToList();         // Read the file into a list.
            int trees = 0;                                                                          // Set the beginning amount of trees
            int i = 1;                                                                              // Set the iterator at one to skip over the first line, since we already know what is at our origin.
            while (i < input.Count())                                                               // While iterator is less than the amount of rows in the document
            {
                int pos = GetColumn(i,3) - 1;                                                         // Set the x position to i-1 to account for 0-indexing
                                                                                                      // Then multiply that by distance along x(3) (x=y3).

                string line = input[i];                                         // Get the current line as a string

                if (pos < line.Length)                                          // If the position of the line is less than the length of the line
                {                                                               // check the character at line of index pos.
                    if (EvaluateChar(line[pos]))                                 // If it evaluates to true, add 1 to the tree count.
                    {                                                           // If it evaluates to false, just print "Not a tree."
                        trees++;
                    }
                    else { Console.WriteLine("Not a tree."); }
                }
                else
                {
                    if (EvaluateChar(line[GetRemainder(pos, line.Length)]))      // But if the position on the line is greater than the size of the line,
                    {                                                           // take the modulus of pos/line.length and use the remainder since the
                        trees++;                                                // pattern simply repeats. Then add 1 to the tree count.
                    }
                    else { Console.WriteLine("Not a tree"); }
                }
                i++;                                                            // Now move to the next row.
            }
            Console.WriteLine($"Total trees: {trees}.");                        // Display total trees.
            Console.WriteLine("Would you like to run the program again [y/n]?");
            switch (Console.ReadLine())
            {
                case "y":
                    {
                        cont = true;
                        break;
                    }
                case "n":
                    {
                        cont = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter y or n...");
                        break;
                    }
            }
            return cont;
        }


        // Takes two integers, the row number and the distance, and returns the column as an int.
        public int GetColumn(int row, int distance)
        {
            int column = row * distance;
            return column;
        }


        // Takes two ints and returns the modulus of the two.
        public int GetRemainder(int pos, int line)
        {
            return pos % line;
        }


        public bool EvaluateChar(char c)
        {
            return (c == '#');
        }


        // Takes the slope of the hill and returns the amount of trees hit for the given slope.
        public int TreeCalculator(int rise, int run)
        {
            List<string> input = File.ReadAllLines(@"./input.txt").Select(l => l).ToList();
            int trees = 0;

            for (int y = rise; y < input.Count(); y += rise)   // set the iterator to add the amount of the rise
            {
                int x = y * run / rise;
                string line = input[y];
                if (x > line.Length - 1)
                {
                    if (EvaluateChar(line[GetRemainder(x, line.Length)]))
                    {
                        trees++;
                    }
                }
                else
                {
                    if (EvaluateChar(line[x]))
                    {
                        trees++;
                    }
                }
            }
            return trees;
        }
    }
}
