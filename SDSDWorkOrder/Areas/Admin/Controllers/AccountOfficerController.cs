using Microsoft.AspNetCore.Mvc;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDSDWorkOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountOfficerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public AccountOfficerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            AccountOfficer accountOfficer = new AccountOfficer();
            if (id == null)
            {
                return View(accountOfficer);
            }

            accountOfficer = _unitOfWork.AccountOfficers.Get(id.GetValueOrDefault());
            if (accountOfficer == null)
            {
                return NotFound();
            }

            return View(accountOfficer);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AccountOfficer accountOfficer)
        {
            if (ModelState.IsValid)
            {
                if (accountOfficer.Id == 0)
                {
                    _unitOfWork.AccountOfficers.Add(accountOfficer);
                }
                else
                {
                    _unitOfWork.AccountOfficers.Update(accountOfficer);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(accountOfficer);
        }

        #region API CALLS


        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.AccountOfficers.GetAll() });
        }
        #endregion
    }
}
