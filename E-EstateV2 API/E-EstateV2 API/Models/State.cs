using System.ComponentModel.DataAnnotations;

namespace E_EstateV2_API.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string state { get; set; }
        public bool isActive { get; set; }
    }
}
