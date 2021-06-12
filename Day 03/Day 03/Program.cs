using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App(new TobogganTrajectoryService());
            app.RunUI();
        }
    }
}
