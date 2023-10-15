using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistrovanjeIncidenata.DataAccess.Repository.IRepository;
using RegistrovanjeIncidenata.Models;
using RegistrovanjeIncidenata.Models.ViewModels;

namespace RegistrovanjeIncidenataNP.Controllers
{
    public class AboutOneIncidentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutOneIncidentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int? id)
        {
            IncidentVM incidentVM = new()
            {
                IncidentTypeList = _unitOfWork.IncidentType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }),
                MunicipalitieList = _unitOfWork.Municipalitie.GetAll().Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }),
                Incident = new Incident()
            };
            incidentVM.Incident = _unitOfWork.Incident.Get(u => u.Id == id, includeProperties: "IncidentImages,IncidentType,Municipalitie");

            return View(incidentVM);
        }


        public IActionResult IncidentGallery(int? id)
        {
            IncidentVM incidentVM = new()
            {
                IncidentTypeList = _unitOfWork.IncidentType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }),
                MunicipalitieList = _unitOfWork.Municipalitie.GetAll().Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }),
                Incident = new Incident()
            };
            incidentVM.Incident = _unitOfWork.Incident.Get(u => u.Id == id, includeProperties: "IncidentImages,IncidentType,Municipalitie");

            return View(incidentVM);
        }
    }
}
