using FleetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Domain.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public RoleType RoleType { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
