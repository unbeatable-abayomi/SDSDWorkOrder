using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models
{
  public  class WorkOrders
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        
        [Display(Name = "Title")]
        public string Details { get; set; }
        
        [Required]
       
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Client Name")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        [Display(Name = "Select Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
      
        [Display(Name = "Annual FDH Allowance")]
        public string AnnualFDHAllowance { get; set; }

        [Display(Name = "Available FDH Balance")]

        public string AnnualFDHBalance { get; set; }



        //public DateTime CreatedTime { get; set; } = DateTime.Now

        [Display(Name = "Request Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,MM,yyyy}", ApplyFormatInEditMode = true)]
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
        
        [Display(Name ="Estimated Delivery Date")]
        public DateTime EstimatedDeliveryDate { get; set; }
      
        [Display(Name = "Expected Delivery Time")]
        public string ExpectedDeliveryTime { get; set; }

      


    
        [Display (Name="Time Chargeable")]
        public string TimeChargeable { get; set; }
      
        
        ///enums
       
        
        [Display(Name ="Countries")]
        public Country Country { get; set; }

        [Display(Name = "Account Manager")]
        public AccountManager AccountManager { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
        //[Required]
        //[Display(Name = "Created By")]

        //public string CreatedBy { get; set; }


        //[Display(Name = "Resource")]
        //public IdentityUser UserTwo { get; set; }

        //[Display(Name = "Project Manager")]
        //public IdentityUser UserThree { get; set; }
    }


    public enum AccountManager
    {
        Morgens,Micheal
    }

 


}
