using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }
        private List<Renovator> renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return this.renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Type == null ||
                renovator.Name == "" || renovator.Type == "")
            {
                return "Invalid renovator's information.";
            }
            if (this.NeededRenovators == Count)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            if (this.renovators.Any(x => x.Name == name))
            {
                Renovator renovator = this.renovators.Find(x => x.Name == name);
                this.renovators.Remove(renovator);
                return true;
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            if (this.renovators.Any(x => x.Type == type))
            {
                var renovators = this.renovators.FindAll(x => x.Type == type);
                int count = 0;
                foreach (var renovator in renovators)
                {
                    this.renovators.Remove(renovator);
                    count++;
                }
                return count;
            }
            return 0;
        }
        public Renovator HireRenovator(string name)
        {
            if (this.renovators.Any(x => x.Name == name))
            {
                var renovator = this.renovators.Find(x => x.Name == name);
                renovator.Hired = true;
                return renovator;
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payedRenovators = new List<Renovator>();
            foreach (var renovator in this.renovators)
            {
                if (renovator.Days >= days)
                {
                    payedRenovators.Add(renovator);
                }
            }
            return payedRenovators;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var renovator in this.renovators)
            {
                if (renovator.Hired != true)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }
            string result = sb.ToString().TrimEnd();
            return String.Format($"Renovators available for Project {this.Project}:\n{result}");
        }
    }
}
