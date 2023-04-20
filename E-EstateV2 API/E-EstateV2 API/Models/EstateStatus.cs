using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_EstateV2_API.Models
{
    public class EstateStatus
    {
        [Key]
        public int Id { get; set; }
        public bool isActive { get; set; }
        public DateTime updatedDate { get; set; }

        [ForeignKey("EstateId")]
        public int EstateId { get; set; }
        public Estate Estate { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
