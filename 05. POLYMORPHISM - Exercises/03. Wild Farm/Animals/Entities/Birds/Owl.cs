using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;
using WildFarm.Foods.Entities;

namespace WildFarm
{
    public class Owl : Bird
    {
        protected override double increaseWeight { get; }

        protected override List<Type> FoodTypes { get; }

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.FoodTypes = new List<Type> { typeof(Meat) };

            this.increaseWeight = 0.25;
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
