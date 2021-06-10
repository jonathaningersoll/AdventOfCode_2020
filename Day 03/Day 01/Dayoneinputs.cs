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
        }

        public Queue<int> EnqueuedFile { get; set; }
        
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
    }
}
