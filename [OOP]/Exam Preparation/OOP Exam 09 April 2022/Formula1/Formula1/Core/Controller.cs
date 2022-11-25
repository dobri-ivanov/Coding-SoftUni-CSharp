using Formula1.Core.Contracts;
using Formula1.Models.Cars;
using Formula1.Models.Contracts;
using Formula1.Models.Pilots;
using Formula1.Models.Races;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilots = new PilotRepository();
        private IRepository<IRace> races = new RaceRepository();
        private IRepository<IFormulaOneCar> cars = new FormulaOneCarRepository();
        public string CreatePilot(string fullName)
        {
            if (this.pilots.FindByName(fullName) != null) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            IPilot pilot = new Pilot(fullName);
            this.pilots.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar currentCar;
            if (this.cars.FindByName(model) != null) throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            if (type == nameof(Ferrari))
            {
                currentCar = new Ferrari(model, horsepower, engineDisplacement); ;
            }
            else if (type == nameof(Williams))
            {
                currentCar = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            this.cars.Add(currentCar);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.races.FindByName(raceName) != null) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            IRace race = new Race(raceName, numberOfLaps);
            this.races.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (this.pilots.FindByName(pilotName) == null) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            IPilot pilot = this.pilots.FindByName(pilotName);
            if(pilot.Car == null) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            if(this.cars.FindByName(carModel) == null) throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            IFormulaOneCar car = this.cars.FindByName(carModel);
            pilot.AddCar(car);
            this.cars.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }
        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if(this.races.FindByName(raceName) == null) throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            IRace race = this.races.FindByName(raceName);

            if(this.pilots.FindByName(pilotFullName) == null) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            IPilot pilot = this.pilots.FindByName(pilotFullName);
            if(pilot.CanRace == false) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            foreach (var currentRace in this.races.Models)
            {
                foreach (var currentPilot in currentRace.Pilots)
                {
                    if (currentPilot.FullName == pilotFullName) throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
                }
            }
            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string StartRace(string raceName)
        {
            if(this.races.FindByName(raceName) == null) throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            IRace race = this.races.FindByName(raceName);
            if (race.Pilots.Count < 3) throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            if(race.TookPlace == true) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            race.TookPlace = true;
            var currentRacePilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            foreach (var racePilot in currentRacePilots)
            {
                racePilot.WinRace();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {currentRacePilots[0].FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot {currentRacePilots[1].FullName} is second in the {race.RaceName} race.");
            sb.AppendLine($"Pilot {currentRacePilots[2].FullName} is third in the {race.RaceName} race.");
            return sb.ToString().TrimEnd();
        }









        public string PilotReport()
        {
            throw new NotImplementedException();
        }
        public string RaceReport()
        {
            throw new NotImplementedException();
        }

    }
}
