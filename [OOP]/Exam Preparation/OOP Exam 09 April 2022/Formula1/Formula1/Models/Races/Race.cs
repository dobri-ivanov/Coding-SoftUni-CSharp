using Formula1.Models.Contracts;
using Formula1.Models.Pilots;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Races
{
    public class Race : IRace
    {
        private string raceName;
        private int numbersOfLaps;
        private List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.raceName = raceName;
            this.numbersOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
            this.TookPlace = false;
        }
        public string RaceName
        {
            get { return this.raceName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5) throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return this.numbersOfLaps; }
            private set
            {
                if (value < 1) throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                this.numbersOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }
        

        public ICollection<IPilot> Pilots => this.pilots.AsReadOnly();

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookplace = "";
            if (this.TookPlace)
            {
                tookplace = "Yes";
            }
            else
            {
                tookplace = "No";
            }
          
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            sb.AppendLine($"Took place: {tookplace}");
            return sb.ToString().TrimEnd();
        }
    }
}
