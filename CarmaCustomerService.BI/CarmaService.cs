using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarmaCustomerService.BI.ConsumerServiceClient;

namespace CarmaCustomerService.BI
{
    public  class CarmaService
    {
        private static ConsumerServiceContractClient _consumerServiceContract;
        public bool SendPasswordRecoveryEmail(String email, int websiteCode)
        {
            _consumerServiceContract = new ConsumerServiceContractClient();
            try
            {
                switch (websiteCode)
                {
                    case 2:
                        _consumerServiceContract.SendPasswordRecoveryEmail(email, Websites.DeWALT);
                        break;
                    case 1:
                        _consumerServiceContract.SendPasswordRecoveryEmail(email, Websites.BlackAndDecker);
                        break;
                    case 4:
                        _consumerServiceContract.SendPasswordRecoveryEmail(email, Websites.DeltaPorterCable);
                        break;
                }
            }
            catch (Exception exception)
            {
                //Exception
                return false;
            }
            return true;
        }
    }
}
