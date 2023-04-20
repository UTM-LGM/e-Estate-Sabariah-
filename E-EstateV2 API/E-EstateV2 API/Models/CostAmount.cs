using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_EstateV2_API.Models
{
    public class CostAmount
    {
        [Key]
        public int Id { get; set; }
        public float amount { get; set; }
        public int year { get; set; }

        [ForeignKey("CostId")]
        public int costId { get; set; }
        public Cost Cost { get; set; }

        [ForeignKey("EstateId")]
        public int estateId { get; set; }
        public Estate Estate { get; set; }
    }
}
