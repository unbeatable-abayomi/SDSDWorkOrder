﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models
{
   public class ApplicationUser : IdentityUser
    {
        
         public string FullName { get; set; }




    }
}
