using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowPage.DBModel;
using YellowPages.Models;

namespace YellowPages.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities ObjUserDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult DeleteAccount(int Id)
        {
            ObjUserDBEntities.deleteAccount(Id);

            return RedirectToAction("AccountDetail");
        }
        public ActionResult UpdateAccount(int Id)
        {
            ObjUserDBEntities.updateAccount(Id);

            return RedirectToAction("AccountDetail");
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AccountDetail()
        {

            var list = from x in ObjUserDBEntities.Users select x;
            return View(list);
        }
       
        public ActionResult ViewMarkets()
        {

            var list = from x in ObjUserDBEntities.Markets select x;
            return View(list);
        }
        public ActionResult ViewVehicles()
        {

            var list = from x in ObjUserDBEntities.Vehicles select x;
            return View(list);
        }
        public ActionResult ViewRestaurants()
        {

            var list = from x in ObjUserDBEntities.Restaurants select x;
            return View(list);
        }
        public ActionResult ViewClothes()
        {

            var list = from x in ObjUserDBEntities.Clothes select x;
            return View(list);
        }
        public ActionResult ViewTech()
        {

            var list = from x in ObjUserDBEntities.Technologies select x;
            return View(list);
        }
        public ActionResult User()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserModel ObjUserModel = new UserModel();
            return View(ObjUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel ObjUserModel)
        {
            if (ModelState.IsValid)
            {
                if (!ObjUserDBEntities.Users.Any(m => m.Email == ObjUserModel.Email))
                {
                    YellowPage.DBModel.User ObjUser = new YellowPage.DBModel.User();
                    ObjUser.CreatedOn = DateTime.Now;
                    ObjUser.Email = ObjUserModel.Email;
                    ObjUser.FirstName = ObjUserModel.FirstName;
                    ObjUser.LastName = ObjUserModel.LastName;
                    ObjUser.Password = ObjUserModel.Password;

                    ObjUserDBEntities.Users.Add(ObjUser);
                    ObjUserDBEntities.SaveChanges();
                    ObjUserModel = new UserModel();
                    ObjUserModel.SuccessMessage = "User is Sucessfully Registered";
                    return RedirectToAction("Register", "Account");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email Already Exists, Try a Different Email!");
                    return View();
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            LoginModel ObjLoginModel = new LoginModel();
            return View(ObjLoginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel ObjLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (ObjUserDBEntities.Users.Where(m => m.Email == ObjLoginModel.Email && m.Password == ObjLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invaild Email or Password.");
                    return View();
                }
                else
                {
                    Session["Email"] = ObjLoginModel.Email;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}