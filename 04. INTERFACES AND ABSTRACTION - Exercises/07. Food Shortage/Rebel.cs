using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel:IBuyer
    {
        private int age;

        private string group;

        public string Name { get; private set; }
        public int Food { get; private set; }

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.age = age;
            this.group = group;
            this.Food = 0;
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
