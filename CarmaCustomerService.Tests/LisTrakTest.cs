using System;
using CarmaCustomerService.BI;
using CarmaCustomerService.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarmaCustomerService.Tests
{
    [TestClass]
    public class ListrakTest
    {
        [TestMethod]
        public void CheckSubscription()
        {
            var lisTrakRequestDto = new LisTrakRequestDto()
                {
                    ListId = 294003,
                    EmailAddress = "barney.rubble@gmail.com"
                };
            Assert.AreEqual(1.005,lisTrakRequestDto.EmailAddress,LisTrakService.CheckSubscription(lisTrakRequestDto).Email);
        }

        [TestMethod]
        public void UnsubscribeSubscriber()
        {
            var lisTrakRequestDto = new LisTrakRequestDto()
                {
                    ListId = 294003,
                    EmailAddress = "barney.rubble@gmail.com"
                };
            Assert.IsTrue(LisTrakService.UnsubscribeSubscription(lisTrakRequestDto));

        }

        [TestMethod]
        public void GetSubscriptionList()
        {
            var list = LisTrakService.GetSubscriberList("suraj.bhattarai@sbdinc.com", 1);
            Console.WriteLine(list.Count);
        }
    }
}
