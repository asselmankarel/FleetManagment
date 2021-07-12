using System;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class MaintenanceInfo
    {
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public string Garage { get; set; }

        public int InvoiceId { get; set; }

    }
}
