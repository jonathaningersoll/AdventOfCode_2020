using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_08
{
    public class Instruction
    {
        public InstructionName Ins { get; set; }
        public bool Operator { get; set; }
        public int Amount { get; set; }
        public bool HasBeenRun { get; set; }
        public bool HasBeenFlipped { get; set; }
    }
}
