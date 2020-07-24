using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;

namespace SDSDWorkOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Client client = new Client();
            if (id == null)
            {
                return View(client);
            }

            client = _unitOfWork.Client.Get(id.GetValueOrDefault());
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Client client)
        {
            if (ModelState.IsValid)
            {
                if(client.Id == 0)
                {
                    _unitOfWork.Client.Add(client);
                }
                else
                {
                    _unitOfWork.Client.Update(client);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Client.GetAll() });
        }

        [HttpDelete]

        public IActionResult Delete(int id)

        {

            var objFromDb = _unitOfWork.Client.Get(id);

            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting " });
            }
            _unitOfWork.Client.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
