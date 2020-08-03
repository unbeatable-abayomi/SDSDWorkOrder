using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models
{
    public  class Comment
    {
        [Key]
        public int Id { get; set; }
 
        [Required]
        [Display(Name = "Comments")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Display(Name = "Date Of Comment")]

        public string User { get; set; }

        public DateTime CreatedDate { get; set; }
       
        public int WorkOrderId { get; set; }
        public WorkOrders WorkOrder { get; set; }
       
    }
}
