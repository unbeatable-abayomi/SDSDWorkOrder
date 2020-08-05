using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SDSDWorkOrder.DataAccess.Data.Repository.IRepository
{
   public interface IWorkOrder : IRepository<WorkOrders>
    {
        IEnumerable<SelectListItem> GetWorkLOrderistForDropDown();
        void Update(WorkOrders workOrder);
        WorkOrders Details(int? id);
        

        


    }
}
