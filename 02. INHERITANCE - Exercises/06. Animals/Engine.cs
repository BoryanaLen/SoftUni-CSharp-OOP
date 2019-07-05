using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                string type = Console.ReadLine();

                if (type == "Beast!")
                {
                    break;
                }

                List<string> animalInformation = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                Animal animal = null;

                if (IsValidInput(animalInformation, type))
                {
                    string name = animalInformation[0];
                    int age = int.Parse(animalInformation[1]);
                    string gender = null;
                    if (animalInformation.Count == 3)
                    {
                       gender = animalInformation[2];
                    }

                    animal = CreateAnimal(name, age, gender, type);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (animal != null)
                {
                    Console.WriteLine(animal);
                }
            }
        }

        public bool IsValidInput(List<string> animalInformation, string type)
        {
            if (animalInformation.Count < 2)
            {
                return false;
            }

            string name = animalInformation[0];

            if (int.TryParse(animalInformation[1], out int result))
            {
                if (result < 0)
                {
                    return false;
                }
            }

            if(animalInformation.Count == 2)
            {
                if (type == "Kitten" || type == "Tomcat")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            string gender = animalInformation[2];

            if(gender == "Male" || gender == "Female")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Animal CreateAnimal(string name, int age, string gender, string type)
        {
            Animal animal = null;

            if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }

            return animal;
        }
    }
}
