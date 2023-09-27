using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;
using paAjmoPokusat.Models.ViewModels;

namespace paAjmoPokusatVol2.Controllers
{
    public class IncidentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public IncidentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            List<Incident> objIncidentList = null;

            return View(objIncidentList);
        }



        public IActionResult Upsert(int? id)
        {
            IncidentVM incidentVM = new()
            {
                IncidentTypeList = _unitOfWork.IncidentType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }),
                MunicipalitieList = _unitOfWork.Municipalitie.GetAll().Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }),
                Incident = new Incident()
            };
            if (id == null || id == 0)
            {

                return View(incidentVM);
            }
            else
            {
                incidentVM.Incident = _unitOfWork.Incident.Get(u => u.Id == id, includeProperties: "IncidentImages");
                return View(incidentVM);
            }
        }

        [HttpPost]

        public IActionResult Upsert(IncidentVM incidentVM, List<IFormFile> files)
        {
            incidentVM.Incident.UserNameOfPersonThatAddedIncident = User.Identity.Name.ToString();

            if (ModelState.IsValid)
            {
                if (incidentVM.Incident.Id == 0)
                {

                    _unitOfWork.Incident.Add(incidentVM.Incident);

                }
                else
                {
                    _unitOfWork.Incident.Update(incidentVM.Incident);

                }

                _unitOfWork.Save();
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {
                    foreach (IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string incidentPath = @"images\incidents\incident-" + incidentVM.Incident.Id;
                        string finalPath = Path.Combine(wwwRootPath, incidentPath);
                        if (!Directory.Exists(finalPath))
                        {
                            Directory.CreateDirectory(finalPath);
                        }
                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        IncidentImage incidentImage = new()
                        {
                            ImageUrl = @"\" + incidentPath + @"\" + fileName,
                            IncidentId = incidentVM.Incident.Id
                        };
                        if (incidentVM.Incident.IncidentImages == null)
                        {
                            incidentVM.Incident.IncidentImages = new List<IncidentImage>();
                        }
                        incidentVM.Incident.IncidentImages.Add(incidentImage);
                        _unitOfWork.IncidentImage.Add(incidentImage);
                    }
                    _unitOfWork.Incident.Update(incidentVM.Incident);
                    _unitOfWork.Save();
                }
                TempData["success"] = "Uspješno dodan novi/izmijenjen postojeći incident";
                return RedirectToAction("Index");
            }
            else
            {
                incidentVM.IncidentTypeList = _unitOfWork.IncidentType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });
                incidentVM.MunicipalitieList = _unitOfWork.Municipalitie.GetAll().Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
                return View(incidentVM);
            }

        }


        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.IncidentImage.Get(u => u.Id == imageId);
            int incidentId = imageToBeDeleted.IncidentId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _unitOfWork.IncidentImage.Remove(imageToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "Image deleted successfully";
            }
            return RedirectToAction(nameof(Upsert), new { id = incidentId });
        }

        #region API CALLS 
        [HttpGet]
        public IActionResult GetAll()
        {


            List<Incident> objIncidentList = null;

            if (User.IsInRole(paAjmoPokusat.Utility.SD.Role_Operater))
            {
                objIncidentList = _unitOfWork.Incident.GetAll(i => i.UserNameOfPersonThatAddedIncident == User.Identity.Name, includeProperties: "IncidentType,Municipalitie").ToList();
            }
            else if (User.IsInRole(paAjmoPokusat.Utility.SD.Role_Admin))
            {
                objIncidentList = _unitOfWork.Incident.GetAll(includeProperties: "IncidentType,Municipalitie").ToList();
            }
            Console.WriteLine(objIncidentList.Count);
            return Json(new { data = objIncidentList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var incidentToBeDeleted = _unitOfWork.Incident.Get(u => u.Id == id);
            if (incidentToBeDeleted == null)
            {
                return Json(new { success = false, message = "Greška prilikom brisanja incidenta" });
            }
            string incidentPath = @"images\incidents\incident-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, incidentPath);
            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }
                Directory.Delete(finalPath);
            }
            _unitOfWork.Incident.Remove(incidentToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Uspješno obrisan incident" });
        }

        #endregion
    }
}

