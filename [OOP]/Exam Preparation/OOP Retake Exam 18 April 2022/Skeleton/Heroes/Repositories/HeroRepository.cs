using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;
        public IReadOnlyCollection<IHero> Models => this.heroes.AsReadOnly();

        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.Find(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            return this.heroes.Remove(model);
        }
    }
}
