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
    
    public partial class ConsumerOptIn
    {
        public System.Guid ConsumerTouchPointID { get; set; }
        public System.Guid OptInID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool OptInStatus { get; set; }
    
        public virtual ConsumerTouchPointProfile ConsumerTouchPointProfile { get; set; }
    }
}