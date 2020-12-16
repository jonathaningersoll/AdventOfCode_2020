using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_01
{
    class ProgramUI
    {
        public void VerboseMenu()
        {
            Run();
        }

        private void Run()
        {
            var file = @"./input.txt";
            Console.WriteLine("Which program would you like to run?");
            Console.WriteLine("1. Multiply two numbers to get 2020\n" +
                "2. Multiply three numbers to get 2020");

            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    {
                        MultiplyTwo(EnqueueFile(file));
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Adding three numbers to find 2020, then multiplying the numbers...");
                        MultiplyThree(InputList(file));
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


        public Queue<int> EnqueueFile(string path)
        {
            Console.WriteLine("Beginning copy");
            Queue<int> newQueue = new Queue<int>();                 // Make a new queue
            string[] lines = File.ReadAllLines(path);               // Read the lines from the file into an array
            foreach (string line in lines)                          // For each line, parse to int, enqueue
            {
                int num = Int32.Parse(line);
                Console.WriteLine(num);
                newQueue.Enqueue(num);
            }
            Console.WriteLine("Copy complete. Press any key to continue...");
            Console.ReadKey();
            return newQueue;
        }

        public List<int> InputList(string path)
        {
            Console.WriteLine("Beginning copy to LIST");
            List<int> newList = new List<int>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                int num = Int32.Parse(line);
                Console.WriteLine(num);
                newList.Add(num);
            }
            Console.WriteLine("Copy complete. Press any key to continue...");
            Console.ReadKey();
            return newList;
        }

        public void MultiplyTwo(Queue<int> queue)
        {
            while(queue.Count > 0)
            {
                int dqdNumber = queue.Dequeue();
                foreach(int num in queue)
                {
                    int potentialNum = dqdNumber + num;
                    if(potentialNum == 2020)
                    {
                        Console.WriteLine("Match Found!!");
                        File.WriteAllText(@"./output.txt", $"First number: {dqdNumber}, Second number: {num}, sum: {dqdNumber + num}, Answer: {dqdNumber * num}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"{num} is not a match");
                    }
                }
            }
        }

        public void MultiplyThree(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                int numOne = numberList[i];
                for (int ii = 0; ii < numberList.Count; ii++)
                {
                    int numTwo = numberList[ii];
                    int sumOne = numOne + numTwo;
                    if (sumOne < 2020)
                    {
                        for (int iii = 0; iii < numberList.Count; iii++)
                        {
                            int sumTwo = sumOne + numberList[iii];
                            if (sumTwo == 2020)
                            {
                                Console.WriteLine($"Match Found! First Number: {numberList[i]}; Second: {numberList[ii]}; Third: {numberList[iii]} Total: {numberList[i] * numberList[ii] * numberList[iii]}");
                                Console.ReadKey();
                                File.WriteAllText(@"ThreeOutput.txt", $"First: {numberList[i]}; Second: {numberList[ii]}; Third: {numberList[iii]} Total multilied together: {numberList[i] * numberList[ii] * numberList[iii]}");
                            }
                            else
                            {
                                Console.WriteLine(numberList[iii]);
                            }
                        }
                    }
                }
            }
        }
    }
}
