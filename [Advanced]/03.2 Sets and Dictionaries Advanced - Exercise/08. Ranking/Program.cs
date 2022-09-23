using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> users = new List<User>();
            Dictionary<string, string> contests = new Dictionary<string, string>();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "end of contests")
                {
                    break;
                }
                string contest = tokens[0];
                string password = tokens[1];
                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, "");
                }
                contests[contest] = password;
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "end of submissions")
                {
                    break;
                }

                string contest = tokens[0];
                string password = tokens[1];
                string userName = tokens[2];
                int contestPoints = int.Parse(tokens[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        if (!users.Any(student => student.Name == userName))
                        {
                            User user = new User(userName);
                            users.Add(user);
                        }
                        User changingUser = users.Single(student => student.Name == userName);
                        if (!changingUser.Exams.ContainsKey(contest))
                        {
                            changingUser.Exams.Add(contest, 0);
                        }
                        if (changingUser.Exams[contest] < contestPoints)
                        {
                            changingUser.Exams[contest] = contestPoints;
                            changingUser.TotalPoint += contestPoints;
                        }
                        changingUser.Exams = changingUser.Exams.OrderByDescending(contest => contest.Value).ToDictionary(x => x.Key, x => x.Value);
                    }
                }
            }
            users = users.OrderByDescending(student => student.TotalPoint).ToList();

            User bestCandidate = users[0];
            users = users.OrderBy(student => student.Name).ToList();
            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {bestCandidate.TotalPoint} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users)
            {
                if (user.TotalPoint <= 0)
                {
                    continue;
                }
                Console.WriteLine(user.Name);
                foreach (var contest in user.Exams)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }

    internal class User
    {
        public string Name { get; set; }
        public Dictionary<string, int> Exams { get; set; }
        public int TotalPoint { get; set; }

        public User(string name)
        {
            Name = name;
            Exams = new Dictionary<string, int>();
            TotalPoint = 0;
        }
    }
}