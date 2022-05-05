using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowPage.DBModel;
using YellowPage.Models;


namespace YellowPage.Controllers
{
    public class RequestController : Controller
    {
        UserDBEntities objReq = new UserDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewRequests()
        {

            var list = from x in objReq.Requests select x;
            return View(list);
        }
        public ActionResult DeleteRequest(int Id)
        {
            objReq.deleteRequest(Id);

            return RedirectToAction("ViewRequests");
        }
        public ActionResult UpdateRequest(int Id)
        {
            objReq.updateRequest(Id);

            return RedirectToAction("ViewRequests");
        }
        public ActionResult RequestBusiness()
        {
            RequestClass rq = new RequestClass();

            return View(rq);
        }
        [HttpPost]
        public ActionResult RequestBusiness(RequestClass rq)
        {
            if (ModelState.IsValid)
            {
                Request objRequest = new DBModel.Request();
                objRequest.Company = rq.Company;
                objRequest.Category = rq.Category;
                objRequest.Address = rq.Address;
                objRequest.Phone = rq.Phone;
                objRequest.Description = rq.Description;
                objRequest.Website = rq.Website;
                objReq.Requests.Add(objRequest);
                objReq.SaveChanges();
                rq = new RequestClass();
                return View("RequestBusiness");
            }
            return View();
        }
    }
}