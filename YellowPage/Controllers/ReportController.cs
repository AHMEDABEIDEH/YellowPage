using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowPage.DBModel;
using YellowPage.Models;

namespace YellowPage.Controllers
{
    public class ReportController : Controller
    {
        UserDBEntities objRep = new UserDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReportDetail()
        {

            var list = from x in objRep.Reports select x;
            return View(list);
        }

        public ActionResult DeleteReport(int Id)
        {
            objRep.deleteReport(Id);

            return RedirectToAction("ReportDetail");
        }
        public ActionResult UpdateReport(int Id)
        {
            objRep.updateReport(Id);

            return RedirectToAction("ReportDetail");
        }
        public ActionResult ProvideReport()
        {
            ReportClass objRepModel = new ReportClass();

            return View(objRepModel);
        }
        [HttpPost]
        public ActionResult ProvideReport(ReportClass objRepModel)
        {
            if (ModelState.IsValid)
            {
                YellowPage.DBModel.Report obRep = new YellowPage.DBModel.Report();
                obRep.FirstName = objRepModel.FirstName;
                obRep.LastName = objRepModel.LastName;
                obRep.Email = objRepModel.Email;
                obRep.Report1 = objRepModel.Report;


                objRep.Reports.Add(obRep);
                objRep.SaveChanges();
                objRepModel = new ReportClass();
                return View("ProvideReport");
            }
            return View();
        }
    }
}