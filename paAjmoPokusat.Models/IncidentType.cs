using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace paAjmoPokusat.Models
{
    public class IncidentType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Naziv incidenta")]
        public string Name { get; set; }
        [DisplayName("Opis incidenta")]
        public string Description { get; set; }
        [DisplayName("URL slike")]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
