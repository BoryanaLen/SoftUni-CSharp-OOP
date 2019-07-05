using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    enum Gender { Male, Female }

    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        private Gender Gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = (Gender)Enum.Parse<Gender>(gender);
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(this.ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
