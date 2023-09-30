using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4_2
{
    internal class Program
    {
        public static string[] SplitString(string str)
        {
            return str.Split(' ');
        }

        public static string ReverseStrings(string[] strs)
        {
            string result = "";
            foreach (var str in strs)
            {
                result = str + " " + result;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the string: ");
            Console.WriteLine("Reversed string: {0}", ReverseStrings(SplitString(Console.ReadLine())));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            
        }
    }
}
