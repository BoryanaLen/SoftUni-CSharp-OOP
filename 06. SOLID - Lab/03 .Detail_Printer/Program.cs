using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            var documents = new List<string> (){ "docimentOne", "documentTwo" };
            var tasks = new List<string>() { "taskOne", "taskTwo" };


            Employee manager = new Manager("Ivan", documents);
            Employee worker = new Worker("Dimitar", tasks);

            DetailsPrinter printer = new DetailsPrinter(new List<Employee>() { manager, worker });

            printer.PrintDetails();
        }
    }
}
