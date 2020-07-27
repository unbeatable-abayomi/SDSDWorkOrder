using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository.IRepository
{
  public  interface IProductRepository : IRepository<Product>
    {
        IEnumerable<SelectListItem> GetProductListForDropDown();
        void Update(Product product);
    }
}
