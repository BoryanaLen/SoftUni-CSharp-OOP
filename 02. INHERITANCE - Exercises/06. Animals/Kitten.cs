using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string kittenGender = "Female";
        public Kitten(string name, int age) : base(name, age, kittenGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
