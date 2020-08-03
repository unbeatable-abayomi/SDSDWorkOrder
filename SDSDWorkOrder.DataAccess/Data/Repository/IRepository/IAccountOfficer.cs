using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository.IRepository
{
  public interface IAccountOfficer : IRepository<AccountOfficer>
    {
        IEnumerable<SelectListItem> GetProductListForAccountOfficer();
        void Update(AccountOfficer accountOfficer);
    }
}
