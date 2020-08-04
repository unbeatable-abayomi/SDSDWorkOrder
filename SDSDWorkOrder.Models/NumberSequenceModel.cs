using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDWorkOrder.Models
{
   public class NumberSequenceModel
    {
        public int Id { get; set; }
     
        public string NumberSequenceName { get; set; }

        public string Module { get; set; }
        
        public string Prefix { get; set; }
        public int LastNumber { get; set; }
    }
}
