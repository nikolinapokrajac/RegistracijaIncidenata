using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace paAjmoPokusat.Models
{
    public class IncidentImage
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int IncidentId { get; set; }
        [ForeignKey("IncidentId")]
        public Incident Incident { get; set; }
    }
}
