using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('-');
                var creator = input[0];
                var teamName = input[1];

                if (teams.Any(currentTeam => currentTeam.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team team = new Team();
                    team.Name = teamName;
                    team.Creator = creator;
                    team.Members = new List<string>();
                    teams.Add(team);   
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
            string lane = Console.ReadLine();
            while (lane != "end of assignment")
            {
                var info = lane.Split("->");
                var memberName = info[0];
                var teamToJoin = info[1];

                if (teams.Any(team => team.Members.Contains(memberName)) || teams.Any(team => team.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                }
                else if (!teams.Any(team => team.Name == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else
                {
                    var currentTeam = teams.Find(team => team.Name == teamToJoin);
                    currentTeam.Members.Add(memberName);
                }

                 lane = Console.ReadLine();
            }
            var complatedTeams = teams.Where(team => team.Members.Count > 0);
            var disbanedTeams = teams.Where(team => team.Members.Count == 0);

            foreach (var team in complatedTeams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(team => team))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            if (disbanedTeams != null)
            {
                Console.WriteLine("Teams to disband:");
                foreach (var team in disbanedTeams.OrderBy(team => team.Name))
                {
                    Console.WriteLine(team.Name);
                }
            }

        }
    }
    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
