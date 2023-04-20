﻿using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string country { get; set; }
        public bool isLocal { get; set; }
        public bool isActive { get; set; }
    }
}
