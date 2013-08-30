//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarmaCustomerService
{
    using System;
    using System.Collections.Generic;
    
    public partial class TouchPoint
    {
        public TouchPoint()
        {
            this.ConsumerLogInInfoes = new HashSet<ConsumerLogInInfo>();
            this.ConsumerProducts = new HashSet<ConsumerProduct>();
            this.ConsumerTouchPointProfiles = new HashSet<ConsumerTouchPointProfile>();
        }
    
        public System.Guid TouchPointID { get; set; }
        public string TouchPointNameShort { get; set; }
        public string TouchPointNameLong { get; set; }
        public Nullable<System.Guid> TouchPointTypeID { get; set; }
        public System.Guid TouchPointSystemID { get; set; }
        public int BrandID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateStarted { get; set; }
        public Nullable<System.DateTime> DateEnded { get; set; }
        public bool IsActive { get; set; }
        public string SourceKey { get; set; }
    
        public virtual ICollection<ConsumerLogInInfo> ConsumerLogInInfoes { get; set; }
        public virtual ICollection<ConsumerProduct> ConsumerProducts { get; set; }
        public virtual ICollection<ConsumerTouchPointProfile> ConsumerTouchPointProfiles { get; set; }
    }
}