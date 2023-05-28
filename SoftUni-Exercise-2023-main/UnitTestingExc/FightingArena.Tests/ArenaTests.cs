namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldInitializeValues()
        {
            var arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorsIfTheyDontAlreadyExist()
        {
            var arena = new Arena();
            var warrior = new Warrior("Mitko", 50, 50);
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
            bool isContained = arena.Warriors.Contains(warrior);
            Assert.IsTrue(isContained);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidAttacker()
        {
            var arena = new Arena();

            var myWarrior = new Warrior("Mitko", 50, 50);
            var enemyWarrior = new Warrior("Gosho", 50, 50);

            arena.Enroll(enemyWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(myWarrior.Name, enemyWarrior.Name));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidDefender()
        {
            var arena = new Arena();

            var myWarrior = new Warrior("Mitko", 50, 50);
            var enemyWarrior = new Warrior("Gosho", 50, 50);

            arena.Enroll(myWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(myWarrior.Name, enemyWarrior.Name));
        }

        [Test]
        public void FightMethodShouldReduceWarriorsHp()
        {
            var arena = new Arena();

            var myWarrior = new Warrior("Mitko", 50, 100);
            var enemyWarrior = new Warrior("Gosho", 50, 100);

            arena.Enroll(myWarrior);
            arena.Enroll(enemyWarrior);

            arena.Fight(myWarrior.Name, enemyWarrior.Name);
            Assert.AreEqual(50, myWarrior.HP);
            Assert.AreEqual(50, enemyWarrior.HP);
        }
    }
}
