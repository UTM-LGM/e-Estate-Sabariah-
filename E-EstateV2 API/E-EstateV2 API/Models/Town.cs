﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_EstateV2_API.Models
{
    public class Town
    {
        [Key]
        public int Id { get; set; }
        public string town { get; set; }

        [ForeignKey("StateId")]
        public int stateId { get; set; }
        public State State { get; set; }
        public bool isActive { get; set; }
    }
}
