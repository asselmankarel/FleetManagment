using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fleetmanagement.IdentityProvider.Entities
{
    public class UserClaim : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Type { get; set; }

        [Required]
        [MaxLength(256)]
        public string Value { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();


        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
