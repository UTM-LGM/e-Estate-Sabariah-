using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_EstateV2_API.Models
{
    public class Labor
    {
        [Key]
        public int Id { get; set; }
        public string monthYear { get; set; }
        public int tapperCheckrole { get; set; }
        public int tapperContractor { get; set; }
        public int fieldCheckrole { get; set; }
        public int fieldContractor { get; set; }
        public int workerNeeded { get; set; }

        [ForeignKey("CountryId")]
        public int countryId { get; set; }
        public Country Country { get; set; }

        [ForeignKey("EstateId")]
        public int estateId { get; set; }
        public Estate Estate { get; set; }
    }
}
