using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_06
{
    public class CustomCustomsService
    {
        List<string> input = File.ReadAllLines(@"./sampleinput.txt").Select(n => n).ToList();

        public List<Group> x = new List<Group>();
    }
}
