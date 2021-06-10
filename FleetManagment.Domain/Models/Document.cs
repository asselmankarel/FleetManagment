﻿using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string FilePath { get; set; }
    }
}