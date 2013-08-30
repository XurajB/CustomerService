using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarmaCustomerService.BI.LisTrakClient;
using CarmaCustomerService.Dto;

namespace CarmaCustomerService.BI
{
    public class LisTrakService
    {
        static WSUser _wsUser= new WSUser
            {
                UserName = System.Configuration.ConfigurationManager.AppSettings["LisTrakUserName"],
                Password = System.Configuration.ConfigurationManager.AppSettings["LisTrakPassword"]
            };

        public static LisTrakSubscriberDto CheckSubscription(LisTrakRequestDto request)
        {
            try
            {
                var listrakWs = new IntegrationServiceSoapClient();
                var contact = listrakWs.GetContact(_wsUser, request.ListId, request.EmailAddress);
                if (contact == null) return null;

                var subscriberDto = new LisTrakSubscriberDto
                    {
                        Email = contact.EmailAddress,
                        ListId = contact.ListID,
                        ListName = request.ListName
                    };
                return subscriberDto;
            }
            catch (Exception exception)
            {
                //exception
                return null;
            }
        }

        public static Boolean UnsubscribeSubscription(LisTrakRequestDto request)
        {
            try
            {
                var listrakWs = new IntegrationServiceSoapClient();
                var contact = listrakWs.UnsubscribeContact(_wsUser, request.ListId, request.EmailAddress);
            }
            catch (Exception exception)
            {
                //exception
                return false;
            }
            return true;
        }

        public static List<LisTrakSubscriberDto> GetSubscriberList(string email, int brandId)
        {
            var lisTrakSubscriberDtos  = new List<LisTrakSubscriberDto>();
            
            var bdLists = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(290056, "Black and Decker Promo"),
                    new KeyValuePair<int, string>(290060, "Black and Decker Research"),
                    new KeyValuePair<int, string>(290059, "Black and Decker Platnum")
                };
            var dewaltLists = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(290067, "DeWalt Promo"),
                    new KeyValuePair<int, string>(290076, "DeWalt Research")
                };

            var pcLists = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(291020, "Porter Cable Research"),
                    new KeyValuePair<int, string>(290058, "Porter Cable Promo")
                };

            var allLists = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(290056, "Black and Decker Promo"),
                    new KeyValuePair<int, string>(290060, "Black and Decker Research"),
                    new KeyValuePair<int, string>(290059, "Black and Decker Platnum"),
                    new KeyValuePair<int, string>(290067, "DeWalt Promo"),
                    new KeyValuePair<int, string>(290076, "DeWalt Research"),
                    new KeyValuePair<int, string>(291020, "Porter Cable Research"),
                    new KeyValuePair<int, string>(290058, "Porter Cable Promo")
                };

            switch (brandId)
            {
                case 0:
                    lisTrakSubscriberDtos.AddRange(allLists.Select(allList => new LisTrakRequestDto()
                    {
                       EmailAddress = email, 
                       ListId = allList.Key, 
                       ListName = allList.Value
                    }).Select(CheckSubscription));
                    break;
                case 1:
                    lisTrakSubscriberDtos.AddRange(bdLists.Select(bdList => new LisTrakRequestDto()
                    {
                       EmailAddress = email, 
                       ListId = bdList.Key, 
                       ListName = bdList.Value
                    }).Select(CheckSubscription));
                    break;
                case 2:
                    lisTrakSubscriberDtos.AddRange(dewaltLists.Select(dewaltList => new LisTrakRequestDto()
                    {
                        EmailAddress = email,
                        ListId = dewaltList.Key,
                        ListName = dewaltList.Value
                    }).Select(CheckSubscription));
                    break;
                case 4:
                    lisTrakSubscriberDtos.AddRange(pcLists.Select(pclist => new LisTrakRequestDto()
                    {
                        EmailAddress = email,
                        ListId = pclist.Key,
                        ListName = pclist.Value
                    }).Select(CheckSubscription));
                    break;
            }

            return lisTrakSubscriberDtos;
        }
    }
}
