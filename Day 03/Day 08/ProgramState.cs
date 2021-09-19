using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_08
{
    public class ProgramState
    {
        public ProgramState()
        {
            Accumulator = 0;
            CurrentInstruction = null;
            NextInstruction = 0;
        }

        public int Accumulator { get; set; }
        public Instruction CurrentInstruction { get; set; }
        public int NextInstruction { get; set; } = 0;
    }
}
