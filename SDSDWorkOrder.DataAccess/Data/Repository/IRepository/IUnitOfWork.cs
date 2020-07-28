using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork  : IDisposable
    {
       IClientRespository Client  { get; }
        IProductRepository Product { get; }
        IWorkOrder WorkOrders { get; }
        void Save();
    }
}
