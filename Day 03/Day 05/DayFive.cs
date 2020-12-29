using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_05
{
    class DayFive
    {
        public void App()
        {
            UI();
        }
        
        private void UI()
        {
            List<string> input = File.ReadAllLines(@"./input.txt").Select(n => n).ToList();
            List<int> seatIds = new List<int>();

            // Operation on each line of the file:
            for (int i = 0; i < input.Count; i++)
            {
                string line = input[i];
                var columns = new List<char>() { input[i][7], input[i][8], input[i][9] };
                int row = 0;
                int seat = 0;

                // Operate on the first seven characters (0-6) in an individual line
                for(int bin = 0; bin < 7; bin++)
                {
                        row += TranslateToBinary(line[bin], bin);
                }
                seat = Columns(columns);
                int seatId = (row * 8) + seat;
                Console.WriteLine($"Row: {row}, Seat:{seat}, Seat ID: {seatId}");
                seatIds.Add(seatId);
            }

            Console.WriteLine(seatIds.Max());
        }

        // ROW FINDING METHODS //
        public int EvaluateIndex(int num)
        {
            switch (num)
            {
                case 0:
                    {
                        num = 64;
                        break;
                    }
                case 1:
                    {
                        num = 32;
                        break;
                    }
                case 2:
                    {
                        num = 16;
                        break;
                    }
                case 3:
                    {
                        num = 8;
                        break;
                    }
                case 4:
                    {
                        num = 4;
                        break;
                    }
                case 5:
                    {
                        num = 2;
                        break;
                    }
                case 6:
                    {
                        num = 1;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return num;
        }
        public int TranslateToBinary(char direction, int index)
        {
            int amount = 0;
            switch (direction)
            {
                case 'B':
                    {
                        amount += EvaluateIndex(index);
                        break;
                    }
                case 'F':
                    {
                        amount += 0;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return amount;
        }

        // SEAT FINDING METHODS //
        public int Columns(List<char> columns)
        {
            var col = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            foreach(char direction in columns)
            {
                int newColAmount = col.Count() / 2;
                
                if (direction == 'R')
                {
                    col.RemoveRange(0, newColAmount);
                }
                else
                {
                    col.RemoveRange(newColAmount, newColAmount);
                }
            }

            return col[0];
        }
    }
}
