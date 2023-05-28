namespace _02.VehiclesExtension
{
    public interface IDriveable
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        double TankCapacity { get; }

        void Drive(double distance);
        double Refuel(double quantity);
    }
}
