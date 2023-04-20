using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class FinancialYear
    {
        [Key]
        public int Id { get; set; }
        public string financialYear { get; set; }
        public bool isActive { get; set; }
    }
}
