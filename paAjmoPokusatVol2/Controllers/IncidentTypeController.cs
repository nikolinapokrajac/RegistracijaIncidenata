
using Microsoft.AspNetCore.Mvc;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;

namespace paAjmoPokusatVol2.Controllers
{
    public class IncidentTypeController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly IIncidentTypeRepository _incidentTypeRepo; //ovo brisem kada dodam UnitOfWork a dodajem dole
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        /* public IncidentTypeController(ApplicationDbContext db)
         {
             _db = db;
         }*/
        /*public IncidentTypeController(IIncidentTypeRepository incidentTypeRepo)
        {
            _incidentTypeRepo = incidentTypeRepo;
        }*/

        public IncidentTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //List<IncidentType> objIncidentTypeList = _db.IncidentTypes.ToList();
            //List<IncidentType> objIncidentTypeList = _incidentTypeRepo.GetAll().ToList(); //ovdje dodali UnitOfWork
            List<IncidentType> objIncidentTypeList = _unitOfWork.IncidentType.GetAll().ToList();
            return View(objIncidentTypeList);
        }
        /*
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IncidentType obj)
        {
            if (obj.Name.Length > 50)
                ModelState.AddModelError("name", "Dužina polja ne smije biti veća od 50 karaktera.");
            if (obj.Description.Length > 250)
                ModelState.AddModelError("description", "Dužina polja ne smije biti veća od 250 karaktera.");
            if (ModelState.IsValid)
            {
                //_db.IncidentTypes.Add(obj);
                //_db.SaveChanges();
                //_incidentTypeRepo.Add(obj);//ovdje dodali UnitOfWork
                //_incidentTypeRepo.Save();
                _unitOfWork.IncidentType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspješno dodana nova vrsta incidenta";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            //IncidentType? incidentTypeFromDb = _db.IncidentTypes.FirstOrDefault(x => x.Id == id);
            //IncidentType? incidentTypeFromDb = _incidentTypeRepo.Get(x => x.Id == id);//ovdje dodali UnitOfWork
            IncidentType? incidentTypeFromDb = _unitOfWork.IncidentType.Get(x => x.Id == id);
            if (incidentTypeFromDb == null)
                return NotFound();
            return View(incidentTypeFromDb);
        }
        [HttpPost]
        public IActionResult Edit(IncidentType obj)
        {
            if (ModelState.IsValid)
            {
                //_db.IncidentTypes.Update(obj);
                //_db.SaveChanges();
                //_incidentTypeRepo.Update(obj);//ovdje dodali UnitOfWork
                //_incidentTypeRepo.Save();
                _unitOfWork.IncidentType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspješno ažurirana postojeća vrsta incidenta";
                return RedirectToAction("Index");
            }
            return View();
        }
        */

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
            //TempData["success"] = "Uspješno";
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string incidentTypePath = Path.Combine(wwwRootPath, @"images\incidentType");
                    if (!string.IsNullOrEmpty(incidentTypePath))
                    {
                        //delete the old image
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
                    //TempData["success"] += " dodan novi ";
                }
                else
                {
                    _unitOfWork.IncidentType.Update(incidentType);
                    //TempData["success"] += " uređen postojeći ";
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
            //IncidentType? incidentTypeFromDb = _db.IncidentTypes.FirstOrDefault(x => x.Id == id);
            //IncidentType? incidentTypeFromDb = _incidentTypeRepo.Get(x => x.Id == id);
            IncidentType? incidentTypeFromDb = _unitOfWork.IncidentType.Get(x => x.Id == id);
            if (incidentTypeFromDb == null)
                return NotFound();
            return View(incidentTypeFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // IncidentType? obj = _db.IncidentTypes.FirstOrDefault(x => x.Id == id);
            //IncidentType? obj = _incidentTypeRepo.Get(x => x.Id == id);
            IncidentType? obj = _unitOfWork.IncidentType.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            //_db.IncidentTypes.Remove(obj);
            //_db.SaveChanges();
            //_incidentTypeRepo.Remove(obj);
            //_incidentTypeRepo.Save();
            _unitOfWork.IncidentType.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
