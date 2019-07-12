using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Engine
    {
        private List<IBuyer> citizensAndRebels;

        public Engine()
        {
            this.citizensAndRebels = new List<IBuyer>();
        }
        public void Run()
        {
            int numberLines = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberLines; i++)
            {
                List<string> inputInfo = Console.ReadLine()
                    .Split()
                    .ToList();

                if(inputInfo.Count == 4)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];
                    string birthdate = inputInfo[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    citizensAndRebels.Add(citizen);
                }
                else if(inputInfo.Count == 3)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string group = inputInfo[2];

                    Rebel rebel = new Rebel(name, age, group);
                    citizensAndRebels.Add(rebel);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if(name == "End")
                {
                    int totalPurchasedFood = citizensAndRebels.Select(x => x.Food).Sum();

                    Console.WriteLine(totalPurchasedFood);

                    break;
                }

                IBuyer buyer = citizensAndRebels.Where(x => x.Name == name).FirstOrDefault();

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
        }
    }
}
