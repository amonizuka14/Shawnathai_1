//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShawnaThai_Eiei.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product_rice
    {
        public product_rice()
        {
            this.history_sell = new HashSet<history_sell>();
        }
    
        public int ProD_IDSell { get; set; }
        public string ProD_Topic { get; set; }
        public string ProD_Pic { get; set; }
        public string ProD_Moisture { get; set; }
        public string ProD_Weight { get; set; }
        public string ProD_Price { get; set; }
        public string ProD_CertiWeightRice { get; set; }
        public string RType_Name { get; set; }
        public string Farmer_IDCard { get; set; }
    
        public virtual farmer farmer { get; set; }
        public virtual ICollection<history_sell> history_sell { get; set; }
        public virtual ricetype ricetype { get; set; }
    }
}