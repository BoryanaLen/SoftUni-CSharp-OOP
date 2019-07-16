using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get;  }
        int FoodEaten { get; }
        string AskForFood();
        void Eat(IFood food);
    }
}
