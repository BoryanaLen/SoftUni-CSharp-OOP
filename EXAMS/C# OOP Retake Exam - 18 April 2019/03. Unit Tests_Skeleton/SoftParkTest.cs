namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark park;

        [SetUp]
        public void Setup()
        {
            park = new SoftPark();
        }

        [Test]
        public void ParkCarWhenParkSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => park.ParkCar("Z111", new Car("make", "number")));
        }

        [Test]
        public void ParkCarWhenParkingSpotIsNotFree()
        {
            park.ParkCar("A1", new Car("make", "number"));

            Assert.Throws<ArgumentException>(() => park.ParkCar("A1", new Car("make1", "number1")));
        }

        [Test]
        public void TryToParkCarAlreadyParked()
        {
            Car car = new Car("make", "number");

            park.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() => park.ParkCar("B1", car));
        }

        [Test]
        public void CarParkedCorrectly()
        {
            Car car = new Car("make", "number");
          
            string result = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(result, park.ParkCar("A1", car));
        }

        [Test]
        public void RemoveCarFromNonExistingSpot()
        {
            Car car = new Car("make", "number");

            Assert.Throws<ArgumentException>(() => park.RemoveCar("Z111", car));
        }

        [Test]
        public void RemoveDifferentCarFromExistingSpot()
        {
            Car car = new Car("make", "number");
            Car carToRemove = new Car("make1", "number1");

            park.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => park.RemoveCar("A1", carToRemove));
        }

        [Test]
        public void RemoveCarCorrect()
        {
            Car car = new Car("make", "number");

            park.ParkCar("A1", car);

            string result = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(result, park.RemoveCar("A1", car));
        }
    }
}