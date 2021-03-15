using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        public static void ShowMenu()
        {
            Console.WriteLine("1.Show args\n2.Show years\n3.Show Fibonacci numbers\n4.Calculate factorial\n5.Show simple digits\n6.Exit");
        }
        static void Main(string[] args)
        {
            bool isLaunched = true;
            ShowMenu();
            while (isLaunched)
            {
                int selected = int.Parse(Console.ReadLine());
                switch(selected)
                {
                    case 1:
                        {
                            First.ShowArgs(args);
                            break;
                        }

                    case 2:
                        {
                            Second.ShowYears();
                            break;
                        }

                    case 3:
                        {
                            int digit = int.Parse(Console.ReadLine());
                            Third.Fibonacci(digit);
                            break;
                        }

                    case 4:
                        {
                            int digit = int.Parse(Console.ReadLine());
                            Console.WriteLine(Fourth.Factorial(digit));
                            break;
                        }

                    case 5:
                        {
                            int digit = int.Parse(Console.ReadLine());
                            Fifth.Eratosthene(digit);
                            break;
                        }

                    case 6:
                        {
                            isLaunched = false;
                            Console.WriteLine("Goodbye...");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Incorrect number...");
                            break;
                        }
                }
            }
        }
    }
}
