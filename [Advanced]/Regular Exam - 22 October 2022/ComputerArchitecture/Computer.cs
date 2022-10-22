using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count { get { return this.Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (!(this.Capacity == Count))
            {
                this.Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            if (!this.Multiprocessor.Any(x => x.Brand == brand))
            {
                return false;
            }
            CPU cpu = this.Multiprocessor.Find(x => x.Brand == brand);
            this.Multiprocessor.Remove(cpu);
            return true;
        }
        public CPU MostPowerful()
        {
            if (!this.Multiprocessor.Any())
            {
                return null;
            }
            List<CPU> orderedCPUs = this.Multiprocessor.OrderByDescending(x => x.Frequency).ToList();
            return orderedCPUs[0];
        }
        public CPU GetCPU(string brand)
        {
            if (!this.Multiprocessor.Any(x => x.Brand == brand))
            {
                return null;
            }
            CPU cpu = this.Multiprocessor.Find(x => x.Brand == brand);
            return cpu;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var cpu in this.Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            string cpuInformation = sb.ToString().TrimEnd();
            return String.Format($"CPUs in the Computer {this.Model}:{Environment.NewLine}{cpuInformation}");
        }
    }
}
