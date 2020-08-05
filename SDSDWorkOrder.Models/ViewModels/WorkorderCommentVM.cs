using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.Models.ViewModels
{
   public class WorkorderCommentVM
    {
        public WorkOrders WorkOrders { get; set; }
        public Comment  Comment { get; set; }
    }
}
