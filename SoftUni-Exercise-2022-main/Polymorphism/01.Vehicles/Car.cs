using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    class Car : IDriveable
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm + 0.9;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm { get; private set; }

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
            return this.FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}
