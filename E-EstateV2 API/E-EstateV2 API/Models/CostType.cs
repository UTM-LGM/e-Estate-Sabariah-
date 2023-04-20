using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class CostType
    {
        [Key]
        public int Id { get; set; }
        public string costType { get; set; }
        public bool isActive { get; set; }
    }
}
