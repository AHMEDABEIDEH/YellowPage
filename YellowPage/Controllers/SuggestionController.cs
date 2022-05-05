using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowPage.DBModel;
using YellowPage.Models;

namespace YellowPage.Controllers
{
    public class SuggestionController : Controller
    {
        UserDBEntities objSug = new UserDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SuggestionDetail()
        {

            var list = from x in objSug.Suggestions select x;
            return View(list);
        }

        public ActionResult DeleteSuggestion(int Id)
        {
            objSug.deleteSuggestion(Id);

            return RedirectToAction("SuggestionDetail");
        }
        public ActionResult UpdateSuggestion(int Id)
        {
            objSug.updateSuggestion(Id);

            return RedirectToAction("SuggestionDetail");
        }




        public ActionResult ProvideSuggestion()
        {
            SuggestionClass objSugModel = new SuggestionClass();

            return View(objSugModel);
        }
        [HttpPost]
        public ActionResult ProvideSuggestion(SuggestionClass objSugModel)
        {
            if (ModelState.IsValid)
            {
               YellowPage.DBModel.Suggestion objsug = new YellowPage.DBModel.Suggestion();
                objsug.FirstName = objSugModel.FirstName;
                objsug.LastName = objSugModel.LastName;
                objsug.Email = objSugModel.Email;
                objsug.Suggestion1 = objSugModel.Suggestion;


                objSug.Suggestions.Add(objsug);
                objSug.SaveChanges();
                objSugModel = new SuggestionClass();
                return View("ProvideSuggestion");
            }
            return View();
        }
    }
}