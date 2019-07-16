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
            List<string> vehicleInfo = Console.ReadLine().Split().ToList();
            double carFuelQuantity = double.Parse(vehicleInfo[1]);
            double carFuelConsumtion = double.Parse(vehicleInfo[2]);
            double carTankCapacity = double.Parse(vehicleInfo[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumtion, carTankCapacity);

            vehicleInfo = Console.ReadLine().Split().ToList();
            double truckFuelQuantity = double.Parse(vehicleInfo[1]);
            double truckFuelConsumtion = double.Parse(vehicleInfo[2]);
            double truckTankCapacity = double.Parse(vehicleInfo[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumtion, truckTankCapacity);

            vehicleInfo = Console.ReadLine().Split().ToList();
            double busFuelQuantity = double.Parse(vehicleInfo[1]);
            double busFuelConsumtion = double.Parse(vehicleInfo[2]);
            double busTankCapacity = double.Parse(vehicleInfo[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumtion, busTankCapacity);

            int numberCommands = int.Parse(Console.ReadLine());

            for (int j = 0; j < numberCommands; j++)
            {
                try
                {
                    List<string> inputInfo = Console.ReadLine().Split().ToList();

                    string command = inputInfo[0];

                    string type = inputInfo[1];

                    double value = double.Parse(inputInfo[2]);

                    if(type == "Car")
                    {
                        ExecuteCommand(command, value, car);
                    }
                    else if(type == "Truck")
                    {
                        ExecuteCommand(command, value, truck);
                    }
                    else if(type == "Bus")
                    {
                        ExecuteCommand(command, value, bus);
                    }
                    
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);

                    continue;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }

        private void ExecuteCommand(string command, double value, Vehicle vehicle)
        {
            if(command == "Drive")
            {
                vehicle.Drive(value);
            }
            else if(command == "Refuel")
            {
                vehicle.Refuel(value);
            }
            else if(command == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(value);
            }
        }
    }
}
