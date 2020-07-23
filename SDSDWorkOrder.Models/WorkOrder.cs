using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models
{
  public  class WorkOrder
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        [Display(Name = "Describe Work Order")]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Client Name")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        [Display(Name = "Select Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
      


        [Display(Name = "Created Date")]
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





        [Required]
        [Display(Name ="Created By")]

        public string CreatedBy { get; set; }

       
        [Display(Name = "Resource")]
        public IdentityUser UserTwo { get; set; }

        [Display(Name = "Project Manager")]
        public IdentityUser UserThree { get; set; }

        //public bool IsApproved { get; set; }
        //public  { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
