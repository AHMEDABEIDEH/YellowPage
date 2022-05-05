using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowPage.DBModel;
using YellowPage.Models;

namespace YellowPage.Controllers
{
    public class BusinessController : Controller
    {
        UserDBEntities objAdd = new UserDBEntities();
        public ActionResult Index()
        {
            return View();
        }
      

        public ActionResult AddBusiness()
        {
            BusinessClass bc = new BusinessClass();

            return View(bc);
        }
        [HttpPost]
        public ActionResult AddBusiness(BusinessClass bc)
        {
            if (ModelState.IsValid)
            {
                Business objBusiness = new DBModel.Business();
                objBusiness.Company = bc.Company;
                objBusiness.Category = bc.Category;
                objBusiness.Address = bc.Address;
                objBusiness.Phone = bc.Phone;
                objBusiness.Description = bc.Description;
                objBusiness.Website = bc.Website;
                objAdd.Businesses.Add(objBusiness);
                objAdd.SaveChanges();
                bc = new BusinessClass();
                return View("AddBusiness");
            }
            return View();
        }
    }
}