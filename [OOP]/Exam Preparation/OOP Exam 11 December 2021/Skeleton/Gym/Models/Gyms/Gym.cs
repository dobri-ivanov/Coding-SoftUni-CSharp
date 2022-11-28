using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentException(String.Format(ExceptionMessages.InvalidGymName));
                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set => capacity = value;
        }

        public double EquipmentWeight
        {
            get { return this.equipments.Sum(e => e.Weight); }
        }

        public ICollection<IEquipment> Equipment => equipments.AsReadOnly();

        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (this.athletes.Count == Capacity) throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughSize));
            this.athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            this.athletes.ForEach(a => a.Exercise());
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            string athletesInTheGym = athletes.Any() ? string.Join(", ", athletes.Select(x => x.FullName)) : "No athletes";

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            sb.Append("Athletes: ");
            sb.AppendLine(athletesInTheGym);
            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.Append($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }

    }
}
