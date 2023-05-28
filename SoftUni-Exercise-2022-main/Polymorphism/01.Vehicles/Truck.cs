using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    class Truck : IDriveable
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm + 1.6;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm { get; private set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - distance * FuelConsumptionPerKm > 0)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= distance * FuelConsumptionPerKm;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public double Refuel(double quantity)
        {
            return this.FuelQuantity += quantity * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:f2}";
        }
    }
}
