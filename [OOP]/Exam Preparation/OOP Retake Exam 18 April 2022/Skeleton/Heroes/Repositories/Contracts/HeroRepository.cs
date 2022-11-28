using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories.Contracts
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heros;
        public HeroRepository()
        {
            heros = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => heros.AsReadOnly();

        public void Add(IHero model)
        {
            heros.Add(model);
        }

        public IHero FindByName(string name)
        {
            return heros.Find(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
            return heros.Remove(model);
        }
    }
}
