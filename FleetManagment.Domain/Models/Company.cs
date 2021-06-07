namespace FleetManagment.Domain.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
