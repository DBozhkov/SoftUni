using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public enum IsPopulated
    {
        Empty,
        NotEmpty
    }
    class Bus : IDriveable
    {
        private double fuelConsumptionPerKm;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;

            this.FuelConsumptionPerKm = fuelConsumptionPerKm;

            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            set
            {
                fuelConsumptionPerKm = value;
            }
        }

        public double TankCapacity { get; private set; }

        public IsPopulated IsPopulated { get; set; }

        public void Drive(double distance)
        {
            if (IsPopulated == IsPopulated.NotEmpty)
            {
                FuelConsumptionPerKm += 1.4;
                if (FuelQuantity - distance * FuelConsumptionPerKm > 0)
                {
                    Console.WriteLine($"Bus travelled {distance} km");
                    FuelQuantity -= distance * FuelConsumptionPerKm;
                }
            }
            else if (IsPopulated == IsPopulated.Empty)
            {
                if (FuelQuantity - distance * FuelConsumptionPerKm > 0)
                {
                    Console.WriteLine($"Bus travelled {distance} km");
                    FuelQuantity -= distance * FuelConsumptionPerKm;
                }
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
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
            return $"Bus: {FuelQuantity:f2}";
        }
    }
}
