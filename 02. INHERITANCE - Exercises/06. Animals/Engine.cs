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
                 try
                 {
                    string type = Console.ReadLine();

                    if (type == "Beast!")
                    {
                        break;
                    }

                    List<string> animalInformation = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                    string name = animalInformation[0];
                    int age = int.Parse(animalInformation[1]);
                    string gender = animalInformation[2];

                    if (type == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                    }
                    else if (type == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                    }
                    else if (type == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                    }
                    else if (type == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(kitten);
                    }
                    else if (type == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat);
                    }

                }
                 catch (Exception exeption)
                 {
                    Console.WriteLine(exeption.Message);
                    continue;
                 }
             }
        }               
    }
}
