using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository.IRepository
{
   public interface IWorkOrder : IRepository<WorkOrders>
    {
        IEnumerable<SelectListItem> GetWorkLOrderistForDropDown();
        void Update(WorkOrders workOrder);
      
    }
}
