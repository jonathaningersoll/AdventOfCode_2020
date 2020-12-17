using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_03
{
    public class App
    {
        public void RunUI()
        {
            Run();
        }

        private void Run()
        {
            // read the file into a list
            List<string> input = File.ReadAllLines(@"./input.txt").Select(l => l).ToList();         // Read the file into a list.
            int trees = 0;                                                                          // Set the beginning amount of trees
            int i = 1;                                                                              // Set the iterator at one to skip over the first line, since we already know what is at our origin.
            while (i < input.Count())                                                               // While iterator is less than the amount of rows in the document
            {
                int pos = XCoordinate(i)-1;                                                         // Set the x position to i-1 to account for 0-indexing
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
                    if(EvaluateChar(line[GetRemainder(pos, line.Length)]))      // But if the position on the line is greater than the size of the line,
                    {                                                           // take the modulus of pos/line.length and use the remainder since the
                        trees++;                                                // pattern simply repeats. Then add 1 to the tree count.
                    }
                    else { Console.WriteLine("Not a tree"); }
                }
                i++;                                                            // Now move to the next row.
            }
            Console.WriteLine($"Total trees: {trees}.");                        // Display total trees.
            Console.ReadKey();                                                  // Await user input
        }

        public int XCoordinate(int row)
        {
            return row * 3 + 1;
        }

        public int GetRemainder(int pos, int line)
        {
            return pos % line;
        }

        public char GetCharacter(string position)
        {
            {
                Console.WriteLine(position);
                return char.Parse(position);
            }
        }

        public bool EvaluateChar(char c)
        {
            return (c == '#');
        }
    }
}
