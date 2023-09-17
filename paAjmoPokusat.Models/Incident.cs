﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace paAjmoPokusat.Models
{
    public class Incident
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Naziv incidenta")]
        public string Name { get; set; }
        [DisplayName("Kratki opis incidenta")]
        public string Description { get; set; }
        [DisplayName("Broj povrijeđenih lica")]
        public int InjuredPeopleCount { get; set; }
        [DisplayName("Broj umrlih lica")]
        public int DeadPeopleCount { get; set; }
        [DisplayName("Vrsta incidenta")]
        public int IncidentTypeId { get; set; }
        [ForeignKey("IncidentTypeId")]
        [ValidateNever]
        public IncidentType IncidentType { get; set; }
        [DisplayName("Opština")]
        public int MunicipalitieId { get; set; }
        [ForeignKey("MunicipalitieId")]
        [ValidateNever]
        public Municipalitie Municipalitie { get; set; }
        [ValidateNever]
        public List<IncidentImage> IncidentImages { get; set; }
    }
}
