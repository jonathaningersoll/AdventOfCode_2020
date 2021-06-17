using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_04
{
    public class PassportProcessingInput : IPassportProcessingInput
    {
        public List<string> PuzzleInput { get; set; } = File.ReadAllLines(@"./input.txt").Select(n => n).ToList();
    }
}
