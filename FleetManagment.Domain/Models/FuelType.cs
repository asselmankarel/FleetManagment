namespace FleetManagment.Domain.Models
{
    public enum FuelTypes
    {
        Cng,
        Diesel,
        Electric,
        Gasoline,
        Hybrid,
        Hydrogen,
        Lpg
    }
    public class FuelType
    {
        public FuelTypes Name { get; set; }

    }
}