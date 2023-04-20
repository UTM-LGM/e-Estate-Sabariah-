using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_EstateV2_API.Models
{
    public class FieldProduction
    {
        [Key]
        public int Id { get; set; }
        public string monthYear { get; set; }
        public int cuplump { get; set; }
        public float cuplumpDRC { get; set; }
        public int latex { get; set; }
        public float latexDRC { get; set; }
        public int noTaskTap { get; set; }
        public int noTaskUntap { get; set; }

        [ForeignKey("FieldId")]
        public int fieldId { get; set; }
        public Field Field { get; set; }
    }
}
