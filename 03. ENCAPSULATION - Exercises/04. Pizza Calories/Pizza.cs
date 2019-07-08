

using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        private List<Topping> toppings;

        private Dough dough;

        public string Name
        {
            get => this.name;

            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public int numberOfToppings => this.toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (this.numberOfToppings == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
 
            this.toppings.Add(topping);
        }

        public double TotalCalories()
        {
            double totalCaloriesDough = this.dough.CalculateCalories();

            double totalCaloriesToppings = toppings.Select(x => x.CalculateCalories()).Sum();

            return totalCaloriesDough + totalCaloriesToppings;
        }
    }
}
