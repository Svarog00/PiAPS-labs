using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fifth
    {
        public static void Eratosthene(int maxValue)
        {
            List<int> numbers = new List<int>();
            //Initialize
            for(int i = 2; i < maxValue; i++)
            {
                numbers.Add(i);
            }

            //Delete multiples numbers
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 2; j < maxValue; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            //Show numbers
            for(int i = 0; i < numbers.Count; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
