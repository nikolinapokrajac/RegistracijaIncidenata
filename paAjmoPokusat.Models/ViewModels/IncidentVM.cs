using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace paAjmoPokusat.Models.ViewModels
{
    public class IncidentVM
    {
        public Incident Incident { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> IncidentTypeList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MunicipalitieList { get; set; }
    }
}
