using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fourth
    {
        public static int Factorial(int digit)
        {
            if (digit == 0)
                return 1;
            return digit * Factorial(digit - 1);
        }
    }
}
