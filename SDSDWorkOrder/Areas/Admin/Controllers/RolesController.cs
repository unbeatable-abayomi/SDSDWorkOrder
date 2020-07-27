using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using SDSDWorkOrder.Models;
using SDSDWorkOrder.Models.ViewModels;

namespace SDSDWorkOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
         private readonly RoleManager <IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]


        [HttpGet]
        public IActionResult AllUser()
        {
            var Users = _userManager.Users;
            return View(Users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var model = new ApplicationUser()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
               
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser user)
        {
            
            var result = await _userManager.FindByIdAsync(user.Id);
         var check =   await _userManager.UpdateAsync(result);
            if (check.Succeeded)
            {
                return View("AllUser", _userManager.Users);
            }
            else
            {
                return NotFound();
            }
            
            
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErroMessage = $"User cannot be found";
                return View("NotFound");
            }
            var model = new ApplicationUser
            {
                Id = user.Id,
                Email = user.Email

            };


            return View(model);
        }
        [HttpPost, ActionName("DeleteUser")]
        public async Task<IActionResult> ConfirmDelete(ApplicationUser model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllUser");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("AllUser", model);

            }

            else
            {

                ViewBag.ErrorMessage = $" Operation Failed";
                return View("NotFound");

            }


        }
        public async Task<IActionResult> LockUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            user.LockoutEnd = DateTime.Now.AddYears(1000);

            return RedirectToAction("AllUser");
        }
        public async Task<IActionResult> UnLockUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            user.LockoutEnd = DateTime.Now;

            return RedirectToAction("AllUser");


        }

        public IActionResult CreateRole()
        {

            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(ApplicationRole model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName,

                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllRole");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View();
        }
        public IActionResult AllRole()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErroMessage = $"Role  cannot be found";
                return View("NotFound");
            }
            var Vmodel = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name

            };



            return View(Vmodel);
        }


        [HttpPost, ActionName("DeleteRole")]
        public async Task<IActionResult> ConfirmDelete(EditRoleViewModel Vmodel)
        {
            var role = await _roleManager.FindByIdAsync(Vmodel.Id);
            if (role != null)
            {
                role.Name = Vmodel.RoleName;

                var result = await _roleManager.DeleteAsync(role);


                if (result.Succeeded)
                {
                    return RedirectToAction("AllRole");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("AllRole", Vmodel);

            }

            else
            {

                ViewBag.ErrorMessage = $"Role  cannot be found";
                return View("NotFound");
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role  cannot be found";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name

            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                };
            }

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErroMessage = $"Role with Id = {model.RoleName} cannot be found";
                return View("NotFound");
            }

            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllRole");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }

                return View("AllRole", model);
            }


        }



        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id ={roleId} cannot be found";
                return View("NotFound");
            }
            var model = new List<EditUserInRole>();
            foreach (var user in _userManager.Users)
            {
                var userRoleViewModel = new EditUserInRole()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<EditUserInRole> model,
            string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role  cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }

                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

    }
}
