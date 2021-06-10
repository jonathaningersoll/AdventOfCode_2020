using System;

namespace Day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI(new Dayoneservice(), new Dayoneinputs());
            ui.VerboseMenu();
        }
    }
}
