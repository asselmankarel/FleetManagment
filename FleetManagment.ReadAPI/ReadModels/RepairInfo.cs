using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class RepairInfo
    {
        public string InsuranceCompany { get; set; }

        public DateTime RepairDate { get; set; }

        public string Description { get; set; }

    }
}
