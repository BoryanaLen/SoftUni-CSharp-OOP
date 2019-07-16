using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods.Entities;

namespace WildFarm.Mammals
{
    public class Tiger : Feline
    {
        protected override double increaseWeight { get; }

        protected override List<Type> FoodTypes { get; }

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.increaseWeight = 1;
            this.FoodTypes = this.FoodTypes = new List<Type> { typeof(Meat)};
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
