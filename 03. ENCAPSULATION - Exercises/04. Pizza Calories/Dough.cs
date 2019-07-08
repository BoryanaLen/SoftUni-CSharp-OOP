

using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private double weight;

        private Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
            {
                {"crispy", 0.9 },
                {"chewy", 1.1 },
                {"homemade", 1.0 }
            };

        private Dictionary<string, double> flourTypes = new Dictionary<string, double>()
            {
                {"white", 1.5 },
                {"wholegrain", 1.0 }
            };

        private string bakingTechnique;

        private string flourType;

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!this.flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!this.bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;

            this.BakingTechnique = bakingTechnique;

            this.Weight = weight;
        }


        public double CalculateCalories()
        {
            return this.weight * this.flourTypes[FlourType.ToLower()] * this.bakingTechniques[BakingTechnique.ToLower()] * 2;
        }
    }
}
