﻿using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class FuelcardOption
    {
        public string Name { get; set; }
        public ICollection<Fuelcard> Fuelcards { get; set; }
    }
}