using AutoMapper;
using DemoEL.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEL.Controllers
{
    //[Authorize]
    public class RolesController : Controller
    {
        public RolesController(RoleManager<IdentityRole> userRole , IMapper mapper)
        {
            _UserRole = userRole;
            _Mapper = mapper;
        }

        public RoleManager<IdentityRole> _UserRole { get; }
        public IMapper _Mapper { get; }

        public async Task< IActionResult> Index(string SearchValue)
        {
            if (SearchValue == null)
            {
                var roles = await _UserRole.Roles.ToListAsync();

               var RolesMapp =  _Mapper.Map<IEnumerable<IdentityRole>, IEnumerable<RoleViewModel>>(roles);
               return View(RolesMapp);
            }
            else
            {
                var role = await _UserRole.FindByNameAsync(SearchValue);

    
                if(role!=null)
                {
                    var RoleMapp = _Mapper.Map<IdentityRole, RoleViewModel>(role);
                    return View(new List<RoleViewModel>() { RoleMapp });
                }
                return View(new List<RoleViewModel>());
                
            }
 
        }



        public IActionResult Create()
        {

            return View();  
        }
        [HttpPost]
        public async Task< IActionResult> Create( RoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userRole = _Mapper.Map<RoleViewModel, IdentityRole>(model);
              var userMapp = await _UserRole.CreateAsync(userRole);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task< IActionResult> Update(string id)
        {
            var Role = await _UserRole.FindByIdAsync(id);

            var userView = _Mapper.Map< IdentityRole, RoleViewModel> (Role);

            return View(userView);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoleViewModel model)
        {

        var role=  await _UserRole.FindByIdAsync (model.Id);
            role.Name  = model.Name;

           await _UserRole.UpdateAsync(role);
           

            return RedirectToAction(nameof(Index));
        }

        public async Task< IActionResult> Delete(string id)
        {
            var Role = await _UserRole.FindByIdAsync(id);

            var userView = _Mapper.Map<IdentityRole, RoleViewModel>(Role);

            return View(userView);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoleViewModel model)
        {

            var role = await _UserRole.FindByIdAsync(model.Id);

            await _UserRole.DeleteAsync(role);


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            var Role = await _UserRole.FindByIdAsync(id);

            var userView = _Mapper.Map<IdentityRole, RoleViewModel>(Role);

            return View(userView);
        }
     

    }
}
