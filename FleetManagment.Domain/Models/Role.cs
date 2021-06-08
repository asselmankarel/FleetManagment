using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagment.Domain.Models
{
    public class Role
    {
        public string RoleType { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
