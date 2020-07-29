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

       
        [Display(Name = "Location")]
        public string Location { get; set; }
      
        [Display(Name = "Client ID ")]
        public string CustomerId { get; set; }
    }
}
