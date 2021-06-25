using System;

namespace Day_06
{
    class Program
    {
        static void Main(string[] args)
        {
            DaySix app = new DaySix(new CustomCustomsRepository());
            app.App();
        }
    }
}
