using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository.IRepository
{
   public interface IClientRespository : IRepository<Client>
    {
        IEnumerable<SelectListItem> GetClientListForDropDown();
        void Update(Client client );
    }
}
