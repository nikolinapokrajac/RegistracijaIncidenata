using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace paAjmoPokusat.Models
{
    public class Municipalitie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Naziv opštine")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Adresa opštine")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Geografska širina")]
        public string Latitude { get; set; }
        [Required]
        [DisplayName("Geografska dužina")]
        public string Longitude { get; set; }
        [ValidateNever]
        public string UrlImage { get; set; }
    }

}
