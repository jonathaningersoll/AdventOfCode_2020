using System;

namespace Day_08
{
    class Program
    {
        static void Main(string[] args)
        {
            HandheldHalting App = new HandheldHalting(new HandheldHaltingRepository(), new ProgramState());
            App.Run();
        }
    }
}
