using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    class Car : IDriveable
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            if (fuelQuantity <= tankCapacity)
            {
                this.FuelQuantity = fuelQuantity;
            }

            else
            {
                this.FuelQuantity = 0;
            }
            this.FuelConsumptionPerKm = fuelConsumptionPerKm + 0.9;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm { get; private set; }

        public double TankCapacity { get; private set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - distance * FuelConsumptionPerKm > 0)
            {
                Console.WriteLine($"Car travelled {distance} km");
                FuelQuantity -= distance * FuelConsumptionPerKm;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public double Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                throw new IndexOutOfRangeException("Fuel must be a positive number");
            }

            else if (quantity > (TankCapacity - FuelQuantity))
            {
                throw new OverflowException($"Cannot fit {quantity} fuel in the tank");
            }
            return this.FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}
