using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicles
{
    public class Engine
    {
        public void Run()
        {
            List<string> carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            double carFuelquantity = double.Parse(carInfo[1]);
            double carLiters = double.Parse(carInfo[2]);

            Car car = new Car(carFuelquantity, carLiters);

            List<string> truckInfo = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            double truckFuelquantity = double.Parse(truckInfo[1]);
            double truckLiters = double.Parse(truckInfo[2]);

            Truck truck = new Truck(truckFuelquantity, truckLiters);

            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                List<string> inputInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string commang = inputInfo[0];
                string type = inputInfo[1];

                if(commang == "Drive")
                {
                    double distance = double.Parse(inputInfo[2]);

                    if(type == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if(type == "Truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if(commang == "Refuel")
                {
                    double amountOfLiters = double.Parse(inputInfo[2]);

                    if (type == "Car")
                    {
                        car.Refuel(amountOfLiters);
                    }
                    else if (type == "Truck")
                    {
                        truck.Refuel(amountOfLiters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
