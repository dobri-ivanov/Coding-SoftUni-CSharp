using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int failedTreshold = int.Parse(Console.ReadLine());
            int failedCounter = 0;
            bool failed = false;
            double finalScore = 0;
            int problemsSolved = 0;
            string lastProblem = string.Empty;

            while (true)
            {
                string problem = Console.ReadLine();
                if (problem == "Enough")
                {
                    break;
                }
                double score = double.Parse(Console.ReadLine());
                if (score <= 4.00)
                {
                    failedCounter++;
                }
                if (failedCounter == failedTreshold)
                {
                    failed = true;
                    break;
                }

                finalScore += score;
                problemsSolved++;
                lastProblem = problem;
            }

            //Ouput
            double averageScore = finalScore / problemsSolved;
            if (failed)
            {
                Console.WriteLine($"You need a break, {failedCounter} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {problemsSolved}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
