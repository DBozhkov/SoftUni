namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void CtorShouldSetCapacityValue()
        {
            var robots = new RobotManager(10);

            Assert.AreEqual(10, robots.Capacity);
        }

        [Test]
        public void CtorShouldThrowExceptionForNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-10));
        }

        [Test]
        public void CountShouldBeZeroForEmptyRobotManager()
        {
            var robots = new RobotManager(0);
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void CountShouldBeCorrectForCorrectRobotManager()
        {
            var robots = new RobotManager(50);
            robots.Add(new Robot("Mitko", 50));
            robots.Add(new Robot("Gosho", 50));
            robots.Add(new Robot("Pesho", 50));
            Assert.AreEqual(3, robots.Count);
        }

        [Test]
        public void AddShouldThrowExceptionForSameNameRobots()
        {
            var robots = new RobotManager(50);
            robots.Add(new Robot("Mitko", 50));

            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("Mitko", 50)));
        }

        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsFull()
        {
            var robots = new RobotManager(2);
            robots.Add(new Robot("Mitko", 50));
            robots.Add(new Robot("Gosho", 50));

            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("Pesho", 50)));
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            var robots = new RobotManager(50);
            robots.Add(new Robot("Mitko", 50));
            robots.Add(new Robot("Pesho", 50));
            robots.Remove("Mitko");
            Assert.AreEqual(1, robots.Count);

            robots.Remove("Pesho");
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenRobotNotFound()
        {
            var robots = new RobotManager(50);
            robots.Add(new Robot("Mitko", 50));
            robots.Add(new Robot("Pesho", 50));
            robots.Remove("Gosho");
            Assert.Throws<InvalidOperationException>(() => robots.Remove("Gosho"));
        }

        [Test]
        public void WorkMethodShouldWorkCorrectly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Mitko", 100);
            robots.Add(robot);
            robots.Work("Mitko", ".....", 40);
            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void WorkShouldThrowExceptionWhenRobotNotFound()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Mitko", 100);
            robots.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robots.Work("Pesho", "....", 40));
        }

        [Test]
        public void WorkShouldThrowExceptionWhenRobotHasNoBattery()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Mitko", 20);
            robots.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robots.Work("Mitko", "....", 30));
        }

        [Test]
        public void ChargeShouldWorkProperly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Mitko", 100);
            robots.Add(robot);
            robots.Work("Mitko", ".....", 60);
            robots.Charge("Mitko");
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowExceptionIfRobotIsNotFound()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Mitko", 100);
            robots.Add(robot);
            robots.Work("Mitko", ".....", 60);

            Assert.Throws<InvalidOperationException>(() => robots.Charge("Gosho"));
        }
    }
}
