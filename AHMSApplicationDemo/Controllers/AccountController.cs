using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AHMSApplicationDemo.Models;
using AHMSApplicationDemo.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AHMSApplicationDemo.Controllers
{
   
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sinInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IList<string> _roles;

        public AccountController(SignInManager<IdentityUser> sinInManager,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _sinInManager = sinInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListRole()
        {
            var listRole = _roleManager.Roles.ToList();
            return View(listRole);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListRole));

                }
            }
            return View(model);
        }

        public async Task<IActionResult> EditRole(string RoleId)
        {
            IdentityRole rol = await _roleManager.FindByIdAsync(RoleId);
            if (rol == null)
            {
                return View("~/NotFound");
            }
            var editRoleViewModel = new EditRoleViewModel
            {
                Id = rol.Id,
                RoleName = rol.Name
            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, rol.Name))
                {
                    editRoleViewModel.Users.Add(user.UserName);
                }
            }
            return View(editRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model, string RoleId)
        {
            var rol = await _roleManager.FindByIdAsync(RoleId);
            if (rol == null)
            {
                return View("~/notFound");
            }
            else
            {
                rol.Name = model.RoleName;
                IdentityResult result = await _roleManager.UpdateAsync(rol);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }
                return View(model);
            }

        }

        public async Task<IActionResult> DeleteRole(string RoleId)
        {
            var Role = await _roleManager.FindByIdAsync(RoleId);
            if (Role == null)
            {
                return View("~/NotFound");
            }
            else
            {
                var result = await _roleManager.DeleteAsync(Role);
                if (result.Succeeded)
                {

                    return RedirectToAction("ListRole");
                }

            }
            return View(Role);
        }

        public async Task<IActionResult> EditUserInRole(string RoleId)
        {
            ViewBag.RoleId = RoleId;
            var model2 = new List<EditUserInRoleViewModel>();

            var rol = await _roleManager.FindByIdAsync(RoleId);
            if (rol == null)
            {
                return View("~/NotFound");
            }
            foreach (var user in _userManager.Users)
            {
                EditUserInRoleViewModel editUserInRoleViewModel = new EditUserInRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if (await _userManager.IsInRoleAsync(user, rol.Name))
                {
                    editUserInRoleViewModel.IsSelected = true;
                }
                else
                {
                    editUserInRoleViewModel.IsSelected = false;
                }

                model2.Add(editUserInRoleViewModel);

            }

            return View(model2);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<EditUserInRoleViewModel> model, string RoleId)
        {

            var rol = await _roleManager.FindByIdAsync(RoleId);
            if (rol == null)
            {
                return View("~/NotFound");
            }

            for (var i = 0; i < model.Count; i++)
            {
                IdentityResult result = null;
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, rol.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, rol.Name);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, rol.Name))
                {

                    result = await _userManager.RemoveFromRoleAsync(user, rol.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < model.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { RoleId = RoleId });
                    }
                }
                else
                {
                    return RedirectToAction("EditRole", new { RoleId = RoleId });
                }


            }


            return RedirectToAction("EditRole", new { RoleId = RoleId });



        }



        [HttpGet]
        public IActionResult ListUser()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> DeleteUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return View("~/NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {

                    return RedirectToAction("ListUser");
                }

            }
            return View(user);
        }

        public async Task<IActionResult> EditUser(string UserId)

        {
            IdentityUser user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return View("NotFound");
            }
            var UserRoles = await _userManager.GetRolesAsync(user);
            var UserClaims = await _userManager.GetClaimsAsync(user);
            EditUserViewModel editUserViewModel = new EditUserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = UserRoles.ToList(),
                Claims = UserClaims.Select(c => c.Value).ToList()

            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            IdentityUser user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return View("NotFound");
            }
            user.UserName = model.UserName;
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ListUser");
            }
            return View(user);
        }

        public async Task<IActionResult> ManageUserRole(string UserId)
        {
            ViewBag.UserId = UserId;
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return View("NotFound");
            }
            var model = new List<ManageUserRoleViewModel>();
            foreach (var rol in _roleManager.Roles)
            {

                ManageUserRoleViewModel manageUserRoleViewModel = new ManageUserRoleViewModel
                {
                    RoleId = rol.Id,
                    RoleName = rol.Name

                };
                if (await _userManager.IsInRoleAsync(user, rol.Name))
                {
                    manageUserRoleViewModel.IsSelected = true;
                }
                else
                {
                    manageUserRoleViewModel.IsSelected = false;
                }

                model.Add(manageUserRoleViewModel);
            }
            return View(model);
        }
        /*
        [HttpPost]
        
            public async Task<IActionResult> ManageUserRole(List<ManageUserRoleViewModel> model, string UserId)
          {
              var user = await _userManager.FindByIdAsync(UserId);
              if(user==null)
              {
                  return View("notFound");
              }
            List<string> list = new List<string>();
               var roles= await _userManager.GetRolesAsync(user);
                 //List<string> result = new List<string>();
               var result  = await _userManager.RemoveFromRoleAsync(user, roles);


              if (!result.Succeeded)
              {

              }

               result = await _userManager.AddToRoleAsync(user,
                 model.Where(x => x.IsSelected).Select(y => y.RoleName));


              return RedirectToAction("EditUser", new { Id = UserId });
          }
          */
    
    
    
    
    }



}