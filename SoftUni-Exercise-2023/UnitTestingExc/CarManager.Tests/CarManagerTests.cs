namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase("Lamborghini", "Aventador", 9.7, 90.0)]
        [TestCase("Ferrari", "Spyder418", 11.1, 80.0)]
        [TestCase("Lada", "Niva", 5.3, 50.0)]
        public void ConstructorShouldInitializeAllValidValues(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase(null, "Aventador", 9.7, 90.0)]
        [TestCase("", "Spyder418", 11.1, 80.0)]
        public void MakeShouldNotBeNullEmptyOrWhiteSpace(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase("Lamborghini", null, 9.7, 90.0)]
        [TestCase("Ferrari", "", 11.1, 80.0)]
        public void ModelShouldNotBeNullEmptyOrWhiteSpace(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void FuelConsumptionCannotBeZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Lamborghini", "Aventador", fuelConsumption, 90.0));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void FuelCapacityCannotBeZeroOrNegative(double fuelcapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Lamborghini", "Aventador", 5.7, fuelcapacity));
        }

        [Test]
        public void FuelAmmountCannotBeNegative()
        {
            var car = new Car("Lamborghini", "Aventador", 5.5, 70.0);

            car.Refuel(car.FuelCapacity);

            double beforeDrive = car.FuelAmount;

            car.Drive(100);

            double afterDrive = car.FuelAmount;

            Assert.AreNotEqual(afterDrive, beforeDrive);
        }

        [Test]
        public void RefuelShouldNotWorkIfValueIsBelowOrEqualToZero()
        {
            var car = new Car("Lamborghini", "Aventador", 5.5, 70.0);

            Assert.Throws<ArgumentException>(() => car.Refuel(-10.0));
        }

        [TestCase(15.7)]
        [TestCase(22.3)]
        public void RefuelShouldAddFuelToTankIfValueIsValid(double fuelToRefuel)
        {
            var car = new Car("Lamborghini", "Aventador", 5.5, 70.0);

            var beforeFuel = car.FuelAmount;

            car.Refuel(fuelToRefuel);

            var afterFuel = car.FuelAmount;

            Assert.AreNotEqual(beforeFuel, afterFuel);
        }

        [TestCase(55.5)]
        [TestCase(33.3)]
        public void FuelAmountShouldNotExceedFuelCapacity(double fuelToRefuel)
        {
            var car = new Car("Lamborghini", "Aventador", 5.5, 20.0);

            car.Refuel(fuelToRefuel);

            var afterFuel = car.FuelAmount;

            Assert.AreEqual(afterFuel, car.FuelCapacity);
        }

        [Test]
        public void DriveShouldThrowExceptionWhenFuelIsZero()
        {
            var car = new Car("Lamborghini", "Aventador", 15.5, 20.0);

            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        [Test]
        public void DriveShouldDecreaseFuelAmountIfValueIsValid()
        {
            var car = new Car("Lamborghini", "Aventador", 5.5, 90.0);
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);

            car.Drive(100);

            Assert.AreEqual(car.FuelAmount, initialFuel - car.FuelConsumption);
        }
    }
}