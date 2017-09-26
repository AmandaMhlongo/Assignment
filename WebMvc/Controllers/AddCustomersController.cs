using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class AddCustomersController : Controller
    {
        private FlicksHotelDbase db = new FlicksHotelDbase();

        // GET: AddCustomers
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        public ActionResult HomePage()
        {
             return View();
        }


        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Customer Customer)
        {
            using (db)
            {
                //var Usr = db.Promoter.Single(u => u.Fname == Promoter.Fname && u.Password == Promoter.Password);
                var Usr = db.Customer.Where(u => u.Fname.Equals(Customer.Fname) && u.Password.Equals(Customer.Password)).FirstOrDefault();
                if (Usr != null)
                {
                    Session["UserID"] = Usr.CustomerID.ToString();
                    Session["UserName"] = Usr.Fname.ToString();
                    //  return RedirectToAction("PromoterProfile", "RegPromoter", new { @id = Usr.CustomerID });
                    return RedirectToAction("HomePage","AddCustomers");
                }
                else
                {
                    ModelState.AddModelError("", "User Name or Password is wrong");

                }

            }

            return View();
        }
        // GET: AddCustomers/Details/5
        public ActionResult LogOut()
        {
            if (Session["UserID"] != null)
            {

                Session["UserID"] = null;
                Session["UserName"] = null;
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                ModelState.Clear();

                return RedirectToAction("HomePage", "AddCustomers");
            }
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            ModelState.Clear();
            return RedirectToAction("HomePage", "AddCustomers");
         
        }
        [HttpPost]
        public ActionResult LogOut(Customer Customer)
        {
               if (Session["UserID"] != null )
               {
                
                Session["UserID"] = null;
                Session["UserName"] = null;
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                ModelState.Clear();

                return RedirectToAction("HomePage", "AddCustomers");
            }
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            ModelState.Clear();
            return RedirectToAction("HomePage", "AddCustomers");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: AddCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Fname,Lnane,Password,confirmPassword,Email,PhoneNumber,Gender,IDNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("HomePage", "AddCustomers");
            }

            return View(customer);
        }

        // GET: AddCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: AddCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Fname,Lnane,Password,confirmPassword,Email,PhoneNumber,Gender,IDNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: AddCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: AddCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
