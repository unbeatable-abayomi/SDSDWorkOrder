using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models.ViewModels
{
   public class CommentViewModel 
    {
        [Required]
        public int WorkOrderId { get; set; }
        public int CommentId { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public string User { get; set; }
        public bool PMApproval { get; set; }
        public bool ACApproval { get; set; }
        public bool MGApproval { get; set; }
        public int Count { get; set; }

    }
}
