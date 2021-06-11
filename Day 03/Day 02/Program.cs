using System;

namespace Day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            AppUI app = new AppUI(new PasswordPhilosophyService(), new DayTwoInput());
            app.Run();
        }
    }
}
