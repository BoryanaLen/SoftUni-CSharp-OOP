using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public abstract class Person
    {
        private int age;

        private string name;

        public int Age
        {
            get { return this.age; }
            set
            {
                if (age < 0)
                {
                    throw new ArgumentNullException("Negative Age!");
                }

                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Empty Name!");
                }
                
                name = value;
            }
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString();

        }
    }
}
