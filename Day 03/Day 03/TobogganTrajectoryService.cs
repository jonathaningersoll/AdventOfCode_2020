using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_03
{
    public class TobogganTrajectoryService
    {
        public int TreeCalculator(int rise, int run)
        {
            List<string> input = File.ReadAllLines(@"./input.txt").Select(l => l).ToList();
            int trees = 0;

            for (int y = rise; y < input.Count(); y += rise)
            {
                int x = y * run / rise;
                string line = input[y];
                if (x > line.Length - 1)
                {
                    if (line[x % line.Length] == '#')
                    {
                        trees++;
                    }
                }
                else
                {
                    if (line[x] == '#')
                    {
                        trees++;
                    }
                }
            }
            return trees;
        }
    }
}
