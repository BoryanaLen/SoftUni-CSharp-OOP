

using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        private double money;

        public List<Product> Products { get; private set; }

        public double Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }


        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                Products.Add(product);
                Console.WriteLine($"{this.name} bought {product.Name}");
                this.Money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}
