
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;
using paAjmoPokusat.Models.ViewModels;

namespace paAjmoPokusatVol2.Controllers
{
    public class IncidentController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly IIncidentRepository _incidentRepo; //ovo brisem kada dodam UnitOfWork a dodajem dole
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        // private readonly IWebHostEnvironment _webHostEnvironment;//ovo bih imala da imam sliku i imala bih dodatan kod za brisanje slike dole
        /* public IncidentController(ApplicationDbContext db)
         {
             _db = db;
         }*/
        /*public IncidentController(IIncidentRepository incidentRepo)
        {
            _incidentRepo = incidentRepo;
        }*/

        public IncidentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //List<Incident> objIncidentList = _db.Incidents.ToList();
            //List<Incident> objIncidentList = _incidentRepo.GetAll().ToList(); //ovdje dodali UnitOfWork
            List<Incident> objIncidentList = _unitOfWork.Incident.GetAll(includeProperties: "IncidentType,Municipalitie").ToList();
            return View(objIncidentList);
        }

        /*
        public IActionResult Create()
        {
            IncidentVM incidentVM = new() { Incident = new Incident(), IncidentTypeList = _unitOfWork.IncidentType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }), MunicipalitieList = _unitOfWork.Municipalitie.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }) };
            return View(incidentVM);
        }
        [HttpPost]
        public IActionResult Create(IncidentVM incidentVM)
        {
            if (ModelState.IsValid)
            {
                //_db.Incidents.Add(obj);
                //_db.SaveChanges();
                //_incidentRepo.Add(obj);//ovdje dodali UnitOfWork
                //_incidentRepo.Save();
                _unitOfWork.Incident.Add(incidentVM.Incident);
                _unitOfWork.Save();
                TempData["success"] = "Uspješno dodana nova vrsta incidenta";
                return RedirectToAction("Index");
            }
            else
            {
                incidentVM.IncidentTypeList = _unitOfWork.IncidentType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });
                incidentVM.MunicipalitieList = _unitOfWork.Municipalitie.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });
                return View(incidentVM);
            }
        }

        /*
        public IActionResult Create(Incident obj)
        {
            if (obj.Name.Length > 50)
                ModelState.AddModelError("name", "Dužina polja ne smije biti veća od 50 karaktera.");
            if (ModelState.IsValid)
            {
                //_db.Incidents.Add(obj);
                //_db.SaveChanges();
                //_incidentRepo.Add(obj);//ovdje dodali UnitOfWork
                //_incidentRepo.Save();
                _unitOfWork.Incident.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspješno dodana nova vrsta incidenta";
                return RedirectToAction("Index");
            }
            return View(obj);
        }//ovdje je bio zatvoren komentar ali kad smo ubacivali da imamo samo upsert morali smo to zatvaranje koje izgleda kao na kraju ovoga reda da premjestimo   //tako eto

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            //Incident? incidentFromDb = _db.Incidents.FirstOrDefault(x => x.Id == id);
            //Incident? incidentFromDb = _incidentRepo.Get(x => x.Id == id);//ovdje dodali UnitOfWork
            Incident? incidentFromDb = _unitOfWork.Incident.Get(x => x.Id == id);
            if (incidentFromDb == null)
                return NotFound();
            return View(incidentFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Incident obj)
        {
            if (ModelState.IsValid)
            {
                //_db.Incidents.Update(obj);
                //_db.SaveChanges();
                //_incidentRepo.Update(obj);//ovdje dodali UnitOfWork
                //_incidentRepo.Save();
                _unitOfWork.Incident.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspješno ažurirana postojeća vrsta incidenta";
                return RedirectToAction("Index");
            }
            return View();
        }
        */

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
            //TempData["success"] = "Uspješno";
            if (ModelState.IsValid)
            {
                if (incidentVM.Incident.Id == 0)
                {
                    _unitOfWork.Incident.Add(incidentVM.Incident);
                    //TempData["success"] += " dodan novi ";
                }
                else
                {
                    _unitOfWork.Incident.Update(incidentVM.Incident);
                    //TempData["success"] += " uređen postojeći ";
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
        /*
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            //Incident? incidentFromDb = _db.Incidents.FirstOrDefault(x => x.Id == id);
            //Incident? incidentFromDb = _incidentRepo.Get(x => x.Id == id);
            Incident? incidentFromDb = _unitOfWork.Incident.Get(x => x.Id == id);
            if (incidentFromDb == null)
                return NotFound();
            return View(incidentFromDb);
        }*/
        /* [HttpPost, ActionName("Delete")]
         public IActionResult DeletePOST(int? id)
         {
             // Incident? obj = _db.Incidents.FirstOrDefault(x => x.Id == id);
             //Incident? obj = _incidentRepo.Get(x => x.Id == id);
             Incident? obj = _unitOfWork.Incident.Get(x => x.Id == id);
             if (obj == null)
             {
                 return NotFound();
             }
             //_db.Incidents.Remove(obj);
             //_db.SaveChanges();
             //_incidentRepo.Remove(obj);
             //_incidentRepo.Save();
             _unitOfWork.Incident.Remove(obj);
             _unitOfWork.Save();
             return RedirectToAction("Index");
         }
         */

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
            List<Incident> objIncidentList = _unitOfWork.Incident.GetAll(includeProperties: "IncidentType,Municipalitie").ToList();
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
