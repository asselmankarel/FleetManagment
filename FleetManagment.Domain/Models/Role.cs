using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagment.Domain.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleType { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
