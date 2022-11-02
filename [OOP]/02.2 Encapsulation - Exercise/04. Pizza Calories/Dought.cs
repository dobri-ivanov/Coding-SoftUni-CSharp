using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Dought
    {
        private const double MOD_FLOUR_WHITE = 1.5;
        private const double MOD_FLOUR_WHOLEGRAIN = 1.0;
        private const double MOD_BAKE_CRISPY = 0.9;
        private const double MOD_BAKE_CHEWY = 1.1;
        private const double MOD_BAKE_HOMEMADE = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dought(string flourType, string bakingTechique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechique;
            Grams = grams;
        }

        public string FlourType { get; set; }
        public string BakingTechnique { get; set; }
        public double Grams { get; set; }

        public double CalculateCalories()
        {

        }
    }
}
