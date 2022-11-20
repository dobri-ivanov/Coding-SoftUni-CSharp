using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthAfterAttack()
        {
            Dummy dummy = new Dummy(10, 10);
            int attackPoints = 5;
            dummy.TakeAttack(attackPoints);
            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void ThrowsExeptionWhenDeadDummyIsAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
            int attackPoints = 5;
            
            try
            {
                dummy.TakeAttack(attackPoints);
            }
            catch (InvalidOperationException)
            {
                Assert.AreEqual(0, dummy.Health);
            }
        }
        [Test]
        public void DeadDummyCanGiveXp()
        {
            Dummy dummy = new Dummy(2, 10);
            try
            {
                dummy.GiveExperience();
            }
            catch (InvalidOperationException)
            {
                Assert.AreEqual(0, dummy.Health);
            }
        }
    }
}