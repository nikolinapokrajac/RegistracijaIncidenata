using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;
using paAjmoPokusat.Models.ViewModels;

namespace paAjmoPokusatVol2.Controllers
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
        public IActionResult Index(int id)
        {
            IncidentVM incidentVM = new()
            {
                IncidentTypeList = _unitOfWork.IncidentType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }),
                MunicipalitieList = _unitOfWork.Municipalitie.GetAll().Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }),
                Incident = new Incident()
            };
            incidentVM.Incident = _unitOfWork.Incident.Get(u => u.Id == id, includeProperties: "IncidentImages");
            return View(incidentVM);
        }
    }
}
