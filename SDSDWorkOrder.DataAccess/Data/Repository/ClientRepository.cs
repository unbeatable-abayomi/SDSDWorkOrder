using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRespository
    {
        private readonly ApplicationDbContext _db;
        public ClientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetClientListForDropDown()
        {
            return _db.Client.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Client client)
        {
            var objFromDb = _db.Client.FirstOrDefault(s => s.Id == client.Id);
            objFromDb.Name = client.Name;
            objFromDb.CustomerUnqiueID = client.CustomerUnqiueID;
            _db.SaveChanges();
        }
    }
}
