using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_01
{
    class Dayoneinputs
    {
        public Dayoneinputs()
        {
            EnqueuedFile = EnqueueFile(@"./input.txt");
            ListedFile = ListFile(@"./input.txt");
        }

        public Queue<int> EnqueuedFile { get; set; }
        public List<int> ListedFile { get; set; }

        /// <summary>
        /// Uses the path to the input file to return a queue of integers.
        ///     - Read all the lines of the input file into an array of strings.
        ///     - For each line in the array, parse each string to int and enqueue the new line.
        ///     - Return the Queue.
        /// </summary>
        private Queue<int> EnqueueFile(string file)
        {
            Queue<int> newQueue = new Queue<int>();                 // Make a new queue
            string[] lines = File.ReadAllLines(file);               // Read the lines from the file into an array
            foreach (string line in lines)                          // For each line, parse to int, enqueue
            {
                int num = Int32.Parse(line);
                newQueue.Enqueue(num);
            }
            return newQueue;
        }

        /// <summary>
        /// Creates a list of integers based on the input file path.
        ///     - Copy each line to an array of strings.
        ///     - For each string in the array, parse to integer, and add to a list.
        ///     - Return the list.
        /// </summary>
        private List<int> ListFile(string file)
        {
            List<int> newList = new List<int>();                // Create a new list of integers
            var lines = File.ReadAllLines(file);                // Read all the lines into an array of 
            foreach (string line in lines)                      // For each string in the array, parse it to an int,
            {                                                   // then add to the new list.
                newList.Add(Int32.Parse(line));                 // return that list.
            }
            return newList;
        }
    }
}
