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
    
    public partial class cooperative
    {
        public cooperative()
        {
            this.admin_cooperative = new HashSet<admin_cooperative>();
            this.farmer = new HashSet<farmer>();
        }
    
        public string Coop_Name { get; set; }
        public string Coop_Tel { get; set; }
        public string Coop_Latitude { get; set; }
        public string Coop_Longitude { get; set; }
        public string Coop_A_No { get; set; }
        public string Coop_A_Sup { get; set; }
        public string Coop_A_District { get; set; }
        public string Coop_A_Province { get; set; }
    
        public virtual ICollection<admin_cooperative> admin_cooperative { get; set; }
        public virtual ICollection<farmer> farmer { get; set; }
    }
}
