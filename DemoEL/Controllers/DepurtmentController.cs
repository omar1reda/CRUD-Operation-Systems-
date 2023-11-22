using AutoMapper;
using DemoBLL.Interfaces;
using DemoBLL.Repositores;
using DemoDAL.Models;
using DemoEL.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEL.Controllers
{
    //[Authorize]
    public class DepurtmentController : Controller
    {
   
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _Mapper;
        public DepurtmentController(IUnitOfWork unitOfWork , IMapper Mapper)

        {
         
            _unitOfWork = unitOfWork;
            _Mapper = Mapper;
        }
        public   async Task< IActionResult> Index()
        {
          var Depurtments = await _unitOfWork.DepurtmentRepositore.GetAllAsync();
            var depurtmentMapper = _Mapper.Map<IEnumerable<Depurtment>, IEnumerable<DepurtmentViewModelcs>>(Depurtments);
            return View(depurtmentMapper );
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Add(DepurtmentViewModelcs depurtmentVM)
        {
            if (ModelState.IsValid)
            {
                var Depurtment = _Mapper.Map<DepurtmentViewModelcs, Depurtment>(depurtmentVM);
                await _unitOfWork.DepurtmentRepositore.AddAsync(Depurtment);
                int num = await _unitOfWork.Complete();
                if (num > 0)
                {
                    TempData["Message"] = "Depurtment.added";
                }
                return RedirectToAction(nameof(Index));
            }

            return View(depurtmentVM);

        }

        public async Task< IActionResult> Details( int id)
        {
          var depurtment = await _unitOfWork.DepurtmentRepositore.GetByIdAsync(id);
            var DepurtmentVm = _Mapper.Map<Depurtment,DepurtmentViewModelcs>(depurtment);
            return View(DepurtmentVm);
        }

        public  async Task< IActionResult> Update(int id)
        {
            var depurtment = await _unitOfWork.DepurtmentRepositore.GetByIdAsync(id);
            var DepurtmentVm = _Mapper.Map<Depurtment, DepurtmentViewModelcs>(depurtment);
            return View(DepurtmentVm);

        }
        [HttpPost]
        public async Task< IActionResult> Update(DepurtmentViewModelcs depurtmentVM)
        {
          
            if (ModelState.IsValid)
            {
                var Depurtment = _Mapper.Map<DepurtmentViewModelcs, Depurtment>(depurtmentVM);
                _unitOfWork.DepurtmentRepositore.Update(Depurtment);
               await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(depurtmentVM);

        }



        public async Task< IActionResult> Delete(int id)
        {
            var depurtment = await _unitOfWork.DepurtmentRepositore.GetByIdAsync(id);
            var DepurtmentVm = _Mapper.Map<Depurtment, DepurtmentViewModelcs>(depurtment);
            return View(DepurtmentVm);
        }
        [HttpPost]
        public async Task< IActionResult> Delete(DepurtmentViewModelcs depurtmentVm)
        {
            var Depurtment = _Mapper.Map<DepurtmentViewModelcs, Depurtment>(depurtmentVm);
            _unitOfWork.DepurtmentRepositore.Delete(Depurtment);
           await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

    }
}
