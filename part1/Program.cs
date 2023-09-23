using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Workspace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            string fullname = "Timur Danilchenko";
            byte age = 21;
            string email = "timurdanilchenko@example.com";
            float scores_math = 3.14f;
            float scores_physics = 9.81f;
            float scores_programming = 2.56f;


            Console.Write("Fullname: {0}\n" +
                             "Age: {1}\n" +
                             "email: {2}\n" +
                             "Math score: {3}\n" +
                             "Physics score: {4}\n" +
                             "Programming score: {5}\n",
                             fullname, age, email, scores_math, scores_physics, scores_programming);

            Console.Write("Press any button to calculate summary and average scores");
            Console.ReadKey(true);

            int tmp = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, tmp);

            // Part 2
            float summary_score = scores_math + scores_physics + scores_programming;
            float average_score = summary_score / 3;

            Console.Write("Summary score: {0}\n" +
                            "Average score: {1}\n",
                            summary_score, average_score);

            Console.Write("Press any button to exit\n");
            Console.ReadKey(true);

        }
    }
}
