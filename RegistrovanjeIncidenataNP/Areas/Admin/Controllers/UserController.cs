
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistrovanjeIncidenata.DataAccess.Repository.IRepository;
using RegistrovanjeIncidenata.Models;
using RegistrovanjeIncidenata.Models.ViewModels;
using RegistrovanjeIncidenata.Utility;
using System.Data;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var usersList = _unitOfWork.ApplicationUser.GetAll().ToList();

            return View();
        }

        public IActionResult RoleManagment(string userId)
        {

            RoleManagmentVM RoleVM = new RoleManagmentVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId),
                RoleList = _roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
            };

            RoleVM.ApplicationUser.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == userId))
                    .GetAwaiter().GetResult().FirstOrDefault();
            return View(RoleVM);
        }

        [HttpPost]
        public IActionResult RoleManagment(RoleManagmentVM roleManagmentVM)
        {

            string oldRole = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == roleManagmentVM.ApplicationUser.Id))
                    .GetAwaiter().GetResult().FirstOrDefault();

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == roleManagmentVM.ApplicationUser.Id);
            if (roleManagmentVM.ApplicationUser.Name != null && roleManagmentVM.ApplicationUser.Name != "")
            {
                applicationUser.Name = roleManagmentVM.ApplicationUser.Name;
            }
            if (roleManagmentVM.ApplicationUser.LastName != null && roleManagmentVM.ApplicationUser.LastName != "")
            {
                applicationUser.LastName = roleManagmentVM.ApplicationUser.LastName;
            }
            if (roleManagmentVM.ApplicationUser.Email != null && roleManagmentVM.ApplicationUser.Email != "")
            {
                applicationUser.Email = roleManagmentVM.ApplicationUser.Email;
                applicationUser.NormalizedEmail = roleManagmentVM.ApplicationUser.Email.ToUpper();
            }
            if (roleManagmentVM.ApplicationUser.PasswordHash != null && roleManagmentVM.ApplicationUser.PasswordHash != "")
            {
                PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
                applicationUser.PasswordHash = ph.HashPassword(applicationUser, roleManagmentVM.ApplicationUser.PasswordHash);

            }
            _unitOfWork.ApplicationUser.Update(applicationUser);


            if (!(roleManagmentVM.ApplicationUser.Role == oldRole))
            {
                if (oldRole != null)
                {
                    _userManager.RemoveFromRoleAsync(roleManagmentVM.ApplicationUser, oldRole).GetAwaiter().GetResult();
                }
                _userManager.AddToRoleAsync(roleManagmentVM.ApplicationUser, roleManagmentVM.ApplicationUser.Role).GetAwaiter().GetResult();

            }
            _unitOfWork.Save();
            TempData["success"] = "Uspješno uređeni podaci o korisniku!";
            return RedirectToAction("Index");
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _unitOfWork.ApplicationUser.GetAll().ToList();

            foreach (var user in objUserList)
            {

                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

            }

            return Json(new { data = objUserList });
        }


        //[HttpPost]
        //public IActionResult LockUnlock([FromBody] string id)
        //{

        //    var objFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while Locking/Unlocking" });
        //    }

        //    if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
        //    {
        //        //user is currently locked and we need to unlock them
        //        objFromDb.LockoutEnd = DateTime.Now;
        //    }
        //    else
        //    {
        //        objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
        //    }
        //    _unitOfWork.ApplicationUser.Update(objFromDb);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Operation Successful" });
        //}

        #endregion
    }
}
