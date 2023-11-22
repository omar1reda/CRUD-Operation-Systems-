using AutoMapper;
using DemoBLL.Interfaces;
using DemoBLL.Repositores;
using DemoDAL.Models;
using DemoEL.Helpers;
using DemoEL.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace DemoEL.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IMapper _Mapper;
        public EmployeeController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _Mapper = Mapper;
        }


        public async Task< IActionResult> Index()
        {
          var Employees = await _unitOfWork.EmployeeRopositore.GetAllAsync( );

          var  EmployeeMapper = _Mapper.Map< IEnumerable<Employee>, IEnumerable<EmployeeViewModelcs>  >(Employees);

            return View(EmployeeMapper);
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Depurtments = await _unitOfWork.DepurtmentRepositore.GetAllAsync();
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModelcs employeeVM)
        {

            if (ModelState.IsValid)
            {
                string ImageName = await DocumentSettings.UploadFile(employeeVM.Image, "Image");
                employeeVM.ImageName = ImageName;

      
                var EmployeeMapper = _Mapper.Map<EmployeeViewModelcs, Employee>(employeeVM);
				await _unitOfWork.EmployeeRopositore.AddAsync(EmployeeMapper);

                int num = await _unitOfWork.Complete();

                if (num > 0)
                {
                    TempData["Message"] = "employee.added";
                }

                return  RedirectToAction(nameof(Index));
            }


            return View(employeeVM);
        }

        public async Task<IActionResult> Details(int id)
        {

           var employee = await _unitOfWork.EmployeeRopositore.GetByIdAsync(id);
            var EmployeeMapper= _Mapper.Map<Employee , EmployeeViewModelcs>(employee);
            return View(EmployeeMapper);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitOfWork.EmployeeRopositore.GetByIdAsync(id);
          
            var EmployeeMapper = _Mapper.Map<Employee, EmployeeViewModelcs>(employee);
            return View(EmployeeMapper);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeViewModelcs employeeVm)
        {
            var Employee = _Mapper.Map< EmployeeViewModelcs ,Employee >(employeeVm);
            _unitOfWork.EmployeeRopositore.Delete(Employee);
           int Result = await _unitOfWork.Complete();
            if(Result >0)
            {
                DocumentSettings.DeleteFile(employeeVm.ImageName, "Image");
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Depurtments = await _unitOfWork.DepurtmentRepositore.GetAllAsync();

            var Employee = await _unitOfWork.EmployeeRopositore.GetByIdAsync(id);
            var EmployeeVM = _Mapper.Map<Employee, EmployeeViewModelcs>(Employee);
            return View(EmployeeVM);
        }
        [HttpPost]
        public IActionResult Update(EmployeeViewModelcs EmployeeVM)
        {
            var employee = _Mapper.Map<EmployeeViewModelcs, Employee>(EmployeeVM);

            if (ModelState.IsValid)
            {

                 _unitOfWork.EmployeeRopositore.Update(employee);
              
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
           
            return View(EmployeeVM);
  
        }
        [HttpPost]
        public IActionResult SearchByName(string SearcInput)
        {
         
           var Employees = _unitOfWork.EmployeeRopositore.SearchByName(SearcInput.ToLower() );
          var EmployeeMapper=  _Mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeViewModelcs> >(Employees);
            return View("Index" , EmployeeMapper);
        }



    }
}
