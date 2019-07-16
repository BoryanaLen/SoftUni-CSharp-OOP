using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Birds;
using WildFarm.Foods;
using WildFarm.Foods.Factory;
using WildFarm.Mammals;

namespace WildFarm
{
    public class Engine
    {
        private List<Animal> animals;

        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<Animal>();

            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "End")
                    {
                        break;
                    }

                    Animal currentAnimal = GetAnimal(input);

                    animals.Add(currentAnimal);

                    string foodInput = Console.ReadLine();

                    IFood food = GetFood(foodInput);

                    Console.WriteLine(currentAnimal.AskForFood());

                    currentAnimal.Eat(food);
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    continue;
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private IFood GetFood(string foodInput)
        {
            List<string> inputInfo = foodInput.Split().ToList();

            string foodType = inputInfo[0];

            int quantity = int.Parse(inputInfo[1]);

            IFood food = this.foodFactory.ProduceFood(foodType, quantity);

            return food;
        }

        private Animal GetAnimal(string input)
        {
            Animal currentAnimal = null;

            List<string> inputInfo = input.Split().ToList();

            string type = inputInfo[0];

            string name = inputInfo[1];

            double weight = double.Parse(inputInfo[2]);

            if (type == "Cat" || type == "Tiger")
            {
                string livingRegion = inputInfo[3];

                string breed = inputInfo[4];

                if (type == "Cat")
                {
                    currentAnimal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    currentAnimal = new Tiger(name, weight, livingRegion, breed);
                }
            }
            else if (type == "Hen" || type == "Owl")
            {
                double wingSize = double.Parse(inputInfo[3]);

                if (type == "Hen")
                {
                    currentAnimal = new Hen(name, weight, wingSize);
                }
                else if (type == "Owl")
                {
                    currentAnimal = new Owl(name, weight, wingSize);
                }
            }
            else if (type == "Mouse" || type == "Dog")
            {
                string livingRegion = inputInfo[3];

                if (type == "Mouse")
                {
                    currentAnimal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    currentAnimal = new Dog(name, weight, livingRegion);
                }
            }

            return currentAnimal;
        }
    }
}
