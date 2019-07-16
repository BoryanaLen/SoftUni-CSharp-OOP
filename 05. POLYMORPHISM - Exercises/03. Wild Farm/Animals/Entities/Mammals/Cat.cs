using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods.Entities;

namespace WildFarm.Mammals
{
    public class Cat : Feline
    {
        protected override double increaseWeight { get; }

        protected override List<Type> FoodTypes { get; }

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.increaseWeight = 0.30;
            this.FoodTypes = this.FoodTypes = new List<Type> { typeof(Meat), typeof(Vegetable)};
        }

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
