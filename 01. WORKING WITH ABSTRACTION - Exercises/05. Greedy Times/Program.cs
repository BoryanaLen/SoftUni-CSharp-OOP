using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());

            string[] safe = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            bag.Add("Gold", new Dictionary<string, long>());
            bag.Add("Gem", new Dictionary<string, long>());
            bag.Add("Cash", new Dictionary<string, long>());

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];

                long quantity = long.Parse(safe[i + 1]);

                string type = GetType(name);


                if (type == "")
                {
                    continue;
                }

                long totalSum = bag.Values.Select(x => x.Values.Sum()).Sum();

                if (capacity >= (totalSum + quantity))
                {
                    long currentGoldSum = bag["Gold"].Sum(x => x.Value);
                    long currentGemSum = bag["Gem"].Sum(x => x.Value);
                    long currentCashSum = bag["Cash"].Sum(x => x.Value);

                    if (type == "Gold" && (currentGoldSum+quantity)>=currentGemSum && currentGemSum >= currentCashSum)
                    {
                        bag = AddQuantity(bag, type, name, quantity);
                    }
                    else if (type == "Gem" && currentGoldSum >= (currentGemSum + quantity)  && (currentGemSum + quantity) >= currentCashSum)
                    {
                        bag = AddQuantity(bag, type, name, quantity);
                    }
                    else if (type == "Cash" && currentGoldSum >= currentGemSum && currentGemSum >= (currentCashSum + quantity))
                    {
                        bag = AddQuantity(bag, type, name, quantity);
                    }

                }

            }

            foreach (var x in bag)
            {
                if (x.Value.Count > 0)
                {
                    Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                    foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                    {
                        Console.WriteLine($"##{item2.Key} - {item2.Value}");
                    }
                }
            }
        }

        public static string GetType(string name)
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

        public static Dictionary<string, Dictionary<string, long>> AddQuantity(Dictionary<string, Dictionary<string, long>> bag,
            string type, string name, long quantity)
        {
            if (bag[type].ContainsKey(name))
            {
                bag[type][name] += quantity;
            }
            else
            {
                bag[type].Add(name, quantity);
            }

            return bag;
        }
    }
}