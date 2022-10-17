using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Schema;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return this.Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Name == "" || player.Position == null || player.Position == "")
            {
                return "Invalid player's information.";
            }
            if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            this.Players.Add(player);
            this.OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }
        public bool RemovePlayer(string name)
        {
            if (!this.Players.Any(x => x.Name == name))
            {
                return false;
            }

            this.OpenPositions++;
            Player player = this.Players.Find(x => x.Name == name);
            this.Players.Remove(player);
            return true;
        }
        public int RemovePlayerByPosition(string position)
        {
            if (!this.Players.Any(x => x.Position == position))
            {
                return 0;
            }
            List<Player> playersToBeRemoved = this.Players.FindAll(x => x.Position == position);
            int count = 0;
            foreach (var player in playersToBeRemoved)
            {
                this.RemovePlayer(player.Name);
                count++;
            }
            return count;
        }
        public Player RetirePlayer(string name)
        {
            if (!this.Players.Any(x => x.Name == name))
            {
                return null;
            }
            Player player = this.Players.Find(x => x.Name == name);
            player.Retired = true;
            return player;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardedPlayes = new List<Player>();
            awardedPlayes = this.Players.FindAll(x => x.Games >= games);
            return awardedPlayes;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            List<Player> notRetiredPlayers = this.Players.FindAll(x => x.Retired == false);
            foreach (var player in notRetiredPlayers)
            {
                sb.AppendLine(player.ToString());
            }
            string text = sb.ToString().TrimEnd();
            return String.Format($"Active players competing for Team {this.Name} from Group {this.Group}:{Environment.NewLine}" + text);
            
        }
    }
}
