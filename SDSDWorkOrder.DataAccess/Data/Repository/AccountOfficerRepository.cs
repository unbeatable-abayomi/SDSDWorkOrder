using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository
{
   public class AccountOfficerRepository : Repository<AccountOfficer>, IAccountOfficer
    {
        private readonly ApplicationDbContext _db;

        public AccountOfficerRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetProductListForAccountOfficer()
        {
            return _db.AccountOfficers.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(AccountOfficer accountOfficer)
        {
            var objFromDb = _db.AccountOfficers.FirstOrDefault(s => s.Id == accountOfficer.Id);
            objFromDb.Name = accountOfficer.Name;

            _db.SaveChanges();
        }
    }
}
