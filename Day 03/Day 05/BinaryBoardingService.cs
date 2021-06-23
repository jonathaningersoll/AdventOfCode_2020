using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_05
{
    public class BinaryBoardingService {

        protected readonly List<BoardingPass> BoardingPasses = new List<BoardingPass>();

        public List<BoardingPass> GetBoardingPasses()
        {
            return BoardingPasses;
        }

        public bool CreateBoardingPasses(List<string> passes)
        {
            int before = BoardingPasses.Count;
            passes.ForEach(p => BoardingPasses.Add(BuildBoardingPass(p)));
            return BoardingPasses.Count() > before;
        }


        public BoardingPass BuildBoardingPass(string pass)
        {
            BoardingPass boardingPass = new BoardingPass();
            boardingPass.InputLabel = pass;
            for (int bin = 0; bin < 10; bin++)
            {
                if (bin < 7)
                {
                    boardingPass.Row += EvaluateFrontOrBack(pass[bin], bin);
                }
                else
                {
                    boardingPass.Column += EvaluateRightOrLeft(pass[bin], bin);
                }
            }
            boardingPass.SeatId = boardingPass.Row * 8 + boardingPass.Column;
            return boardingPass;
        }


        public int EvaluateFrontOrBack(char dir, int i)
        {
            switch (dir)
            {
                case 'B':
                    {
                        return AddIndexValue(i);
                    }
                case 'F':
                    {
                        return 0;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }


        public int EvaluateRightOrLeft(char dir, int i)
        {
            switch (dir)
            {
                case 'R':
                    {
                        return AddIndexValue(i);
                    }
                case 'L':
                    {
                        return 0;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }


        public int AddIndexValue(int i)
        {
            switch (i)
            {
                case 0:
                    {
                        return 64;
                    }
                case 1:
                    {
                        return 32;
                    }
                case 2:
                    {
                        return 16;
                    }
                case 3:
                    {
                        return 8;
                    }
                case 4:
                    {
                        return 4;
                    }
                case 5:
                    {
                        return 2;
                    }
                case 6:
                    {
                        return 1;
                    }
                case 7:
                    {
                        return 4;
                    }
                case 8:
                    {
                        return 2;
                    }
                case 9:
                    {
                        return 1;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }


        public int GetHighestSeatId(List<BoardingPass> passes)
        {
            var numList = new List<int>();
            passes.ForEach(p => numList.Add(p.SeatId));
            return numList.Max();
        }

        public bool DeleteBoardingPasses()
        {
            int before = BoardingPasses.Count();
            if (BoardingPasses.Count() > 1){
                BoardingPasses.Clear();
            }
            return before >= BoardingPasses.Count();
        }

        public int GetMissingSeatId(List<BoardingPass> passes)
        {
            List<int> seatIds = new List<int>();
            passes.ForEach(p => seatIds.Add(p.SeatId));
            seatIds.Sort();
            seatIds.ForEach(id => Console.WriteLine(id));
            for (int i = 1; i < seatIds.Count(); i++)
                {
                    if(seatIds[i] - i == seatIds[0])
                    {
                        Console.WriteLine("Consecutive number");
                    }
                    else
                    {
                    return seatIds[i] - 1;
                    }
                }
                return 0;
        }
    }
}
