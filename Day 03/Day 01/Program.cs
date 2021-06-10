using System;

namespace Day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new Dayoneinputs();
            var service = new Dayoneservice();
            ProgramUI ui = new ProgramUI(service, inputs);
            ui.VerboseMenu();
        }
    }
}
