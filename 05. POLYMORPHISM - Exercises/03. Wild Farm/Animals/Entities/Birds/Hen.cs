using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods.Entities;

namespace WildFarm.Birds
{
    public class Hen : Bird
    {
        protected override double increaseWeight { get; }
        protected override List<Type> FoodTypes { get; }

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.increaseWeight = 0.35;
            this.FoodTypes = this.FoodTypes = new List<Type> { typeof(Meat), typeof(Vegetable),
                typeof(Fruit), typeof(Seeds) };
        }

        public override string AskForFood()
        {
           return "Cluck";
        }
    }
}
