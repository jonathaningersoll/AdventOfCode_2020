using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day_02
{
    class DayTwoInput : IDayTwoInput
    {
        public DayTwoInput()
        {
            Input = File.ReadAllLines(@"./input.txt");
        }

        public string[] Input { get; set; }
    }
}
