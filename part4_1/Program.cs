using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4_1
{
    internal class Program
    {
        public static string[] SplitString(string str)
        {
            return str.Split(' ');
        }

        public static void PrintStrings(string[] strs)
        {
            foreach (var s in strs)
            {
                Console.WriteLine(s);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();
            PrintStrings(SplitString(str));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
