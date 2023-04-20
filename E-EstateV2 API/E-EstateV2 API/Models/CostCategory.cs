using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class CostCategory
    {
        [Key]
        public int Id { get; set; }
        public string costCategory { get; set; }
        public bool isActive { get; set; }

    }
}
