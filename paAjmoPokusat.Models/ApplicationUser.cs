using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegistrovanjeIncidenata.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [ValidateNever]
        [DisplayName("Address")]
        public string? StreetAdress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        [ValidateNever]
        public string? Role { get; set; }
    }
}
