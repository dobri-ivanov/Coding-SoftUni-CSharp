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

            Assert.Catch<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
        }
        [Test]
        public void DeadDummyCanGiveXp()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.AreEqual(true, dummy.IsDead());
        }

        [Test]
        public void AliveDummyCantGiveXp()
        {
            Dummy dummy = new Dummy(2, 10);
            Assert.Catch<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}