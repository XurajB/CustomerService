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
    
    public partial class ProductSatisfactionOld
    {
        public System.Guid ConsumerProductID { get; set; }
        public Nullable<int> LikelyToRecommendProduct { get; set; }
        public Nullable<int> LikelyToRecommendProduct6week { get; set; }
        public Nullable<int> LikelyToRecommendProduct6month { get; set; }
        public Nullable<int> LikelyToRecommendBrand6week { get; set; }
        public Nullable<int> LikelyToRecommendBrand6month { get; set; }
        public Nullable<int> LikelyToPurchaseBrand { get; set; }
        public Nullable<int> LikelyToPurchaseBrand6week { get; set; }
        public Nullable<int> LikelyToPurchaseBrand6month { get; set; }
        public Nullable<int> NumberOfTimesUsedID6week { get; set; }
        public Nullable<int> NumberOfTimesUsedID6month { get; set; }
        public Nullable<int> PerformanceExpectationLevelID6week { get; set; }
        public Nullable<int> PerformanceExpectationLevelID6month { get; set; }
        public Nullable<int> PurchasingActivityID6week { get; set; }
        public Nullable<int> PurchasingActivityID6month { get; set; }
        public Nullable<bool> ContactCustomerServiceByPhone6week { get; set; }
        public Nullable<bool> ContactCustomerServiceByPhone6month { get; set; }
        public Nullable<bool> ContactCustomerServiceByEmail6week { get; set; }
        public Nullable<bool> ContactCustomerServiceByEmail6month { get; set; }
        public Nullable<bool> VisitedWebSiteforProductInfo6week { get; set; }
        public Nullable<bool> VisitedWebSiteforProductInfo6month { get; set; }
        public Nullable<bool> VisitedWebSiteforProjectInfo6week { get; set; }
        public Nullable<bool> VisitedWebSiteforProjectInfo6month { get; set; }
        public Nullable<bool> VisitedWebSiteforCustServiceInfo6week { get; set; }
        public Nullable<bool> VisitedWebSiteforCustServiceInfo6month { get; set; }
        public Nullable<bool> VisitedWebSiteforAnyOtherReason6week { get; set; }
        public Nullable<bool> VisitedWebSiteforAnyOtherReason6month { get; set; }
        public Nullable<bool> VisitedServiceCenter6week { get; set; }
        public Nullable<bool> VisitedServiceCenter6month { get; set; }
        public Nullable<bool> ReceivedEmailFromBrand6week { get; set; }
        public Nullable<bool> ReceivedEmailFromBrand6month { get; set; }
        public Nullable<bool> DoNotRecallAny6week { get; set; }
        public Nullable<bool> DoNotRecallAny6month { get; set; }
        public string PositiveFeedback6week { get; set; }
        public string PositiveFeedback6month { get; set; }
        public string ConstructiveFeedback6week { get; set; }
        public string ConstructiveFeedback6month { get; set; }
        public Nullable<System.DateTime> Date6weekSurveyTaken { get; set; }
        public Nullable<System.DateTime> Date6monthSurveyTaken { get; set; }
        public Nullable<System.DateTime> DateMostRecentResponse { get; set; }
    
        public virtual ConsumerProduct ConsumerProduct { get; set; }
    }
}
