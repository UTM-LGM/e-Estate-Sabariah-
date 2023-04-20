﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_EstateV2_API.Models
{
    public class FieldClone
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FieldId")]
        public int fieldId { get; set; }
        public Field Field { get; set; }

        [ForeignKey("CloneId")]
        public int cloneId { get; set; }
        public Clone Clone { get; set; }
        
    }
}
