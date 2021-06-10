using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_01
{
    public class Dayoneservice
    {
        public int MultiplyTwoNumbers(Queue<int> queue)
        {
            while (queue.Count > 0)                             // While the queue is populated...
            {
                int dqdNumber = queue.Dequeue();                // Take the number off the top of the queue...
                foreach (int num in queue)                      // and for each remaining number in the queue...
                {
                    int potentialNum = dqdNumber + num;         // sum the two numbers.
                    if (potentialNum == 2020)                   // If the result equals 2020, then it's a match.
                    {                                           // Multiply those two numbers and write to the file which is
                        //Console.WriteLine("Match Found!!");     // found in \Day 01\bin\Debug\netcoreapp3.1\output.txt
                        File.WriteAllText(@"./output.txt", $"First number: {dqdNumber}, Second number: {num}, sum: {dqdNumber + num}, Answer: {dqdNumber * num}");
                        //Console.WriteLine($"First number: {dqdNumber}, Second number: {num}, sum: {dqdNumber + num}, Answer: {dqdNumber * num}");
                        return dqdNumber * num;
                    }
                }
            }
            return 0;
        }
    }
}
