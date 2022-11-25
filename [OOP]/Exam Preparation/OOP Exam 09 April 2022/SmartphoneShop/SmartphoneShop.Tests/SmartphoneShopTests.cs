using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Smartphone_Constructor_Test_1()
        {
            string model = "Nokia";
            int maximumBatteryCharge = 95;
            Smartphone smartphone = new Smartphone(model, maximumBatteryCharge);
            Assert.AreEqual(model, smartphone.ModelName);
        }
        [Test]
        public void Smartphone_Constructor_Test_2()
        {
            string model = "Nokia";
            int maximumBatteryCharge = 95;
            Smartphone smartphone = new Smartphone(model, maximumBatteryCharge);
            Assert.AreEqual(maximumBatteryCharge, smartphone.MaximumBatteryCharge);
        }
        [Test]
        public void Smartphone_Constructor_Test_3()
        {
            string model = "Nokia";
            int maximumBatteryCharge = 95;
            Smartphone smartphone = new Smartphone(model, maximumBatteryCharge);
            Assert.AreEqual(maximumBatteryCharge, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void Shop_Constructor_Test_1()
        {
            int shopCapacity = 5;
            Shop shop = new Shop(shopCapacity);
            Assert.AreEqual(shopCapacity, shop.Capacity);
        }
        [Test]
        public void Shop_Capacity_Propery_Test_1()
        {
            int shopCapacity = -4;
            Shop shop;
            Assert.Catch<ArgumentException>(() => shop = new Shop(shopCapacity));
        }
        [Test]
        public void Shop_Count_Property_Test_1()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);
            int capacity = 2;
            Shop shop = new Shop(capacity);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void Shop_Add_Phone_Method_Test_1()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 2;
            Shop shop = new Shop(capacity);
            shop.Add(smartphone);
            Assert.Catch<InvalidOperationException>(() => shop.Add(smartphone));
        }
        [Test]
        public void Shop_Add_Phone_Method_Test_2()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);
            Smartphone smartphone2 = new Smartphone(model, batteryCharge + 1);

            int capacity = 1;
            Shop shop = new Shop(capacity);
            shop.Add(smartphone);
            Assert.Catch<InvalidOperationException>(() => shop.Add(smartphone2));
        }
        [Test]
        public void Shop_Add_Phone_Method_Test_3()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 1;
            Shop shop = new Shop(capacity);
            shop.Add(smartphone);
            Assert.Pass();
        }
        [Test]
        public void Shop_Remove_Phone_Method_Test_1()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);
            int capacity = 6;
            Shop shop = new Shop(capacity);
            Assert.Catch<InvalidOperationException>(() => shop.Remove(model));
        }
        [Test]
        public void Shop_Remove_Phone_Method_Test_2()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);
            int capacity = 6;
            Shop shop = new Shop(capacity);
            shop.Add(smartphone);
            shop.Remove(model);
            Assert.Pass();
        }
        [Test]
        public void Shop_Remove_Phone_Method_Test_3()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);
            Smartphone smartphone2 = new Smartphone("Unknown", batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);
            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.Remove(model);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void Shop_Remove_Phone_Method_Test_4()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);
            shop.Add(smartphone);
            shop.Remove(model);
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void Shop_Test_Phone_Method_Test_1()
        {
            string model = "Iphone";
            int batteryCharge = 98;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);

            Assert.Catch<InvalidOperationException>(() => shop.TestPhone(model, 50));
        }
        [Test]
        public void Shop_Test_Phone_Method_Test_2()
        {
            string model = "Iphone";
            int batteryCharge = 50;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);
            int batteryUsage = 80;
            Assert.Catch<InvalidOperationException>(() => shop.TestPhone(model, batteryUsage));
        }
        [Test]
        public void Shop_Test_Phone_Method_Test_3()
        {
            string model = "Iphone";
            int batteryCharge = 90;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);
            int batteryUsage = 80;
            shop.Add(smartphone);
            shop.TestPhone(model, batteryUsage);
            Assert.Pass();
        }
        [Test]
        public void Shop_Test_Phone_Method_Test_4()
        {
            string model = "Iphone";
            int batteryCharge = 90;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);
            int batteryUsage = 30;
            shop.Add(smartphone);
            shop.TestPhone(model, batteryUsage);
            Assert.AreEqual(batteryCharge - batteryUsage, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void Shop_Charge_Phone_Method_Test_1()
        {
            string model = "Iphone";
            int batteryCharge = 90;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);

            Assert.Catch<InvalidOperationException>(() => shop.ChargePhone(model));
        }
        [Test]
        public void Shop_Charge_Phone_Method_Test_2()
        {
            string model = "Iphone";
            int batteryCharge = 90;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);

            shop.Add(smartphone);
            shop.ChargePhone(model);
            Assert.Pass();
        }
        [Test]
        public void Shop_Charge_Phone_Method_Test_3()
        {
            string model = "Iphone";
            int batteryCharge = 90;
            Smartphone smartphone = new Smartphone(model, batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);

            shop.Add(smartphone);
            shop.ChargePhone(model);
            Assert.AreEqual(batteryCharge, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void Shop_Charge_Phone_Method_Test_4()
        {
            string model = "Iphone";
            int batteryCharge = 90;
            Smartphone smartphone = new Smartphone(model, batteryCharge);
            Smartphone smartphone2 = new Smartphone("Unknown", batteryCharge);

            int capacity = 6;
            Shop shop = new Shop(capacity);

            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.ChargePhone(model);
            Assert.AreEqual(batteryCharge, smartphone.CurrentBateryCharge);
        }
    }
}