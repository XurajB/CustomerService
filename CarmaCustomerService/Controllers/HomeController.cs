using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarmaCustomerService.Controllers
{
    public class HomeController : Controller
    {
        private CarmaEntities db = new CarmaEntities();

        public ActionResult Index()
        {

            LoadSpinners();
            return View(db.ConsumerLogInInfoes.Take(50));
        }

        [HttpGet, ActionName("Search")]
        public ActionResult Search(string searchText = null, int brands = 0, int searchType=0)
        {
            //Touchpoint IDs for major brands - registration via web
            var touchpointBd = new Guid("7F1ACBE2-E485-4B06-B4DF-39B4C4C6C967");
            var touchpointDewalt = new Guid("9729D6AF-23A8-4650-92E1-47A6249C0723");
            var touchpointPc = new Guid("68BADDAC-C1E5-4420-87BC-C303848CA636");
            var touchpointBdp = new Guid("7CACAE47-8274-4C00-B111-AFA49F261902");

            IEnumerable<ConsumerLogInInfo> consumerLogInInfos = null;
            //System.Threading.Thread.Sleep(1000);
            if (searchText == string.Empty)
            {
                consumerLogInInfos = db.ConsumerLogInInfoes.Take(50);
            }
            else
            {
                var touchpointId = new Guid();
                switch (brands)
                {
                    case 0:
                        touchpointId = touchpointDewalt;
                        break;
                    case 1:
                        touchpointId = touchpointBd;
                        break;
                    case 2:
                        touchpointId = touchpointPc;
                        break;
                    case 4:
                        touchpointId = touchpointBdp;
                        break;

                }
                switch (searchType)
                {
                    case 0:
                        consumerLogInInfos = brands==3 ? db.ConsumerLogInInfoes.Where(x => x.UserID.Contains(searchText)) : db.ConsumerLogInInfoes.Where(x => x.UserID.Contains(searchText) && x.TouchPointID.Equals(touchpointId));
                        break;
                    case 1:
                        consumerLogInInfos = brands==3 ? db.ConsumerLogInInfoes.Where(x => x.ConsumerTouchPointProfile.NameFirst.Contains(searchText)) : db.ConsumerLogInInfoes.Where(x => x.ConsumerTouchPointProfile.NameFirst.Contains(searchText) && x.TouchPointID.Equals(touchpointId));
                        break;
                    case 2:
                        consumerLogInInfos = brands==3 ? db.ConsumerLogInInfoes.Where(x => x.ConsumerTouchPointProfile.NameLast.Contains(searchText)) : db.ConsumerLogInInfoes.Where(x => x.ConsumerTouchPointProfile.NameLast.Contains(searchText) && x.TouchPointID.Equals(touchpointId));
                        break;
                }

            }

            LoadSpinners();

            return View("Index", consumerLogInInfos);
        }

        [HttpGet]
        public ActionResult View(Guid? id)
        {
            ConsumerLogInInfo consumerLogInInfo =
                db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == id);

            LoadSpinners();

            return View(consumerLogInInfo);
        }

        public void LoadSpinners()
        {
            var items = new List<SelectListItem>
                {
                    new SelectListItem {Text = "All Brands", Value = "3"},
                    new SelectListItem {Text = "DeWalt", Value = "0"},
                    new SelectListItem {Text = "Black and Decker", Value = "1"},
                    new SelectListItem {Text = "Porter Cable", Value = "2"},
                };
            var searchFilter = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Email", Value = "0"},
                    new SelectListItem {Text = "First Name", Value = "1"},
                    new SelectListItem {Text = "Last Name", Value = "2"},
                };
            ViewBag.searchType = searchFilter;
            ViewBag.brands = items;
        }

    }
}
