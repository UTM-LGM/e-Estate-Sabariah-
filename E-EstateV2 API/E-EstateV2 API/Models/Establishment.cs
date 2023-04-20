using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class Establishment
    {
        [Key]
        public int Id { get; set; }
        public string establishment { get; set; }
        public bool isActive { get; set; }
    }
}
