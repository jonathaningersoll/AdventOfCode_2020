﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_01
{
    class ProgramUI
    {
        private readonly IDayOneService _service;
        private readonly IDayOneInputs _inputs;
        public ProgramUI(IDayOneService service, IDayOneInputs inputs)
        {
            _service = service;
            _inputs = inputs;
        }
        public void VerboseMenu()
        {
            Run();
        }

        // 1.   Given a list of numbers, find two that sum to the number 2020. Then multiply those numbers and the product is the puzzle answer.
        //      - Take the text file, and enqueue each line parsing the string into an int.
        //      - Evaluate if there is anything in the queue, then dequeue the first number. Add that number to each line evaluating
        //          if it sums to 2020. If it does, multiply those two numbers and save the result. Otherwise, print "not a match".
        //      - The output.txt file is written to Day 01\bin\Debug\netcoreapp3.1\output.txt

        /// <summary>
        /// 2.  Given a list of numbers, find three numbers, that when, added together, produce the number 2020. Then multiply those numbers and the product is the puzzle answer.
        ///     - Use the same input file and load it into a list of integers. loop through each number, adding it to each number
        ///         in the list.
        ///     - Given the sum of that number, evaluate if it is less than 2020. If it is not, discontinue the loop and try a
        ///         different list item. If the number is less than 2020, then loop over the list a third time adding the sum of the
        ///         previous number to each number in the list. If the sum is equal to 2020, then you have a match. Multiply those
        ///         numbers and the product is the answer.
        /// </summary>


        /// <summary>
        /// Option menu with two options: multiply two numbers to satisfy day 1 part 1, or multiply three numbers to satisfy day 1 part 2.
        /// </summary>
        private void Run()
        {
            Console.WriteLine("Which program would you like to run?");
            Console.WriteLine("1. Multiply two numbers to get 2020\n" +
                "2. Multiply three numbers to get 2020");

            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    {
                        PartOne();
                        // MultiplyTwo(_inputs.EnqueuedFile);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Adding three numbers to find 2020, then multiplying the numbers...");
                        PartTwo();
                        // MultiplyThreeNumbers(InputList(file));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("default case");
                        break;
                    }
            }
            Console.WriteLine("Application finished. Press any key to continue");
            Console.ReadKey();
        }

        

        public void PartOne()
        {
            Console.WriteLine("Searching for solution...");
            if(_inputs.EnqueuedFile != null)
            {
                Console.WriteLine($"Answer: {_service.MultiplyTwoNumbers(_inputs.EnqueuedFile)}");
            }
        }

        public void PartTwo()
        {
            Console.WriteLine("Searching for solution...");

            Console.WriteLine($"Answer: {_service.MultiplyThreeNumbers(_inputs.ListedFile)}");
        }

        // OLD CODE:

        /// <summary>
        /// Uses the path to the input file to return a queue of integers.
        ///     - Read all the lines of the input file into an array of strings.
        ///     - For each line in the array, parse each string to int and enqueue the new line.
        ///     - Return the Queue.
        /// </summary>
        //public Queue<int> EnqueueFile(string path)
        //{
        //    Console.WriteLine("Beginning copy");

        //    Queue<int> newQueue = new Queue<int>();                 // Make a new queue
        //    string[] lines = File.ReadAllLines(path);               // Read the lines from the file into an array
        //    foreach (string line in lines)                          // For each line, parse to int, enqueue
        //    {
        //        int num = Int32.Parse(line);
        //        Console.WriteLine(num);
        //        newQueue.Enqueue(num);
        //    }
        //    Console.WriteLine("Copy complete. Press any key to continue...");
        //    Console.ReadKey();
        //    return newQueue;
        //}

        /// <summary>
        /// Creates a list of integers based on the input file path.
        ///     - Copy each line to an array of strings.
        ///     - For each string in the array, parse to integer, and add to a list.
        ///     - Return the list.
        /// </summary>
        //public List<int> InputList(string path)
        //{
        //    Console.WriteLine("Beginning copy to LIST");
        //    List<int> newList = new List<int>();                // Create a new list of integers
        //    string[] lines = File.ReadAllLines(path);           // Read all the lines into an array of strings
        //    foreach (string line in lines)                      // For each string in the array, parse it to an int,
        //    {                                                   // then add to the new list.
        //        int num = Int32.Parse(line);                    // return that list.
        //        Console.WriteLine(num);
        //        newList.Add(num);
        //    }
        //    Console.WriteLine("Copy complete. Press any key to continue...");
        //    Console.ReadKey();
        //    return newList;
        //}

        /// <summary>
        /// Takes a list of numbers, for each number in the list, add to the next number, take the sum, evaluate if the number
        /// is less than 2020, and if it is, loop over the list again adding the previous sum to each number. If the sum of those
        /// three numbers equals 2020, multiply all three numbers together and the result is your answer.
        /// </summary>
        //public void MultiplyThreeNumbers(List<int> numberList)
        //{
        //    for (int i = 0; i < numberList.Count; i++)                      // Loop 1 - Loop over the list
        //    {
        //        int numOne = numberList[i];                                 //  - Save the first number at index i
        //        for (int ii = 0; ii < numberList.Count; ii++)               // Loop 2 - Loop over the list again
        //        {                                                           //  - Add the first number to each number in the list
        //            int numTwo = numberList[ii];                            //      creating a sum. If the sum is less than 2020,
        //            int sumOne = numOne + numTwo;                           //      then it could still be looped through the
        //            if (sumOne < 2020)                                      //      list a third time in order to sum to 2020
        //            {                                                       //  - if the sum of all three numbers equals 2020,
        //                for (int iii = 0; iii < numberList.Count; iii++)    //      then multiply all of them and the result wil be printed to 
        //                {                                                   //      \Day 01\bin\Debug\netcoreapp3.1\ThreeOutput.txt
        //                    int sumTwo = sumOne + numberList[iii];
        //                    if (sumTwo == 2020)
        //                    {
        //                        Console.WriteLine($"Match Found! First Number: {numberList[i]}; Second: {numberList[ii]}; Third: {numberList[iii]} Total: {numberList[i] * numberList[ii] * numberList[iii]}");
        //                        Console.ReadKey();
        //                        File.WriteAllText(@"ThreeOutput.txt", $"First: {numberList[i]}; Second: {numberList[ii]}; Third: {numberList[iii]} Total multilied together: {numberList[i] * numberList[ii] * numberList[iii]}");
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine(numberList[iii]);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
