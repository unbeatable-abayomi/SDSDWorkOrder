using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models
{
  public  class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Client's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        //[Display(Name = "Annual FDH Allowance")]
        //public int? FDHAllowance { get; set; }

        //[Display(Name = "Avaliable FDH Balance")]
        //public int? FDHBalance { get; set; }
        //[Display(Name = "SDSD Unqiue Customer ID ")]
        //public string CustomerUnqiueID { get; set; }
    }
}
