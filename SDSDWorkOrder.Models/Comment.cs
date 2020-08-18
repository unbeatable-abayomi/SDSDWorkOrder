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
        public string User { get; set; }

        [Display(Name = "Date ")]
        public DateTime CreatedDate { get; set; }
       
        public int WorkOrderId { get; set; }
        public WorkOrders WorkOrder { get; set; }
        [Display(Name = "Project Managers's Approval")]
        public bool PMApproval { get; set; }
        [Display(Name = "Account Officer's Approval")]
        public bool ACApproval { get; set; }
        [Display(Name = "Managements's Approval")]
        public bool MGApproval { get; set; }
        public int Count { get; set; }

    }
}
