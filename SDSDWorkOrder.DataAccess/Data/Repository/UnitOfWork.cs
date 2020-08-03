using SDSDWorkOrder.DataAccess.Data.Repository.IRepository;
using SDSDWorkOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Client = new ClientRepository(_db);
            Product = new ProductRepository(_db);
            WorkOrders = new WorkOrderRepository(_db);
            AccountOfficers = new AccountOfficerRepository(_db);
        }
        public IClientRespository Client { get; private set; }
        public IProductRepository Product { get; private set; }
        public IWorkOrder WorkOrders { get; private set; }
        public IAccountOfficer AccountOfficers { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }





}
