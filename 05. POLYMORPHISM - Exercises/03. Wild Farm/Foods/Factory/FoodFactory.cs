using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods.Entities;

namespace WildFarm.Foods.Factory
{
    public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            IFood food = null;

            if(type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }

            return food;
        }
    }
}
