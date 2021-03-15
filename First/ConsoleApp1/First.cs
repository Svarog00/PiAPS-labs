using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class First
    {
        public static void ShowArgs(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Oh..You don`t enter agruments");
            }
            else
            {
                for(int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"Argument {i} is {args[i]}\n");
                }
            }
        }
    }
}
