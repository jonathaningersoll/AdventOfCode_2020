using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_03
{
    public class TobogganTrajectoryService : ITobogganTrajectoryService
    {
        public int TreeCalculator(List<string> file, int rise, int run)
        {
            var input = file;
            int trees = 0;

            for (int y = run; y < input.Count(); y += run)
            {

                // A positively-sloped line is defined as y=mx+b where
                // m is the slope and b is the y-intercept. Our m (slope) is
                // defined as the rise, or how much the amount of y changes in 
                // a positive direction (the y delta), divided by how much the 
                // amount of x changes in a positive direction (the x delta).
                // We are given the rise and the run which provides us the slope:
                // rise/run

                // But not everything is as it seems. At first glance, you would
                // think the y axis is the puzzle up/down, but if you plot it out, 
                // the y-axis is actually how far to the right you have to travel.

                int x = y * rise / run;
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
