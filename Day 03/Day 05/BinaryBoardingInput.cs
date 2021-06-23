using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_05
{
    public class BinaryBoardingInput
    {
        public List<string> Input { get; set; } = File.ReadAllLines(@"./input.txt").Select(n => n).ToList();
    }
}
