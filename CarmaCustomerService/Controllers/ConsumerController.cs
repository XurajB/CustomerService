using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Linq;
using System.Diagnostics;
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

        [HttpGet]
        public ActionResult View(Guid? id)
        {
            ConsumerLogInInfo consumerLogInInfo =
                db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == id);

            LoadSpinners();

            return View(consumerLogInInfo);
        }

        public ActionResult Edit(Guid? id)
        {
            ConsumerLogInInfo consumerLogInInfo =
                db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == id);

            LoadSpinners();

            return View(consumerLogInInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsumerLogInInfo consumerLogInInfo)
        {
            if (ModelState.IsValid)
            {
                ConsumerLogInInfo consumer =
                db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == consumerLogInInfo.ConsumerTouchPointID);

                if (consumer == null)
                {
                    return HttpNotFound();
                }

                

                //db.Entry(consumerLogInInfo).State=EntityState.Modified;
                try
                {
                    consumer.ConsumerTouchPointProfile.NameLast = consumerLogInInfo.ConsumerTouchPointProfile.NameLast;
                    consumer.ConsumerTouchPointProfile.NameFirst = consumerLogInInfo.ConsumerTouchPointProfile.NameFirst;
                    consumer.UserID = consumerLogInInfo.UserID;
                    consumer.ConsumerTouchPointProfile.ConsumerDemographic.Street =
                        consumerLogInInfo.ConsumerTouchPointProfile.ConsumerDemographic.Street;
                    consumer.ConsumerTouchPointProfile.ConsumerDemographic.City =
                        consumerLogInInfo.ConsumerTouchPointProfile.ConsumerDemographic.City;
                    consumer.ConsumerTouchPointProfile.ConsumerDemographic.PostCode =
                        consumerLogInInfo.ConsumerTouchPointProfile.ConsumerDemographic.PostCode;
                    consumer.ConsumerTouchPointProfile.ConsumerDemographic.PhoneHome =
                        consumerLogInInfo.ConsumerTouchPointProfile.ConsumerDemographic.PhoneHome;

                    if (consumerLogInInfo.DisplayName == null)
                    {
                        ModelState.AddModelError(string.Empty, "Display Name cannot be empty");
                        throw new DbEntityValidationException();
                    }
                    consumer.DisplayName = consumerLogInInfo.DisplayName;
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError(string.Empty, validationError.ErrorMessage);
                        }
                    }

                    LoadSpinners();
                    return View("Edit", consumerLogInInfo);
                }
                catch (DuplicateKeyException exception)
                {
                    ModelState.AddModelError(string.Empty, exception.InnerException.Message);
                    LoadSpinners();
                    return View("Edit", consumerLogInInfo);
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message+"Error updating database. Please contact IT");
                    LoadSpinners();
                    return View("Edit", consumerLogInInfo);
                }
                LoadSpinners();
                ViewBag.successEditUser = true;
                return View("Edit", consumerLogInInfo);
                
            }
            LoadSpinners();
            return View("Edit", consumerLogInInfo);
            
            

            
            //return View(consumerLogInInfo);
        }


        public ActionResult EditProduct(Guid? id)
        {
            ConsumerProduct  consumerProduct =
                db.ConsumerProducts.FirstOrDefault(a => a.ConsumerProductID == id);

            LoadSpinners();

            return View(consumerProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ConsumerProduct consumerProduct)
        {
            if (ModelState.IsValid)
            {
                ConsumerProduct product =
                    db.ConsumerProducts.FirstOrDefault(a => a.ConsumerProductID == consumerProduct.ConsumerProductID);

                if (product == null)
                {
                    return HttpNotFound();
                }
                try
                {
                    product.ModelNumber = consumerProduct.ModelNumber;
                    product.SerialNumber = consumerProduct.SerialNumber;
                    product.DateCreated = consumerProduct.DateCreated;
               
                    //db.Entry(consumerProduct).State=EntityState.Modified;
                    db.SaveChanges();

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError(string.Empty, validationError.ErrorMessage);
                        }
                    }

                    LoadSpinners();
                    return View("EditProduct", consumerProduct);
                }
                catch (DuplicateKeyException exception)
                {
                    ModelState.AddModelError(string.Empty, exception.InnerException.Message);
                    LoadSpinners();
                    return View("EditProduct", consumerProduct);
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message + "Error updating database. Please contact IT");
                    LoadSpinners();
                    return View("EditProduct", consumerProduct);
                }
                LoadSpinners();
                ViewBag.successEditUser = true;
                return View("EditProduct", consumerProduct);

            }
            LoadSpinners();
            return View("EditProduct", consumerProduct);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Guid? id)
        {
            ConsumerProduct product =
                    db.ConsumerProducts.FirstOrDefault(a => a.ConsumerProductID == id);
            
            if (product == null)
                {
                    return HttpNotFound();
                }

            var purchaseReason =
                db.ConsumerPurchaseReasons.FirstOrDefault(a => a.ConsumerProductID == product.ConsumerProductID);

            try
            {
                db.ConsumerPurchaseReasons.Remove(purchaseReason);
                db.PurchaseDynamics.Remove(product.PurchaseDynamic);
                foreach (var satisfaction in product.ProductSatisfactions)
                {
                    db.ProductSatisfactions.Remove(satisfaction);
                }
                db.ProductSatisfactionOlds.Remove(product.ProductSatisfactionOld);
                db.ConsumerProducts.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //catch error here.
            }
            return RedirectToAction("View", new { id = product.ConsumerTouchPointID });
        }

        [HttpPost]
        public ActionResult DeleteConsumer(Guid? id)
        {
            ConsumerLogInInfo consumerLogInInfo =
                db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == id);

            //try
            //{
                //Remove all products associated records
                IQueryable<ConsumerProduct> consumerProducts =
                    db.ConsumerProducts.Where(a => a.ConsumerTouchPointID == id);
                foreach (var product in consumerProducts)
                {
                    var purchaseReason =
                        db.ConsumerPurchaseReasons.FirstOrDefault(a => a.ConsumerProductID == product.ConsumerProductID);
                    db.ConsumerPurchaseReasons.Remove(purchaseReason);
                    db.PurchaseDynamics.Remove(product.PurchaseDynamic);
                    foreach (var satisfaction in product.ProductSatisfactions)
                    {
                        db.ProductSatisfactions.Remove(satisfaction);
                    }
                    db.ProductSatisfactionOlds.Remove(product.ProductSatisfactionOld);
                    db.ConsumerProducts.Remove(product);
                }

                //Remove all consumer associated records
            foreach (var consumerDemography in db.ConsumerDemographics.Where(a=>a.ConsumerTouchPointID==id))
            {
                db.ConsumerDemographics.Remove(consumerDemography);
            }

                //Remove consumer
                db.ConsumerLogInInfoes.Remove(db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == id));
                
                //commit
                db.SaveChanges();
            //}
           // catch (Exception exception)
           // {
                //Exception
          //  }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ResetPassword(Guid? id)
        {
            var consumer = db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == id);
            var carmaService = new CarmaService();
            carmaService.SendPasswordRecoveryEmail(consumer.UserID, consumer.TouchPoint.BrandID);
            return RedirectToAction("View", new { id = consumer.ConsumerTouchPointID });
        }

        [HttpPost]
        public ActionResult RemoveSubscription(int id, Guid? consumer, string email)
        {
            var result= LisTrakService.UnsubscribeSubscription(new LisTrakRequestDto
                {
                    EmailAddress = email,
                    ListId = id
                });
            return RedirectToAction("View", new { id = consumer });
        }

        [HttpPost]
        public ActionResult UnsubscribeFromAll(Guid? id)
        {
            var consumer = db.ConsumerLogInInfoes.FirstOrDefault(a => a.ConsumerTouchPointID == id);
            var subscriptionLists = LisTrakService.GetSubscriberList(consumer.UserID, 0);

            foreach (var lisTrakSubscriberDto in subscriptionLists.Where(lisTrakSubscriberDto => lisTrakSubscriberDto != null))
            {
                LisTrakService.UnsubscribeSubscription(new LisTrakRequestDto
                    {
                        EmailAddress = consumer.UserID,
                        ListId = lisTrakSubscriberDto.ListId
                    });
            }
            
            return RedirectToAction("View", new { id = id });
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
