using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equpments;
        private List<IGym> gyms;
        public Controller()
        {
            equpments = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            this.gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            this.equpments.Add(equipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (this.equpments.FindByType(equipmentType) == null) throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            IEquipment equipment = this.equpments.FindByType(equipmentType);
            IGym gym = this.gyms.Find(g => g.Name == gymName);
            gym.AddEquipment(equipment);
            this.equpments.Remove(equipment);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            IGym gym = this.gyms.Find(x => x.Name == gymName);
            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != nameof(BoxingGym))
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != nameof(WeightliftingGym))
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            gym.AddAthlete(athlete);
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }
        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.Find(x => x.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }
            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.Find(x => x.Name == gymName);
            double totalWeight = gym.EquipmentWeight;
            return String.Format($"The total weight of the equipment in the gym {gymName} is {totalWeight:f2} grams.");
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
