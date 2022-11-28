using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private const string DEF_ATHLETE_NAME = "Test athlete name";
        private const string DEF_GYM_NAME = "Test gym name";
        private const int DEF_GYM_SIZE = 2;

        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void Setup()
        {
            athlete = new Athlete(DEF_ATHLETE_NAME);
            gym = new Gym(DEF_GYM_NAME, DEF_GYM_SIZE);
            gym.AddAthlete(athlete);
        }
        [Test]
        public void AtleteConstructorTest1()
        {
            string name = "TestName";
            Athlete athlete = new Athlete(name);
            Assert.AreEqual(name, athlete.FullName);
        }
        [Test]
        public void AtleteConstructorTest2()
        {
            string name = "TestName";
            Athlete athlete = new Athlete(name);
            Assert.AreEqual(false, athlete.IsInjured);
        }
        [Test]
        public void GymConstructorTest1()
        {
            string name = "TestName";
            int size = 5;
            Gym gym = new Gym(name, size);
            Assert.AreEqual(name, gym.Name);
        }
        [Test]
        public void GymConstructorTest2()
        {
            string name = "TestName";
            int size = 5;
            Gym gym = new Gym(name, size);
            Assert.AreEqual(size, gym.Capacity);
        }
        [Test]
        public void GymConstructorTest3()
        {
            string name = "TestName";
            int size = 5;
            Gym gym = new Gym(name, size);
            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            Assert.Pass();
        }
        [Test]
        public void GymNamePropertyTest1()
        {
            string name = null;
            int size = 5;
            Gym gym;
           Assert.Catch<ArgumentNullException>(() => gym = new Gym(name, size));
        }
        [Test]
        public void GymNamePropertyTest2()
        {
            string name = "";
            int size = 5;
            Gym gym;
            Assert.Catch<ArgumentNullException>(() => gym = new Gym(name, size));
        }
        [Test]
        public void GymNamePropertyTest3()
        {
            string name = "Test";
            int size = 5;
            Gym gym = new Gym(name, size);
            Assert.Pass();
        }
        [Test]
        public void GymCapacityPropertyTest1()
        {
            string name = "TestName";
            int size = -5;
            Gym gym;
            Assert.Catch<ArgumentException>(() => gym = new Gym(name, size));
        }
        [Test]
        public void GymCapacityPropertyTest2()
        {
            string name = "TestName";
            int size = 0;
            Gym gym = new Gym(name, size);
            Assert.Pass();
        }
        [Test]
        public void GymCapacityPropertyTest3()
        {
            string name = "TestName";
            int size = 5;
            Gym gym = new Gym(name, size);
            Assert.Pass();
        }
        [Test]
        public void GymCountPropertyTest1()
        {
            string name = "TestName";
            int size = 5;
            Gym gym = new Gym(name, size);
            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void GymCountPropertyTest2()
        {
            string name = "TestName";
            int size = 5;
            Gym gym = new Gym(name, size);
            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void GymAddAthleteMethodTest1()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);
            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            Assert.Catch<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }
        [Test]
        public void GymRemoveMethodTest1()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);
            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            Assert.Catch<InvalidOperationException>(() => gym.RemoveAthlete(athleteName));
        }
        [Test]
        public void GymRemoveMethodTest2()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);
            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            gym.RemoveAthlete(athleteName);
            Assert.Pass();
        }
        [Test]
        public void GymRemoveMethodTest3()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);
            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            gym.RemoveAthlete(athleteName);
            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void GymRemoveMethodTest4()
        {
            string name = "TestName";
            int size = 5;
            Gym gym = new Gym(name, size);
            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            gym.RemoveAthlete(athleteName);
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void GymInjureMethodTest1()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);

            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);

            gym.AddAthlete(athlete);
            gym.InjureAthlete(athleteName);
            Assert.AreEqual(true, athlete.IsInjured);
        }
        [Test]
        public void GymInjureMethodTest2()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);

            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);

            gym.AddAthlete(athlete);
            gym.InjureAthlete(athleteName);
            Assert.Pass();
        }
        [Test]
        public void GymInjureMethodTest3()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);

            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);

            Assert.Catch<InvalidOperationException>(() => gym.InjureAthlete(athleteName));
        }
        [Test]
        public void GymReportMethodTest1()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);

            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            string result = gym.Report();
            Assert.AreNotEqual(null, result);
        }
        [Test]
        public void GymReportMethodTest2()
        {
            string name = "TestName";
            int size = 1;
            Gym gym = new Gym(name, size);

            string athleteName = "TestName";
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            string result = gym.Report();
            Assert.Pass(result);
        }
        [Test]
        public void Gym_Report_ReturnsCorrectInfo()
        {
            Athlete athlete2 = new Athlete("Token name");
            List<Athlete> athletes = new List<Athlete>() { athlete, athlete2 };
            gym.AddAthlete(athlete2);
            gym.InjureAthlete(athlete2.FullName);
            string expectedString = $"Active athletes at {DEF_GYM_NAME}: {string.Join(", ", athletes.Where(x => !x.IsInjured).Select(x => x.FullName))}";
            Assert.AreEqual(expectedString, gym.Report());
        }
    }
}
