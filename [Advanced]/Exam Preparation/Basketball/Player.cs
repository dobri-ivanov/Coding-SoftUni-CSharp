using System;
using System.Text;
using System.Xml.Linq;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rateing, int games)
        {
            Name = name;
            Position = position;
            Rating = rateing;
            Games = games;
            Retired = false;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; }

        public override string ToString()
        {
            return String.Format($"-Player: {this.Name}{Environment.NewLine}--Position: {this.Position}{Environment.NewLine}--Rating: {this.Rating}{Environment.NewLine}--Games played: {this.Games}");

        }
    }
}
