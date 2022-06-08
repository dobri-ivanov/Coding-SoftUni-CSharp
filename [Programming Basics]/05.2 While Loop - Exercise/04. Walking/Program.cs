using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int currnetSteps = 0;

            while (currnetSteps < 10000)
            {
                string text = Console.ReadLine();
                if (text == "Going home")
                {
                    currnetSteps += int.Parse(Console.ReadLine());
                    break;
                }

                int steps = int.Parse(text);
                currnetSteps += steps;
            }
            if (currnetSteps < 10000)
            {
                int sum = 10000 - currnetSteps;
                Console.WriteLine($"{sum} more steps to reach goal.");
            }
            else
            {
                int sum = currnetSteps - 10000;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{sum} steps over the goal!");
            }
        }
    }
}
