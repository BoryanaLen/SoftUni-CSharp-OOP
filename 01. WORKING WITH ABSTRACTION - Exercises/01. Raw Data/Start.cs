using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class Start
    {
        private List<Car> cars;

        public Start()
        {
            cars = new List<Car>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string [] parameters = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car newCar =  this.CreateCar(parameters);

                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(flamable);
            }
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            double firstTirePressure = double.Parse(parameters[5]);
            int firstTireAge = int.Parse(parameters[6]);
            Tyre firstTyre = new Tyre(firstTirePressure, firstTireAge);

            double secondTirePressure = double.Parse(parameters[7]);
            int secondTireAge = int.Parse(parameters[8]);
            Tyre secondTyre = new Tyre(secondTirePressure,secondTireAge);

            double thirdTirePressure = double.Parse(parameters[9]);
            int thirdTireAge = int.Parse(parameters[10]);
            Tyre thirdTyre = new Tyre(thirdTirePressure, thirdTireAge); ;

            double fourthTirePressure = double.Parse(parameters[11]);
            int fourthTireAge = int.Parse(parameters[12]);
            Tyre fourthTyre = new Tyre(fourthTirePressure, fourthTireAge);

            Car newCar = new Car(model, engine, cargo, firstTyre,secondTyre,thirdTyre,fourthTyre);

            return newCar;
        }

        private void PrintInfo(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
