using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_01
{
    public class Dayoneservice
    {

        /// <summary>
        /// Takes a queue of numbers and performs operations to evaluate whether the sum of two numbers add to 2020, and if so, multiply those numbers.
        ///     Takes a Queue of numbers. While the Queue still has something in the queue, dequeue that number.
        ///     Take that dequeued number and add it to each number remaining in the queue.
        ///     If the result equals 2020, multiply those two numbers and there's your answer.
        ///     The queue is used because once a number has been evaulated against each other number in the list to see if it
        ///     is equal to 2020, it is no longer necessary to keep the number in the list.
        /// </summary>
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

        public int MultiplyThreeNumbers(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)                      // Loop 1 - Loop over the list
            {
                int numOne = numberList[i];                                 //  - Save the first number at index i
                for (int ii = 0; ii < numberList.Count; ii++)               // Loop 2 - Loop over the list again
                {                                                           //  - Add the first number to each number in the list
                    int numTwo = numberList[ii];                            //      creating a sum. If the sum is less than 2020,
                    int sumOne = numOne + numTwo;                           //      then it could still be looped through the
                    if (sumOne < 2020)                                      //      list a third time in order to sum to 2020
                    {                                                       //  - if the sum of all three numbers equals 2020,
                        for (int iii = 0; iii < numberList.Count; iii++)    //      then multiply all of them and the result wil be printed to 
                        {                                                   //      \Day 01\bin\Debug\netcoreapp3.1\ThreeOutput.txt
                            int sumTwo = sumOne + numberList[iii];
                            if (sumTwo == 2020)
                            {
                                Console.WriteLine("Matches found!");
                                File.WriteAllText(@"ThreeOutput.txt", $"First: {numberList[i]}; Second: {numberList[ii]}; Third: {numberList[iii]} Total multilied together: {numberList[i] * numberList[ii] * numberList[iii]}");
                                return numberList[i] * numberList[ii] * numberList[iii];
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
