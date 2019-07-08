using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            List<Product> products = new List<Product>();

            try
            {
                List<string> personsInfo = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int i = 0; i < personsInfo.Count; i++)
                {
                    List<string> currentPersonInfo = personsInfo[i]
                        .Split('=')
                        .ToList();

                    string personName = currentPersonInfo[0];
                    double personMoney = double.Parse(currentPersonInfo[1]);

                    persons.Add(new Person(personName, personMoney));
                }

                List<string> productsInfo = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int j = 0; j < productsInfo.Count; j++)
                {
                    List<string> currentProductInfo = productsInfo[j]
                        .Split('=')
                        .ToList();

                    string productName = currentProductInfo[0];
                    double productCost = double.Parse(currentProductInfo[1]);

                    products.Add(new Product(productName, productCost));
                }

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    List<string> commandInfo = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    string personName = commandInfo[0];
                    string productName = commandInfo[1];

                    Person foundPerson = persons.Where(x => x.Name == personName).FirstOrDefault();
                    Product foundProduct = products.Where(x => x.Name == productName).FirstOrDefault();

                    if (foundPerson != null && foundProduct != null)
                    {
                        foundPerson.AddProduct(foundProduct);
                    }
                }

                foreach(var person in persons)
                {
                    if (person.Products.Count > 0)
                    {
                        List<string> boughtProducts = person.Products.Select(x => x.Name).ToList();

                        Console.WriteLine($"{person.Name} - {string.Join(", ",boughtProducts)}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought ");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
