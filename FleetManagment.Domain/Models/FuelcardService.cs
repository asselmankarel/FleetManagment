﻿using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class FuelcardService
    {
        public string Name { get; set; }
        public ICollection<Fuelcard> Fuelcards { get; set; }
    }
}