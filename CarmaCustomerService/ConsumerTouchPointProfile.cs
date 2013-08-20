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
    
    public partial class ConsumerTouchPointProfile
    {
        public ConsumerTouchPointProfile()
        {
            this.ConsumerOptIns = new HashSet<ConsumerOptIn>();
            this.ConsumerProducts = new HashSet<ConsumerProduct>();
        }
    
        public System.Guid ConsumerTouchPointID { get; set; }
        public System.Guid TouchPointID { get; set; }
        public Nullable<System.Guid> MasterConsumerID { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NameLast { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateLastEdited { get; set; }
        public Nullable<int> EquifaxContactID { get; set; }
        public int NumberOfVisits { get; set; }
        public string PageJoinedFrom { get; set; }
        public string SiteReferredFrom { get; set; }
        public int DeWaltMemberID { get; set; }
    
        public virtual ConsumerDemographic ConsumerDemographic { get; set; }
        public virtual ConsumerLogInInfo ConsumerLogInInfo { get; set; }
        public virtual ICollection<ConsumerOptIn> ConsumerOptIns { get; set; }
        public virtual ICollection<ConsumerProduct> ConsumerProducts { get; set; }
    }
}
