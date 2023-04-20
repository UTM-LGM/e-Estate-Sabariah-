using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class CostSubcategory2
    {
        [Key]
        public int Id { get; set; }
        public string costSubcategory2 { get; set; }
        public bool isActive { get; set; }
    }
}
