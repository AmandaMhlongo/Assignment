using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMvc.Models;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class AddReservationsController : Controller
    {
        private FlicksHotelDbase db = new FlicksHotelDbase();

        // GET: AddReservations
        public ActionResult Index()
        {
            var reservation = db.Reservation.Include(r => r.Customer).Include(r => r.Room);
            return View(reservation.ToList());
        }

        public ActionResult reservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult reservation([Bind(Include = "NumOfNights,NumOfGuests,RoomType,CheckIn,CheckOut")]ReservationViewModel reservationViewModel)
        {
            if (ModelState.IsValid)
            {
                // do stuff here like validation and mapping so fort.
                var reservation = new Reservation
                {
                    BookingDate = DateTime.Now,
                checkInDate = DateTime.Parse( reservationViewModel.CheckIn),//,"",System.Globalization.DateTimeStyles.None),
                checkOutDate = DateTime.Parse(reservationViewModel.CheckOut),
                numberOFGuests = reservationViewModel.NumOfGuests,
                //Price = Double.Parse( reservationViewModel.Price)
                };
                db.Reservation.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationViewModel);
        }

        // GET: AddReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: AddReservations/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Fname");
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomName");
            return View();
        }

        // POST: AddReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,RoomID,CustomerID,BookingDate,checkInDate,checkOutDate,numberOFGuests,Price")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservation.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Fname", reservation.CustomerID);
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomName", reservation.RoomID);
            return View(reservation);
        }

        // GET: AddReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Fname", reservation.CustomerID);
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomName", reservation.RoomID);
            return View(reservation);
        }

        // POST: AddReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,RoomID,CustomerID,BookingDate,checkInDate,checkOutDate,numberOFGuests,Price")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "Fname", reservation.CustomerID);
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomName", reservation.RoomID);
            return View(reservation);
        }

        // GET: AddReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: AddReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservation.Find(id);
            db.Reservation.Remove(reservation);
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
