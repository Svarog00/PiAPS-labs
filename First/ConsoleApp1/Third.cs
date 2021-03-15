using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Third
    {
        public static void Fibonacci(int digit)
        {
            switch (digit)
            {
                case 0:
                    {
                        return;  
                    }
                case 1:
                    {
                        Console.WriteLine("0 1\n");
                        return;
                    }
            }

            int prev = 0, current = 1, next;
            Console.Write("0 1 ");
            for (int i = 1; i < digit; i++)
            {
                next = prev + current;
                Console.Write($"{next} ");
                prev = current;
                current = next;
            }
            Console.Write("\n");
        }
    }
}
