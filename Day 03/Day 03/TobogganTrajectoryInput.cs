using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_03
{
    public class TobogganTrajectoryInput : ITobogganTrajectoryInput
    {
        public List<string> Input { get; set; } = File.ReadAllLines(@"./input.txt").Select(l => l).ToList();
    }
}
