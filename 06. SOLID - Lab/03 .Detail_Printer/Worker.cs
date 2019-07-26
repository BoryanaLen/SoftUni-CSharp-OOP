using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public class Worker : Employee
    {
        public Worker(string name, ICollection<string> tasks) : base(name)
        {
            this.Tasks = new List<string>(tasks);
        }

        public IReadOnlyCollection<string> Tasks { get; set; }

        public override void PrintDetails()
        {
            base.PrintDetails();

            Console.WriteLine(string.Join(Environment.NewLine, this.Tasks));
        }
    }
}
