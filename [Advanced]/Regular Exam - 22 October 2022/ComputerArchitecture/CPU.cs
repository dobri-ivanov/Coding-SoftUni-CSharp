using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        public override string ToString()
        {
            return String.Format($"{this.Brand} CPU:{Environment.NewLine}Cores: {this.Cores}{Environment.NewLine}Frequency: {this.Frequency:f1} GHz");
        }
    }

}
