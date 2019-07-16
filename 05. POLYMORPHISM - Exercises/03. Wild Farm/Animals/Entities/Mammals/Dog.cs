using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods.Entities;

namespace WildFarm.Mammals
{
    public class Dog : Mammal
    {
        protected override double increaseWeight { get; }

        protected override List<Type> FoodTypes { get; }

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.increaseWeight = 0.40;
            this.FoodTypes = this.FoodTypes = new List<Type> { typeof(Meat)};
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
