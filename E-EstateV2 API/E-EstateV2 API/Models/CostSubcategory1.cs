using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class CostSubcategory1
    {
        [Key]
        public int Id { get; set; }
        public string costSubcategory1 { get; set; }
        public bool isActive { get; set; }
    }
}
