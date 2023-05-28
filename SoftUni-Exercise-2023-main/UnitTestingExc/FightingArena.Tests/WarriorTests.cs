namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("Mitko", 1, 0)]
        [TestCase("Gosho", 60, 70)]
        [TestCase("Pesho", 11, 11)]
        public void ConstructorShouldInitializeAllValidValues(string name, int damage, int hp)
        {
            var warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null, 60, 70)]
        [TestCase("", 10, 10)]
        [TestCase(" ", 11, 11)]
        public void NameShouldNotBeNullEmptyOrWhiteSpace(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void DamageCannotBeZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Mitko", damage, 50));
        }

        [TestCase(-10)]
        public void HealthCannotBeNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Mitko", 50, hp));
        }

        [TestCase("Mitko", 30, 20)]
        [TestCase("Mitko", 20, 10)]
        public void WarriorShouldNotAttackIfHealthIsBelow30(string name, int damage, int hp)
        {
            var warrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Gosho", 10, 40)));
        }

        [TestCase("Mitko", 50, 60)]
        [TestCase("Mitko", 40, 50)]
        public void WarriorShouldNotAttackWhenHpIsLowerThanEnemyDamage(string name, int damage, int hp)
        {
            var warrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Gosho", 99, 88)));
        }

        [TestCase("Mitko", 50, 50)]
        [TestCase("Mitko", 60, 70)]
        public void WarriorShouldNotAttackEnemyWarriorsWhoseHpIsBelow30(string name, int damage, int hp)
        {
            var warrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Gosho", 70, 20)));
        }

        [TestCase("Mitko", 50, 100, 50, "Gosho", 50, 100, 50)]
        [TestCase("Mitko", 100, 100, 0, "Gosho", 100, 100, 0)]
        [TestCase("Mitko", 110, 100, 0, "Gosho", 100, 100, 0)]
        public void AttackMethodShouldReduceHpForBothWarriors(string name, int damage, int hp, int resultThis, string enemyName, int enemyDamage, int enemyHp, int resultWarrior)
        {
            var myWarrior = new Warrior(name, damage, hp);
            var enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHp);

            myWarrior.Attack(enemyWarrior);

            Assert.AreEqual(resultThis, myWarrior.HP);
            Assert.AreEqual(resultWarrior, enemyWarrior.HP);
        }
    }
}