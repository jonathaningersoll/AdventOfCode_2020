using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Day_08
{
    public enum InstructionName { jmp, acc, nop }

    public class HandheldHalting
    {
        public HandheldHalting(HandheldHaltingRepository repo, ProgramState state)
        {
            _repo = repo;
            _state = state;
        }
        private HandheldHaltingRepository _repo;
        private ProgramState _state;




        public void Run()
        {
            Ui();
        }
        private void Ui()
        {
            Console.WriteLine("Welcome to Handheld Halting.\n" +
                "Which part would you like to run?\n" +
                "1. Handheld Halting pt. One\n" +
                "2. Handheld Halting pt. Two");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    {
                        HandheldHaltingPartOne();
                        break;
                    }
                case "2":
                    {
                        X();
                        break;
                    }
            }
        }
        private void HandheldHaltingPartOne()
        {
            // Execute the instructions
            bool runProgram = true;
            while (runProgram)
            {
                _state.CurrentInstruction = _repo.CleanInstructions[_state.NextInstruction];
                if (!_state.CurrentInstruction.HasBeenRun)
                {
                    int indexOrigin = _repo.CleanInstructions.IndexOf(_state.CurrentInstruction);
                    //Check the instruction
                    switch (_state.CurrentInstruction.Ins.ToString())
                    {
                        case "acc":
                            {
                                if (_state.CurrentInstruction.Operator)
                                {
                                    _state.Accumulator += _state.CurrentInstruction.Amount;
                                }
                                else
                                {
                                    _state.Accumulator -= _state.CurrentInstruction.Amount;
                                }
                                // Toggle the HasBeenRun boolean
                                _repo.CleanInstructions[indexOrigin].HasBeenRun = true;
                                _state.NextInstruction++;
                                break;
                            }
                        case "jmp":
                            {
                                if (_state.CurrentInstruction.Operator)
                                {
                                    _state.NextInstruction += _state.CurrentInstruction.Amount;
                                }
                                else
                                {
                                    _state.NextInstruction -= _state.CurrentInstruction.Amount;
                                }
                                _repo.CleanInstructions[indexOrigin].HasBeenRun = true;
                                break;
                            }
                        case "nop":
                            {
                                _repo.CleanInstructions[indexOrigin].HasBeenRun = true;
                                _state.NextInstruction++;
                                break;
                            }
                    }
                }
                else
                {
                    runProgram = false;
                }
            }
            Console.Clear();
            Console.WriteLine(_state.Accumulator);
            Console.ReadLine();
        }




        private void HandheldHaltingPartTwo(int index, Instruction x)
        {
            StateReset(_repo.CleanInstructions[0]);
            List<Instruction> instructionList = new List<Instruction>();
            instructionList = _repo.CleanInstructions.Select(y => new Instruction()
            {
                Amount = y.Amount,
                HasBeenFlipped = y.HasBeenFlipped,
                HasBeenRun = y.HasBeenRun,
                Ins = y.Ins,
                Operator = y.Operator
            }).ToList() ;

            //Does the new instruction need all the old instruction's information or just the x.ins inum?
            var newInstruction = new Instruction()
            {
                Amount = x.Amount,
                HasBeenFlipped = x.HasBeenFlipped,
                HasBeenRun = x.HasBeenRun,
                Ins = x.Ins,
                Operator = x.Operator
            };

            instructionList[index] = FlipInstruction(newInstruction);

            if (_state.NextInstruction <= instructionList.Count)
            {
                bool runProgram = true;
                while (runProgram)
                {
                    if(_state.NextInstruction >= instructionList.Count)
                    {
                        runProgram = false;
                        Endgame(true);
                    }
                    else
                    {
                        _state.CurrentInstruction = instructionList[_state.NextInstruction];

                        if (!_state.CurrentInstruction.HasBeenRun)
                        {
                            int indexOrigin = instructionList.IndexOf(_state.CurrentInstruction);

                            switch (_state.CurrentInstruction.Ins.ToString())
                            {
                                case "acc":
                                    {
                                        if (_state.CurrentInstruction.Operator)
                                        {
                                            _state.Accumulator += _state.CurrentInstruction.Amount;
                                        }
                                        else
                                        {
                                            _state.Accumulator -= _state.CurrentInstruction.Amount;
                                        }
                                        // Toggle the HasBeenRun boolean
                                        instructionList[indexOrigin].HasBeenRun = true;
                                        _state.NextInstruction++;
                                        break;
                                    }
                                case "jmp":
                                    {
                                        if (_state.CurrentInstruction.Operator)
                                        {
                                            _state.NextInstruction += _state.CurrentInstruction.Amount;
                                        }
                                        else
                                        {
                                            _state.NextInstruction -= _state.CurrentInstruction.Amount;
                                        }
                                        instructionList[indexOrigin].HasBeenRun = true;
                                        break;
                                    }
                                case "nop":
                                    {
                                        instructionList[indexOrigin].HasBeenRun = true;
                                        _state.NextInstruction++;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            runProgram = false;
                            Endgame(false);
                        }
                    }
                }


                    
            }
        }

        private void X()
        {
            _repo.CleanInstructions.ForEach(instructionToCheck =>
            {

                Console.WriteLine($"List item {_repo.CleanInstructions.IndexOf(instructionToCheck) + 1}:");
                if (instructionToCheck.Ins != InstructionName.acc)
                {
                    // get the index
                    int index = _repo.CleanInstructions.IndexOf(instructionToCheck);
                    HandheldHaltingPartTwo(index, instructionToCheck);
                }
                else
                {
                    Console.WriteLine("---Not a jmp or nop");
                }
            });
        }

        private Instruction FlipInstruction(Instruction instruction)
        {
            if (instruction.Ins == InstructionName.jmp)
            {
                instruction.Ins = InstructionName.nop;
            }
            else if (instruction.Ins == InstructionName.nop)
            {
                instruction.Ins = InstructionName.jmp;
            }

            return instruction;
        }

        private void StateReset(Instruction beginning)
        {
            _state.Accumulator = 0;
            _state.NextInstruction = 0;
            _state.CurrentInstruction = beginning;
        }

        private void Endgame(bool winCondition)
        {
            if (winCondition)
            {
                Console.WriteLine($"---Accumulator: " + _state.Accumulator);
                Console.ReadKey();
            }
            //Console.Clear();
            Console.WriteLine($"---Accumulator: " + _state.Accumulator);
            //Console.ReadLine();
        }
    }
}
