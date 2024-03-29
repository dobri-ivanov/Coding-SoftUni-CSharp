using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        Dummy dummy;
        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(10, 10);
        }
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }
        [Test]
        public void AxeCantAttackWhenBroken()
        {
            Axe axe = new Axe(0, 0);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));


        }
    }
}