using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetProductListForDropDown()
        {
            return _db.Product.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Product.FirstOrDefault(s => s.Id == product.Id);
            objFromDb.Name = product.Name;

            _db.SaveChanges();
        }
    }
}
