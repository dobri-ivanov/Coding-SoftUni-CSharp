namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private string fishName = "Nemo";

        private Aquarium aquarium;
        private string aquariumName = "TestName";
        private int aquariumCapacity = 3;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish(fishName);
            aquarium = new Aquarium(aquariumName, aquariumCapacity);
        }

        [Test]
        public void Test_Fish()
        {
            fish = new Fish(fishName);
            Assert.AreEqual(fishName, fish.Name);
        }
        [Test]
        public void Test_Fish2()
        {
            fish = new Fish(fishName);
            Assert.IsTrue(fish.Available);
        }
        [Test]
        public void Test_Aquarium_Const()
        {
            aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Assert.AreEqual(aquariumName, aquarium.Name);
        }
        [Test]
        public void Test_Aquarium_Const2()
        {
            aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Assert.AreEqual(aquariumCapacity, aquarium.Capacity);
        }
        [Test]
        public void Test_Aquarium_Const3()
        {
            aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Assert.AreEqual(0, aquarium.Count);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Test_Aquarium_Name(string name)
        {
            Assert.Catch<ArgumentNullException>(() => aquarium = new Aquarium(name, aquariumCapacity));
        }
        [TestCase("Test")]
        public void Test_Aquarium_Name2(string name)
        {
            aquarium = new Aquarium(name, aquariumCapacity);
            Assert.AreEqual(name, aquarium.Name);
        }
        [TestCase(-5)]
        public void Test_Aquarium_Capacity(int capacity)
        {
            Assert.Catch<ArgumentException>(() => aquarium = new Aquarium(aquariumName, capacity));
        }
        [TestCase(0)]
        public void Test_Aquarium_Capacity2(int capacity)
        {
            aquarium = new Aquarium(aquariumName, capacity);
            Assert.Pass();
        }
        [TestCase(5)]
        public void Test_Aquarium_Capacity3(int capacity)
        {
            aquarium = new Aquarium(aquariumName, capacity);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }
        [Test]
        public void Test_Aquarium_Add()
        {
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void Test_Aquarium_Add2()
        {
            aquarium.Add(fish);
            aquarium.Add(fish);
            aquarium.Add(fish);

            Assert.Catch<InvalidOperationException>(() => aquarium.Add(fish));
        }
        [Test]
        public void Test_Aquarium_Remove()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish(fishName);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void Test_Aquarium_Remove2()
        {
            Assert.Catch<InvalidOperationException>(() => aquarium.RemoveFish(fishName));
        }
        [Test]
        public void Test_Aquarium_Sell()
        {
            aquarium.Add(fish);
            Fish returnedFish = aquarium.SellFish(fishName);
            Assert.AreEqual(fish, returnedFish);
        }
        [Test]
        public void Test_Aquarium_Sell2()
        {
            aquarium.Add(fish);
            Fish returnedFish = aquarium.SellFish(fishName);
            Assert.AreEqual(false, fish.Available);
        }
        [Test]
        public void Test_Aquarium_Sell3()
        {
            Assert.Catch<InvalidOperationException>(() => aquarium.SellFish(fishName));
        }
        [Test]
        public void Test_Aquarium_Report()
        {
            aquarium.Add(fish);

            string excpected = $"Fish available at {aquarium.Name}: {fish.Name}";
            string returned = aquarium.Report();

            Assert.AreEqual(excpected, returned);
        }
    }
}
