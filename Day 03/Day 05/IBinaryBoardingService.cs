using System;
using System.Collections.Generic;
using System.Text;

namespace Day_05
{
    interface IBinaryBoardingService
    {
        List<BoardingPass> Passes { get; set; }

        List<BoardingPass> GetBoardingPasses();
    }
}
