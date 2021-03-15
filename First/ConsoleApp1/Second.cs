using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Second
    {
        public static void ShowYears()
        {
            int leapYearCount = 0;
            for (int years = 1900; years <= 2000; years++, leapYearCount++)
            {
                if(leapYearCount == 4)
                {
                    Console.WriteLine($"{years} is leap");
                    leapYearCount = 0;
                }
                else
                {
                    Console.WriteLine($"{years} is not leap");
                }
            }
        }
    }
}
