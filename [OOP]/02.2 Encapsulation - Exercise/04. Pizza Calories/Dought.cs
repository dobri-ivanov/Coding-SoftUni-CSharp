﻿using System;
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

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                    throw new ArgumentException("Invalid type of dough.");
                flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                    throw new ArgumentException("Invalid type of dough.");
                bakingTechnique = value;
            }
        }

        private double Grams
        {
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                grams = value;
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                double caloriesPerGram = 2;

                if (this.flourType.ToLower() == "white") caloriesPerGram *= MOD_FLOUR_WHITE;
                else if (this.flourType.ToLower() == "wholegrain") caloriesPerGram *= MOD_FLOUR_WHOLEGRAIN;
                if (this.bakingTechnique.ToLower() == "crispy") caloriesPerGram *= MOD_BAKE_CRISPY;
                else if (this.bakingTechnique.ToLower() == "chewy") caloriesPerGram *= MOD_BAKE_CHEWY;
                else if (this.bakingTechnique.ToLower() == "homemade") caloriesPerGram *= MOD_BAKE_HOMEMADE;

                return caloriesPerGram;
            }
       }
        public double CalculateCalories()
        {
            return this.grams * this.CaloriesPerGram;
        }
    }
}
