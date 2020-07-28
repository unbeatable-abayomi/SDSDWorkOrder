using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;

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

        [HttpGet]
        public IActionResult AddWorkOrder()
        {
            RandomNumber _randomNumber = new RandomNumber();
            ViewBag.RandomNumber ="#"+_randomNumber.GetRandomNumb();
       
            ViewBag.Clients = _unitOfWork.Client.GetClientListForDropDown();
            ViewBag.Products = _unitOfWork.Product.GetProductListForDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWorkOrder(WorkOrders workOrder)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WorkOrder.Add(workOrder);
            }
            return View();
        }

    }
}
