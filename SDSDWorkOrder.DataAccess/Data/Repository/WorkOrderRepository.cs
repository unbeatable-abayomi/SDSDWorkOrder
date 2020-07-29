using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _db.WorkOrders.Select(i => new SelectListItem()
            {
                Text = i.Details,
                Value = i.Id.ToString()
            });
        }


        //public IEnumerable<WorkOrders> GetWorkOrdersTo()
        //{
        //    return _db.WorkOrders.Include(x => x.Client);
        //}
        public void Update(WorkOrders workOrder)
        {
            var objFromDb = _db.WorkOrders.FirstOrDefault(s => s.Id == workOrder.Id);
            objFromDb.Details = workOrder.Details;
            objFromDb.Description = workOrder.Description;

            _db.SaveChanges();
        }
    }
}
