using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> pizzaNameInfo = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                string pizzaName = pizzaNameInfo[1];

                List<string> inputInfoDough = Console.ReadLine()
                        .Split(' ')
                        .ToList();

                string flourType = inputInfoDough[1];
                string bakingTechnique = inputInfoDough[2];
                double flourWeight = double.Parse(inputInfoDough[3]);

                Dough dough = new Dough(flourType, bakingTechnique, flourWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string input = Console.ReadLine();

                    if(input == "END")
                    {
                        break;
                    }

                    List<string> inputInfoTopping = input
                        .Split(' ')
                        .ToList();

                    string toppingType = inputInfoTopping[1];
                    double toppingWeight = double.Parse(inputInfoTopping[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
