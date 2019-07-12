using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IIdentical
    {
        private string name;

        public string Birthdate { get; private set; }

        public Pet(string name, string birthdate)
        {
            this.name = name;
            this.Birthdate = birthdate;
        }
    }
}
