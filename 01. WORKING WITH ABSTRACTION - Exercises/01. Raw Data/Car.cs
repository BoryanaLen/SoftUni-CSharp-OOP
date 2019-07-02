using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyre []  Tires  { get; set; }

        public Car(string model, Engine engine, Cargo cargo,params Tyre[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
    }
}
