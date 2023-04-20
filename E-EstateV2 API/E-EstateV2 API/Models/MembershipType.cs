using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }
        public string membershipType { get; set; }
        public bool isActive { get; set; }
    }
}
