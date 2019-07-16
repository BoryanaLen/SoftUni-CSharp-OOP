using System;
using System.Collections.Generic;
using WildFarm.Exceptions;
using WildFarm.Foods;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        public string Name{ get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract double increaseWeight { get; }

        protected abstract List<Type> FoodTypes { get; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public abstract string AskForFood();

        public void Eat(IFood food)
        {
            if (this.FoodTypes.Contains(food.GetType()))
            {
                this.Weight += food.Quantity * increaseWeight;

                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFoodTypeException,
                    this.GetType().Name, food.GetType().Name));
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
