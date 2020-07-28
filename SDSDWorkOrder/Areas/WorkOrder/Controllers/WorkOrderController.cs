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
        public IActionResult AddWorkOrder(WorkOrderViewModel vm)
        {



            var workorders = new WorkOrders
            {
                ClientId = vm.WorkOrders.ClientId,
                ProductId = vm.WorkOrders.ProductId,
                AccountManager = vm.WorkOrders.AccountManager,
                Details = vm.WorkOrders.Details,
                Description = vm.WorkOrders.Description,
                AnnualFDHAllowance = vm.WorkOrders.AnnualFDHAllowance,
                AnnualFDHBalance = vm.WorkOrders.AnnualFDHBalance,
                EstimatedDeliveryDate = vm.WorkOrders.EstimatedDeliveryDate,
                ExpectedDeliveryTime = vm.WorkOrders.ExpectedDeliveryTime,
                Country = vm.WorkOrders.Country,
                TimeChargeable = vm.WorkOrders.TimeChargeable

            };




            if (ModelState.IsValid)
            {
                _unitOfWork.WorkOrders.Add(workorders);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
             
            }
            return View();
        }

    }
}
