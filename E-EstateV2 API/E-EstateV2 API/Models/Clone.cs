using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class Clone
    {
        [Key]
        public int Id { get; set; }
        public string cloneName { get; set; }
        public string cloneCode { get; set; }
        public bool isActive { get; set; }

    }
}
