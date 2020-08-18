using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.Models.ViewModels
{
   public class WorkorderCommentVM
    {
        public int WorkOrderId { get; set; }
        public int CommentId { get; set; }
        public WorkOrders WorkOrders { get; set; }
        public Comment  Comment { get; set; }
    }
}
