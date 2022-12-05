using NUnit.Framework;
using System;
using System.ComponentModel;

namespace PlanetWars.Tests
{[TestFixture]
    public class Tests
    {
        private Planet planet;
        private string planetName = "Planet";
        private double planetBudget = 1000;

        private Weapon weapon;
        private string weaponName = "WEAPON";
        private double weaponPrice = 5.55;
        private int weaponLevel = 2;

        [SetUp]
        public void SetUp()
        {
            weapon = new Weapon(weaponName, weaponPrice, weaponLevel);
            planet = new Planet(planetName, planetBudget);
        }
        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(planetName, planet.Name);
            Assert.AreEqual(planetBudget, planet.Budget);
            Assert.AreEqual(0 , planet.Weapons.Count);
            Assert.IsTrue(planet.Weapons != null);
        }
        [TestCase (null)]
        [TestCase ("")]
        public void Test_Name_Prop(string name)
        {
            Assert.Throws<ArgumentException>(() => planet = new Planet(name, 5));
        }
        [TestCase(-5)]
        public void Test_Budget_Prop(int budget)
        {
            Assert.Throws<ArgumentException>(() => planet = new Planet(planetName, budget));
        }
        [Test]
        public void Test_Profit()
        {
            planet.Profit(50);
            Assert.AreEqual(planetBudget + 50, planet.Budget);
        }
        [Test]
        public void Test_Spend()
        {
            planet.SpendFunds(50);
            Assert.AreEqual(planetBudget - 50, planet.Budget);
        }
        [Test]
        public void Test_Spend2()
        {
            Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(planetBudget + 1));
        }
        [Test]
        public void Test_Add()
        {
            planet.AddWeapon(weapon);
            Assert.AreEqual(1, planet.Weapons.Count);
        }
        [Test]
        public void Test_Add2()
        {
            planet.AddWeapon(weapon);
            Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
        }
        [Test]
        public void Test_Remove()
        {
            planet.AddWeapon(weapon);
            planet.RemoveWeapon(weaponName);
            Assert.AreEqual(0, planet.Weapons.Count);
        }
        [Test]
        public void Test_Remove2()
        {
            planet.RemoveWeapon(weaponName);
            Assert.AreEqual(0, planet.Weapons.Count);
        }
        [Test]
        public void Test_MilitaryPower()
        {
            planet.AddWeapon(weapon);
            Weapon weapon2 = new Weapon("asd", 0, 1);
            planet.AddWeapon(weapon2);
            Assert.AreEqual(weapon.DestructionLevel + weapon2.DestructionLevel, planet.MilitaryPowerRatio);
        }
        [Test]
        public void Test_Upgrade()
        {
            planet.AddWeapon(weapon);
            planet.UpgradeWeapon(weaponName);
            Assert.AreEqual(weaponLevel + 1, weapon.DestructionLevel);
        }
        [Test]
        public void Test_Upgrade2()
        {
            Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon(weaponName));
        }
        [Test]
        public void Test_Distruct()
        {
            planet.AddWeapon(weapon);
            Planet planet2 = new Planet("planet", 50);
            string result = planet.DestructOpponent(planet2);
            Assert.AreEqual($"{planet2.Name} is destructed!", result);
        }
        [Test]
        public void Test_Distruct2()
        {
            Planet planet2 = new Planet("planet", 50);
            Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet2));
        }
        [Test]
        public void Test_Distruct3()
        {
            Planet planet2 = new Planet("planet", 50);
            planet2.AddWeapon(weapon);
            Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet2));
        }
    }
}
