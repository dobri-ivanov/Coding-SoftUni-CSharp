using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contestsInfo = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }
                string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];

                if (!contestsInfo.ContainsKey(contest))
                {
                    contestsInfo.Add(contest, string.Empty);
                }
                contestsInfo[contest] = password;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }

                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string currentname = tokens[2];
                int currentPoint = int.Parse(tokens[3]);

                bool isValidContest = false;
                if (contestsInfo.ContainsKey(contest))
                {
                    if (contestsInfo[contest] == password)
                    {
                        //Valid contest
                        isValidContest = true;
                    }
                }
                if (isValidContest)
                {
                    if (!users.ContainsKey(currentname))
                    {
                        users[currentname] = new Dictionary<string, int>();
                    }

                    if (!users[currentname].ContainsKey(contest))
                    {
                        users[currentname].Add(contest, currentPoint);
                    }
                    else
                    {
                        int points = users[currentname][contest];
                        if (currentPoint > points)
                        {
                            users[currentname][contest] = currentPoint;
                        }
                    }
                    if (users[currentname].Count > 1)
                    {
                        users[currentname] = users[currentname]
                            .OrderByDescending(x => x.Value)
                            .ToDictionary(x => x.Key, x => x.Value);
                    }

                }
            }
            users = users
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string[] result = GetBestUser(users);
            string name = result[0];
            int resultPoints = int.Parse(result[1]);
            Console.WriteLine($"Best candidate is {name} with total {resultPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }

        private static string[] GetBestUser(Dictionary<string, Dictionary<string, int>> users)
        {
            string[] result = new string[2];
            string bestCandidate = string.Empty;
            int bestPoints = int.MinValue;
            foreach (var name in users)
            {
                int currentTotalPoint = name.Value.Values.Sum();
                if (currentTotalPoint > bestPoints)
                {
                    bestPoints = currentTotalPoint;
                    bestCandidate = name.Key;
                }
            }
            result[0] = bestCandidate;
            result[1] = bestPoints.ToString();
            return result;
        }
    }
}