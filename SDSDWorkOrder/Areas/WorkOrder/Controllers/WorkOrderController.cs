﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDSDWorkOrder.DataAccess.Data;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using SDSDWorkOrder.Models.ViewModels;

namespace SDSDWorkOrder.Areas.WorkOrder.Controllers
{
    [Area("WorkOrder")]
    public class WorkOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public WorkOrderController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddWorkOrder(int? id)
        {
            RandomNumber _randomNumber = new RandomNumber();
            ViewBag.RandomNumber ="#"+_randomNumber.GetRandomNumb();
       
            ViewBag.Clients = _unitOfWork.Client.GetClientListForDropDown();
            ViewBag.Products = _unitOfWork.Product.GetProductListForDropDown();

            WorkOrders workOrders = new WorkOrders();

            if (id == null)
            {
                return View(workOrders);
            }

            workOrders = _unitOfWork.WorkOrders.Get(id.GetValueOrDefault());
            if(workOrders == null)
            {
                return NotFound();
            }
            return View(workOrders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.WorkOrders.Include(x => x.Comments).Include(x => x.Product).Include(x => x.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWorkOrder(WorkOrders workorders)
        {

            ViewBag.Clients = _unitOfWork.Client.GetClientListForDropDown();
            ViewBag.Products = _unitOfWork.Product.GetProductListForDropDown();

            if (ModelState.IsValid)
            {
                if (workorders.Id == 0)
                {
                    _unitOfWork.WorkOrders.Add(workorders);
                }
                else
                {
                    _unitOfWork.WorkOrders.Update(workorders);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
             
             
            }
            return View(workorders);
        }
        public IActionResult AllWorkOrder ()
        {
            var result = _context.WorkOrders.Include(x => x.Comments).ToList();
            return View(result);
        }


       

        public IActionResult Comment(CommentViewModel Vmodel)
        {


            //var result = _unitOfWork.WorkOrders.Details(Vmodel.WorkOrderId);
            var result = _context.WorkOrders.Include(p => p.Comments).FirstOrDefault(x => x.Id == Vmodel.WorkOrderId);
           


            if (ModelState.IsValid)
            {

                result.Comments.Add(new Comment
                {
                    Id = Vmodel.CommentId,
                    Text = Vmodel.Text,
                    CreatedDate = DateTime.Now,
                    User = "Ifeanyi"
                }) ;

                _unitOfWork.WorkOrders.Update(result);

            }
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }


        #region

            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public IActionResult Upsert(Client client)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        if (client.Id == 0)
            //        {
            //            _unitOfWork.Client.Add(client);
            //        }
            //        else
            //        {
            //            _unitOfWork.Client.Update(client);
            //        }
            //        _unitOfWork.Save();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(client);
            //}
            #endregion Upser
            #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            //return Json(new { data = _unitOfWork.WorkOrders.GetWorkOrdersTo() });
            return Json(new { data = _unitOfWork.WorkOrders.GetAll(includeProperties:"Product,Client") });
        }

        [HttpDelete]

        public IActionResult Delete(int id)

        {

            var objFromDb = _unitOfWork.WorkOrders.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting " });
            }
            _unitOfWork.WorkOrders.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion

    }
}
