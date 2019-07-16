using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods.Entities;

namespace WildFarm.Mammals
{
    public class Mouse : Mammal
    {
        protected override double increaseWeight { get; }

        protected override List<Type> FoodTypes { get; }

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.increaseWeight = 0.10;
            this.FoodTypes = new List<Type> {typeof(Vegetable), typeof(Fruit)};
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
