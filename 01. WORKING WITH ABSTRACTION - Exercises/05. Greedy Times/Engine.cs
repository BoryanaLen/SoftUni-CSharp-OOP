using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public  class Engine
    {
        private Dictionary<string, Dictionary<string, long>> bag;

        private long capacity;

        public Engine()
        {
            this.bag = new Dictionary<string, Dictionary<string, long>>()
            {
                { "Gold",new Dictionary<string, long>()},
                { "Gem", new Dictionary<string, long>()},
                { "Cash", new Dictionary<string, long>()}
            };
        }

        public void Run()
        {
            capacity = long.Parse(Console.ReadLine());

            string[] safe = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];

                long quantity = long.Parse(safe[i + 1]);

                string type = this.GetType(name);

                if (IsInRules(type,quantity))
                {
                    AddQuantity(name, type, quantity);
                }
            }

            this.Print();
           
        }

        private bool IsInRules(string type, long quantity)
        {
            bool result = false;

            long totalSum = bag.Values.Select(x => x.Values.Sum()).Sum();

            if (capacity >= (totalSum + quantity))
            {
                long currentGoldSum = bag["Gold"].Sum(x => x.Value);
                long currentGemSum = bag["Gem"].Sum(x => x.Value);
                long currentCashSum = bag["Cash"].Sum(x => x.Value);

                if (type == "Gold" && (currentGoldSum + quantity) >= currentGemSum && currentGemSum >= currentCashSum)
                {
                    result = true;
                }
                else if (type == "Gem" && currentGoldSum >= (currentGemSum + quantity) && (currentGemSum + quantity) >= currentCashSum)
                {
                    result = true;
                }
                else if (type == "Cash" && currentGoldSum >= currentGemSum && currentGemSum >= (currentCashSum + quantity))
                {
                    result = true;
                }
            }

            return result;
        }

        private void Print()
        {
            foreach (var item in bag)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                    foreach (var element in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                    {
                        Console.WriteLine($"##{element.Key} - {element.Value}");
                    }
                }
            }
        }

        private string GetType(string name)
        {
            string type = string.Empty;

            if (name.Length == 3)
            {
                type = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                type = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                type = "Gold";
            }

            return type;
        }

        private void AddQuantity(string name, string type, long quantity)
        {
            if (bag[type].ContainsKey(name))
            {
                bag[type][name] += quantity;
            }
            else
            {
                bag[type].Add(name, quantity);
            }
        }
    }
}
