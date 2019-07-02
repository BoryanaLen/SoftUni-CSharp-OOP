namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public StudentSystem()
        {
            this.repo = new Dictionary<string, Student>();
        }

        public void Create(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            if (!repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                repo[name] = student;
            }
        }

        public void Show(string[] args)
        {
            var name = args[1];
            if (repo.ContainsKey(name))
            {
                var student = repo[name];
                string view = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    view += " Excellent student.";
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    view += " Average student.";
                }
                else
                {
                    view += " Very nice person.";
                }

                Console.WriteLine(view);
            }
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                this.Create(args);
            }
            else if (args[0] == "Show")
            {
                this.Show(args);
            }
            else if (args[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }

    public class Student
    {
        public double Grade { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
    }
}