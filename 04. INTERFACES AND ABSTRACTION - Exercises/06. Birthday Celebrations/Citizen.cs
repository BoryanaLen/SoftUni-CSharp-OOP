using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentical
    {
        private string name;

        private int age;

        private string id;

        public string Birthdate { get; private set; }
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.Birthdate = birthdate;
        }
    }
}
