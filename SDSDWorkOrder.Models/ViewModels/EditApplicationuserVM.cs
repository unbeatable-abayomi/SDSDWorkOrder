using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDWorkOrder.Models.ViewModels
{
  public class EditApplicationuserVM
    {
        public EditApplicationuserVM ()
        {
            Users = new List<ApplicationUser>();
        }
        public string Id { get; set; }

        
        public string FullName { get; set; }

        public string Email { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
