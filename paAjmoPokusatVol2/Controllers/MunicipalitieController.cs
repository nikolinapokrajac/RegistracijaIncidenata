using Microsoft.AspNetCore.Mvc;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;

namespace paAjmoPokusatVol2.Controllers
{
    public class MunicipalitieController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly IMunicipalitieRepository _municipalitieRepo; //ovo brisem kada dodam UnitOfWork a dodajem dole
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        /* public MunicipalitieController(ApplicationDbContext db)
         {
             _db = db;
         }*/
        /*public MunicipalitieController(IMunicipalitieRepository municipalitieRepo)
        {
            _municipalitieRepo = municipalitieRepo;
        }*/

        public MunicipalitieController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //List<Municipalitie> objMunicipalitieList = _db.Municipalities.ToList();
            //List<Municipalitie> objMunicipalitieList = _municipalitieRepo.GetAll().ToList(); //ovdje dodali UnitOfWork
            List<Municipalitie> objMunicipalitieList = _unitOfWork.Municipalitie.GetAll().ToList();
            return View(objMunicipalitieList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Municipalitie obj, IFormFile? file)
        {
            if (obj.Name.Length > 50)
                ModelState.AddModelError("name", "Dužina polja ne smije biti veća od 50 karaktera.");
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string municipalitieTypePath = Path.Combine(wwwRootPath, @"images/municipalitie");
                    using (var fileStream = new FileStream(Path.Combine(municipalitieTypePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.UrlImage = @"\images\municipalitie\" + fileName;
                }
                //_db.Municipalities.Add(obj);
                //_db.SaveChanges();
                //_municipalitieRepo.Add(obj);//ovdje dodali UnitOfWork
                //_municipalitieRepo.Save();
                _unitOfWork.Municipalitie.Add(obj);
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
            //Municipalitie? municipalitieFromDb = _db.Municipalities.FirstOrDefault(x => x.Id == id);
            //Municipalitie? municipalitieFromDb = _municipalitieRepo.Get(x => x.Id == id);//ovdje dodali UnitOfWork
            Municipalitie? municipalitieFromDb = _unitOfWork.Municipalitie.Get(x => x.Id == id);
            if (municipalitieFromDb == null)
                return NotFound();
            return View(municipalitieFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Municipalitie obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string municipalitieTypePath = Path.Combine(wwwRootPath, @"images\municipalitie");
                    if (!string.IsNullOrEmpty(municipalitieTypePath))
                    {
                        //delete the old image
                        if (obj.UrlImage != null)
                        {
                            var oldImagePath = Path.Combine(wwwRootPath, obj.UrlImage.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(municipalitieTypePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.UrlImage = @"\images\municipalitie\" + fileName;
                }
                //_db.Municipalities.Update(obj);
                //_db.SaveChanges();
                //_municipalitieRepo.Update(obj);//ovdje dodali UnitOfWork
                //_municipalitieRepo.Save();
                _unitOfWork.Municipalitie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspješno ažurirana postojeća vrsta incidenta";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            //Municipalitie? municipalitieFromDb = _db.Municipalities.FirstOrDefault(x => x.Id == id);
            //Municipalitie? municipalitieFromDb = _municipalitieRepo.Get(x => x.Id == id);
            Municipalitie? municipalitieFromDb = _unitOfWork.Municipalitie.Get(x => x.Id == id);
            if (municipalitieFromDb == null)
                return NotFound();
            return View(municipalitieFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Municipalitie? obj = _db.Municipalities.FirstOrDefault(x => x.Id == id);
            //Municipalitie? obj = _municipalitieRepo.Get(x => x.Id == id);
            Municipalitie? obj = _unitOfWork.Municipalitie.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            //_db.Municipalities.Remove(obj);
            //_db.SaveChanges();
            //_municipalitieRepo.Remove(obj);
            //_municipalitieRepo.Save();
            _unitOfWork.Municipalitie.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
