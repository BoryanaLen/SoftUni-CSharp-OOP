using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IPhoneCall, IPhoneBrowse
    {
        public List<string> Sites { get; private set; }

        public List<string> Numbers { get; private set; }

        public Smartphone(List<string> numbers, List<string> sites)
        {
            this.Numbers = numbers;
            this.Sites = sites;
        }

        public void Browse()
        {
            foreach (string site in this.Sites)
            {
                if (!site.Any(char.IsDigit))
                {
                    Console.WriteLine($"Browsing: {site}!");
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }

        public void Call()
        {
            foreach(string number in this.Numbers)
            {
                if (number.All(char.IsDigit))
                {
                    Console.WriteLine($"Calling... {number}");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}
