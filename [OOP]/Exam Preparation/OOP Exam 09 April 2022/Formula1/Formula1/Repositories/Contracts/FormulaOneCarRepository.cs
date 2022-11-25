using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Contracts
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars;
        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => this.cars.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            this.cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.cars.Find(c => c.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return cars.Remove(model);
        }
    }
}
