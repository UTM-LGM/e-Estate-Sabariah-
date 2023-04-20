using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_EstateV2_API.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }
        public string fieldName { get; set; }
        public int area { get; set; }
        public bool isMature { get; set; }
        public bool isActive { get; set; }
        public DateTime dateOpenTapping { get; set; }
        public int yearPlanted { get; set; }
        public string otherCrop { get; set; }
        public int totalTask { get; set; }

        [ForeignKey("CropCategoryId")]
        public int cropCategoryId { get; set; }
        public CropCategory CropCategory { get; set; }

        [ForeignKey("EstateId")]
        public int estateId { get; set; }
        public Estate Estate { get; set; }
    }
}
