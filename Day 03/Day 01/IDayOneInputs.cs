using System;
using System.Collections.Generic;
using System.Text;

namespace Day_01
{
    interface IDayOneInputs
    {
        Queue<int> EnqueuedFile { get; set; }
        List<int> ListedFile { get; set; }
        Queue<int> EnqueueFile(string file);
        List<int> ListFile(string file);
    }
}
