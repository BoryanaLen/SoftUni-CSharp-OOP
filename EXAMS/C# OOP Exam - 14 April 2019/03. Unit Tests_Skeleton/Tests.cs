namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void ConstructowWorksCorrectly()
        {
            Phone phone = new Phone("make", "model");

            Assert.AreEqual("make", phone.Make);
            Assert.AreEqual("model", phone.Model);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreatePhoneWithNullOrEmptyMake(string make)
        {
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone(make, "model"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreatePhoneWithNullOrEmptyModel(string model)
        {
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone("make", model));
        }

        [Test]
        public void AddContactWithExistingName()
        {
            Phone phone = new Phone("make", "model");
            string name = "name";

            phone.AddContact(name, "phone");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact(name,"mod"));
        }

        [Test]
        public void AddContactWorksCorrectly()
        {
            Phone phone = new Phone("make", "model");
            string name = "name";

            phone.AddContact(name, "phone");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void CallContactNonExistingName()
        {
            Phone phone = new Phone("make", "model");
            string name = "name";

            phone.AddContact(name, "phone");

            Assert.Throws<InvalidOperationException>(() => phone.Call("newname"));
        }

        [Test]
        public void CallWorksCorrect()
        {
            Phone phone = new Phone("make", "model");
            string name = "name";
            string number = "number";

            phone.AddContact(name, number);

            string result = $"Calling {name} - {number}...";

            Assert.AreEqual(result, phone.Call(name));
        }
    }
}