using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press A:");
            string str_a = Console.ReadLine();
            Console.WriteLine("Press B:");
            string str_b = Console.ReadLine();
            Console.WriteLine(Add(int.Parse(str_a), int.Parse(str_b)));



        }
        public static int Add(int x, int y)
        {
            return x + y;
        }

    }
}
