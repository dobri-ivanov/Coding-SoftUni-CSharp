using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;
        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => units.AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return units.Find(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return units.Remove(FindByName(name));
        }
    }
}
