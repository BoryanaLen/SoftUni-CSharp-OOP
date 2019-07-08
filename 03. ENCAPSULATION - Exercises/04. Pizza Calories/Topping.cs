using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> types = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8},
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private double weight;

        private string type;
        public string Type
        {
            get => this.type;
            set
            {
                if (!this.types.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public Topping(string type, double weight)
        {
            this.Type = type;

            this.Weight = weight;
        }

        public double CalculateCalories()
        {
            return this.types[Type.ToLower()] * this.Weight * 2;
        }
    }
}
