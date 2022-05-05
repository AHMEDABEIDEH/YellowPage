using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowPage.DBModel;
using YellowPage.Models;

namespace YellowPage.Controllers
{
    public class ReviewController : Controller
    {
        UserDBEntities objRev = new UserDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReviewDetail()
        {

            var list = from x in objRev.Reviews select x;
            return View(list);
        }

        public ActionResult DeleteReview(int Id)
        {
            objRev.deleteReview(Id);

            return RedirectToAction("ReviewDetail");
        }
        public ActionResult UpdateReview(int Id)
        {
            objRev.updateReview(Id);

            return RedirectToAction("ReviewDetail");
        }

        public ActionResult ProvideReview()
        {
            ReviewClass objRevModel = new ReviewClass();

            return View(objRevModel);
        }
        [HttpPost]
        public ActionResult ProvideReview(ReviewClass objRevModel)
        {
            if (ModelState.IsValid)
            {
                YellowPage.DBModel.Review obRev = new YellowPage.DBModel.Review();
                obRev.FirstName = objRevModel.FirstName;
                obRev.LastName = objRevModel.LastName;
                obRev.Email = objRevModel.Email;
                obRev.Review1 = objRevModel.Review;


                objRev.Reviews.Add(obRev);
                objRev.SaveChanges();
                objRevModel = new ReviewClass();
                return View("ProvideReview");
            }
            return View();
        }
    }
}