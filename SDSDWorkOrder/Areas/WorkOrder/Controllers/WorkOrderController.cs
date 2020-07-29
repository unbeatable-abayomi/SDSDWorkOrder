using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using SDSDWorkOrder.Models.ViewModels;

namespace SDSDWorkOrder.Areas.WorkOrder.Controllers
{
    [Area("WorkOrder")]
    public class WorkOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public WorkOrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
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

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            //return Json(new { data = _unitOfWork.WorkOrders.GetWorkOrdersTo() });
            return Json(new { data = _unitOfWork.WorkOrders.GetAll(includeProperties: "Client,Product") });
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
