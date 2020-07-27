using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models
{
  public  class ApplicationRole : IdentityUserRole
    {
        [Key]
        public Guid Id { get; set; }

        [Required, Display(Name ="Name")]
        public string RoleName { get; set; }
    }
}
