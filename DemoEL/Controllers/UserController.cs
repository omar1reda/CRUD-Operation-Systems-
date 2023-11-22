using AutoMapper;
using DemoBLL.Repositores;
using DemoDAL.Models;
using DemoEL.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEL.Controllers
{
    //[Authorize]
    public class UserController : Controller
	{
        private UserManager<ApplicationUser> _UserManager { get; }
        public IMapper _UnitOfWork { get; }

        public UserController(UserManager<ApplicationUser> userManager , IMapper unitOfWork )
		{
			_UserManager = userManager;
            _UnitOfWork = unitOfWork;
        }

		
        #region Index///////
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (SearchValue == null)
            {
                var users = await _UserManager.Users.Select(U => new UserViewModel()
                {
                    Id = U.Id,
                    FName = U.FName,
                    LName = U.LName,
                    Email = U.Email,
                    Roles = _UserManager.GetRolesAsync(U).Result
                }).ToListAsync();

                return View(users);
            }
            else
            {
                var UserSearch = await _UserManager.FindByEmailAsync(SearchValue);
                if(UserSearch != null)
                {
                    var User = new UserViewModel()
                    {
                        Id = UserSearch.Id,
                        FName = UserSearch.FName,
                        LName = UserSearch.LName,
                        Email = UserSearch.Email,
                        Roles = await _UserManager.GetRolesAsync(UserSearch)
                    };

                    return View(new List<UserViewModel> { User });
                }
                return View(new List<UserViewModel>());

            }


        }
        #endregion

        #region Update ////////

        public async Task< IActionResult> Update(string id)
        {
            var user = await _UserManager.FindByIdAsync(id);
           var UserMpp = _UnitOfWork.Map<ApplicationUser, UserViewModel>(user);
            return View(UserMpp);
            
        }
        [HttpPost]
        public async Task< IActionResult> Update(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByIdAsync(model.Id);

                if (user != null)
                {
                   user.Email = model.Email;
                   user.FName = model.FName;
                   user.LName = model.LName;
                 

                   await _UserManager.UpdateAsync(user);
                    return RedirectToAction("Index");
                }
                
            }
            return View(model);
        }
        #endregion

        #region Details /////////

        public async Task< IActionResult> Details(string id)
        {
            var User = await _UserManager.FindByIdAsync(id);

            if (User != null)
            {
                var UserMapp = _UnitOfWork.Map<ApplicationUser, UserViewModel>(User);
                return View(UserMapp);
            }
            else { return View(null); }
         
        }
        #endregion

        #region Delete/////////////

        public async Task< IActionResult> Delete(string id)
        {
            var user =await _UserManager.FindByIdAsync(id);
           
                var usermapp = _UnitOfWork.Map<ApplicationUser, UserViewModel>(user);
                return View(usermapp);
            

        }
        [HttpPost]
        public async Task<IActionResult> Delete(UserViewModel model)
        {
            var user = await _UserManager.FindByIdAsync(model.Id);

            await _UserManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));


        }

        #endregion

    }
}
