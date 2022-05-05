using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YellowPage.DBModel;

namespace YellowPage.Controllers
{
    public class ComController : Controller
    {
        // GET: Com
        // DataContext db = new DataContext();
        UserDBEntities db = new UserDBEntities();
        public ActionResult BusinessDetail()
        {
           
            var list = from x in db.Businesses select x;
            return View(list);
        }
        public ActionResult BusinessDetailUser()
        {

            var list = from x in db.Businesses select x;
            return View(list);
        }

        public ActionResult DeleteBusiness(int Id)
        {
            db.deleteBusiness(Id);

            return RedirectToAction("BusinessDetail");
        }
        public ActionResult UpdateBusiness(int Id)
        {
            db.updateBusiness(Id);

            return RedirectToAction("BusinessDetail");
        }

        // GET: Com/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Com/Create
        [HttpPost]
        public ActionResult Create(Business collection)
        {
            try
            {
                // TODO: Add insert logic here
                List<object> lst = new List<object>();
                lst.Add(collection.Company);
                lst.Add(collection.Category);
                lst.Add(collection.Address);
                lst.Add(collection.Phone);
                lst.Add(collection.Description);
                object[] allitems = lst.ToArray();
                int output = db.Database.ExecuteSqlCommand("insert into Bussinesses(Company, Category, Address, Phone, Description) values(@p0,@p1,@p2,@p3,@p4)", allitems);
                if (output > 0)
                {
                    ViewBag.msg = "Business is added";
                }
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Com/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Com/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                List<object> lst = new List<object>();

               




                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Com/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Com/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
