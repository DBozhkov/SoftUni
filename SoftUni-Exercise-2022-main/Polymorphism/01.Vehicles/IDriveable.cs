namespace _01.Vehicles
{
    public interface IDriveable
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }

        void Drive(double distance);
        double Refuel(double quantity);
    }
}
