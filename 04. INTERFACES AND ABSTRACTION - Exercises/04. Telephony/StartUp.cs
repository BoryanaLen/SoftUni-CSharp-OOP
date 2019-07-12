using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split()
                .ToList();

            List<string> sites = Console.ReadLine()
                .Split()
                .ToList();

            Smartphone phone = new Smartphone(numbers, sites);
            phone.Call();
            phone.Browse();
        }
    }
}
