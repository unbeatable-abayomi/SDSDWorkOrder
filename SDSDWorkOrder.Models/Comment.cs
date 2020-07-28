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

        [Display(Name = "Signed On Date")]
        [DataType(DataType.DateTime)]

        public DateTime CreatedDate
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;
        public int WorkOrderId { get; set; }
        public WorkOrders WorkOrder { get; set; }
       
    }
}
