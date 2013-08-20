using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarmaCustomerService.Controllers
{
    public class ConsumerController : Controller
    {
        private CarmaEntities db = new CarmaEntities();
        //
        // GET: /Consumer/

        public ActionResult ViewConsumer(Guid consumerTouchpointId)
        {
            ConsumerLogInInfo consumerLogInInfo =
                db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == consumerTouchpointId);
            return View();
        }

    }
}
