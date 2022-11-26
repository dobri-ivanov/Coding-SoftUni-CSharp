using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void IsCarConstructorWorkingProperlyTest()
            {
                string model = "Audi";
                int numberOfIssues = 5;

                Car car = new Car(model, numberOfIssues);
                Assert.AreEqual(model, car.CarModel);
            }
            [Test]
            public void IsCarConstructorWorkingProperlyTest2()
            {
                string model = "Audi";
                int numberOfIssues = 5;

                Car car = new Car(model, numberOfIssues);
                Assert.AreEqual(numberOfIssues, car.NumberOfIssues);
            }
            [Test]
            public void IsFixedPropertyWorkingProperlyTest()
            {
                string model = "Audi";
                int numberOfIssues = 5;

                Car car = new Car(model, numberOfIssues);
                Assert.AreEqual(false, car.IsFixed);
            }
            [Test]
            public void IsFixedPropertyWorkingProperlyTest2()
            {
                string model = "Audi";
                int numberOfIssues = 0;

                Car car = new Car(model, numberOfIssues);
                Assert.AreEqual(true, car.IsFixed);
            }
            [Test]
            public void IsGarageConstructorWorkingProperlyTest()
            {
                string name = "TestName";
                int mechanicsAvailable = 5;
                Garage garage = new Garage(name, mechanicsAvailable);
                Assert.AreEqual(name, garage.Name);
            }
            [Test]
            public void IsGarageConstructorWorkingProperlyTest2()
            {
                string name = "TestName";
                int mechanicsAvailable = 5;
                Garage garage = new Garage(name, mechanicsAvailable);
                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
            }
            [Test]
            public void IsGarageNamePropertyWorkingProperlyTest()
            {
                string name = null;
                int mechanicsAvailable = 5;
                Garage garage;
                Assert.Catch<ArgumentNullException>( () => garage = new Garage(name, mechanicsAvailable));
            }
            [Test]
            public void IsGarageNamePropertyWorkingProperlyTest2()
            {
                string name = "";
                int mechanicsAvailable = 5;
                Garage garage;
                Assert.Catch<ArgumentNullException>(() => garage = new Garage(name, mechanicsAvailable));
            }
            [Test]
            public void IsGarageMechanicsAvailablePropertyWorkingProperlyTest()
            {
                string name = "TestName";
                int mechanicsAvailable = -5;
                Garage garage;
                Assert.Catch<ArgumentException>(() => garage = new Garage(name, mechanicsAvailable));
            }
            [Test]
            public void IsGarageMechanicsAvailablePropertyWorkingProperlyTest2()
            {
                string name = "TestName";
                int mechanicsAvailable = 0;
                Garage garage;
                Assert.Catch<ArgumentException>(() => garage = new Garage(name, mechanicsAvailable));
            }
            [Test]
            public void IsGarageCarsInGaragePropertyWorkingProperlyTest()
            {
                Garage garage = new Garage("TestName", 5);
                int carsAdded = 3;
                for (int i = 1; i <= carsAdded; i++)
                {
                    Car car = new Car("TestModel", 2);
                    garage.AddCar(car);
                }
                Assert.AreEqual(carsAdded, garage.CarsInGarage);
            }
            [Test]
            public void IsGarageAddCarMethodWorkingProperlyTest()
            {
                Garage garage = new Garage("TestName", 1);
                
                Car car = new Car("SpecialCar", 5);
                Car car2 = new Car("SpecialCar2", 1);

                garage.AddCar(car);
                Assert.Catch<InvalidOperationException>(() => garage.AddCar(car2));
            }
            [Test]
            public void IsGarageFixCarMethodWorkingProperlyTest()
            {
                Garage garage = new Garage("TestName", 1);
                Assert.Catch<InvalidOperationException>(() => garage.FixCar("Unknown"));
            }
            [Test]
            public void IsGarageFixCarMethodWorkingProperlyTest2()
            {
                Garage garage = new Garage("TestName", 1);
                string carModel = "Audi";
                int carIssues = 3;
                Car car = new Car(carModel, carIssues);
                garage.AddCar(car);
                garage.FixCar(carModel);
                Assert.AreEqual(0, car.NumberOfIssues);
            }
            [Test]
            public void IsGarageFixCarMethodWorkingProperlyTest3()
            {
                Garage garage = new Garage("TestName", 1);
                string carModel = "Audi";
                int carIssues = 3;
                Car car = new Car(carModel, carIssues);
                garage.AddCar(car);
                Car fixedCar = garage.FixCar(carModel);
                Assert.AreEqual(car, fixedCar);
            }
            [Test]
            public void IsGarageRemoveFixedCarMethodWorkingProperlyTest3()
            {
                Garage garage = new Garage("TestName", 1);
                string carModel = "Audi";
                int carIssues = 3;
                Car car = new Car(carModel, carIssues);
                garage.AddCar(car);
                Assert.Catch<InvalidOperationException>(() => garage.RemoveFixedCar());
            }
            [Test]
            public void IsGarageRemoveFixedCarMethodWorkingProperlyTest4()
            {
                Garage garage = new Garage("TestName", 1);
                string carModel = "Audi";
                int carIssues = 3;
                Car car = new Car(carModel, carIssues);
                garage.AddCar(car);
                garage.FixCar(carModel);
                garage.RemoveFixedCar();
                Assert.AreEqual(0, garage.CarsInGarage);
            }
            [Test]
            public void IsGarageRemoveFixedCarMethodWorkingProperlyTest5()
            {
                Garage garage = new Garage("TestName", 5);
                string carModel = "Audi";
                int carIssues = 3;
                Car car = new Car(carModel, carIssues);
                garage.AddCar(car);

                string carModel2 = "BMW";
                Car car2 = new Car(carModel2, carIssues + 1);
                garage.AddCar(car2);

                garage.FixCar(carModel);
                garage.RemoveFixedCar();
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void IsGarageRemoveFixedCarMethodWorkingProperlyTest6()
            {
                Garage garage = new Garage("TestName", 5);
                string carModel = "Audi";
                int carIssues = 3;
                Car car = new Car(carModel, carIssues);
                garage.AddCar(car);

                string carModel2 = "BMW";
                Car car2 = new Car(carModel2, carIssues + 1);
                garage.AddCar(car2);

                garage.FixCar(carModel);
                garage.FixCar(carModel2);
                garage.RemoveFixedCar();
                Assert.AreEqual(0, garage.CarsInGarage);
            }
        }
    }
}