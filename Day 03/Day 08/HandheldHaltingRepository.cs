using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_08
{
    public class HandheldHaltingRepository
    {
        public List<Instruction> CleanInstructions { get; set; } = Load();

        public static List<Instruction> Load()
        {
            return File.ReadAllLines(@"./input.txt").Select(n => CleanInstruction(n)).ToList();
        }

        public static Instruction CleanInstruction(string x)
        {
            string instruction = $"{x[0]}" + $"{x[1]}" + $"{x[2]}";
            var ins = new Instruction();
            switch (instruction)
            {
                case "acc":
                    {
                        ins.Ins = InstructionName.acc;
                        break;
                    }
                case "jmp":
                    {
                        ins.Ins = InstructionName.jmp;
                        break;
                    }
                case "nop":
                    {
                        ins.Ins = InstructionName.nop;
                        break;
                    }
            }

            if (x[4] == '+')
            {
                ins.Operator = true;
            }
            else
            {
                ins.Operator = false;
            }

            ins.Amount = Int32.Parse(x.Remove(0, 5));

            return ins;
        }

    }
}
