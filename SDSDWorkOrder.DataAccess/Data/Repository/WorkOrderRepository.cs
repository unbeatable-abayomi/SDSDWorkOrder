using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository
{
   public class WorkOrderRepository : Repository<WorkOrders>, IWorkOrder
    {
        private readonly ApplicationDbContext _db;
        public WorkOrderRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetWorkLOrderistForDropDown()
        {
            return _db.WorkOrder.Select(i => new SelectListItem()
            {
                Text = i.Details,
                Value = i.Id.ToString()
            });
        }

        public void Update(WorkOrders workOrder)
        {
            var objFromDb = _db.WorkOrder.FirstOrDefault(s => s.Id == workOrder.Id);
            objFromDb.Details = workOrder.Details;
            objFromDb.Description = workOrder.Description;

            _db.SaveChanges();
        }
    }
}
