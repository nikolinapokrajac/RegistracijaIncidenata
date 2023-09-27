
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;
using paAjmoPokusat.Utility;

namespace paAjmoPokusatVol2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class IncidentTypeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public IncidentTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            List<IncidentType> objIncidentTypeList = _unitOfWork.IncidentType.GetAll().ToList();
            return View(objIncidentTypeList);
        }

        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                IncidentType incidentType = new IncidentType();
                return View(incidentType);
            }
            else
            {
                IncidentType? incidentTypeFromDb = _unitOfWork.IncidentType.Get(x => x.Id == id);
                return View(incidentTypeFromDb);
            }
        }

        [HttpPost]

        public IActionResult Upsert(IncidentType incidentType, IFormFile? file)
        {


            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string incidentTypePath = Path.Combine(wwwRootPath, @"images\incidentType");
                    if (!string.IsNullOrEmpty(incidentTypePath))
                    {

                        if (incidentType.ImageUrl != null)
                        {
                            var oldImagePath = Path.Combine(wwwRootPath, incidentType.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(incidentTypePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    incidentType.ImageUrl = @"\images\incidentType\" + fileName;
                }
                if (incidentType.Id == 0)
                {
                    _unitOfWork.IncidentType.Add(incidentType);

                }
                else
                {
                    _unitOfWork.IncidentType.Update(incidentType);

                }
                _unitOfWork.Save();
                TempData["success"] = "Uspješno dodana nova/izmijenjena postojeća vrsta incident";
                return RedirectToAction("Index");
            }
            else
            {
                return View(incidentType);
            }

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            IncidentType? incidentTypeFromDb = _unitOfWork.IncidentType.Get(x => x.Id == id);
            if (incidentTypeFromDb == null)
                return NotFound();
            return View(incidentTypeFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            IncidentType? obj = _unitOfWork.IncidentType.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.IncidentType.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
