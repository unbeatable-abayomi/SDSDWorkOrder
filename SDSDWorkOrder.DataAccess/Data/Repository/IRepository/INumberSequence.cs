using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.DataAccess.Data.Repository.IRepository
{
  public  interface INumberSequence
    {
        string GetNumberSequence(string module);
    }
}
