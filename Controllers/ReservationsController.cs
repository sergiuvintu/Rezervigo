using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rezervigo.Models;
using System.Diagnostics;

namespace Rezervigo.Controllers
{
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        [Authorize]
        public async Task<ActionResult> Index()
        {
            return View(await db.Reservations.ToListAsync());
        }
        [Authorize]
        // GET: Reservations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }
        [Authorize]
        // GET: Reservations/Create
        public ActionResult Create()
        {
            PopulateUsersDropDownList();
            PopulateRoomsDropDownList();
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Checkin,Checkout,User_Id,Room_Id")] Reservation reservation)
        {
            string checking_in = Request["Checkin"];   
            string checking_out = Request["Checkout"];
            int room_id = Convert.ToInt32(Request["Room_Id"]);
            DateTime date_checkin = DateTime.Parse(checking_in, null, System.Globalization.DateTimeStyles.RoundtripKind);
            DateTime date_checkout = DateTime.Parse(checking_out, null, System.Globalization.DateTimeStyles.RoundtripKind);

            var occupied = db.Reservations.Where(b => ((b.checkin > date_checkin) && (b.checkin > date_checkout))|| ((b.Checkout < date_checkout) && (b.Checkout < date_checkin)) || ((b.checkin == date_checkin) && (b.Checkout == date_checkout)) && (b.Room_Id == room_id)).FirstOrDefault();
            if (occupied != null)
            {
                ModelState.AddModelError("", "The room is already booked for the period selected.Please select another time window and try again.");
            }
            else
            {
                if (date_checkin < DateTime.Today)
                {
                    ModelState.AddModelError("", "You can not checkin in the past.Please select another time window and try again.");
                }
                else if (date_checkout < DateTime.Today)
                {
                    ModelState.AddModelError("", "You can not checkout in the past.Please select another time window and try again.");
                }
                else if (date_checkout < date_checkin)
                {
                    ModelState.AddModelError("", "You can not checkout before checking in.Please select another time window and try again.");
                }
                else if (ModelState.IsValid)
                {
                    db.Reservations.Add(reservation);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }   
            PopulateUsersDropDownList();
            PopulateRoomsDropDownList();
            return View(reservation);
        }
        [Authorize]
        // GET: Reservations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            PopulateUsersDropDownList(reservation.User_Id);
            PopulateRoomsDropDownList(reservation.Room_Id);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Checkin,Checkout,User_Id,Room_Id")] Reservation reservation)
        {
            string checking_in = Request["Checkin"];
            string checking_out = Request["Checkout"];
            int room_id = Convert.ToInt32(Request["Room_Id"]);
            int user_id = Convert.ToInt32(Request["User_Id"]);
            DateTime date_checkin;
            DateTime date_checkout;
            if (DateTime.TryParseExact(checking_in, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date_checkin) && DateTime.TryParseExact(checking_out, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date_checkout))
            {
                var occupied = db.Reservations.Where(b => (b.checkin >= date_checkin) && (b.Checkout <= date_checkout) && (b.Room_Id == room_id)).FirstOrDefault();
                if (occupied != null)
                {
                    ModelState.AddModelError("", "The room is already booked for the period selected.Please select another time window and try again.");
                }
                else
                {
                    if (date_checkin < DateTime.Today)
                    {
                        ModelState.AddModelError("", "You can not checkin in the past.Please select another time window and try again.");
                    }
                    else if (date_checkout < DateTime.Today)
                    {
                        ModelState.AddModelError("", "You can not checkout in the past.Please select another time window and try again.");
                    }
                    else if (date_checkout < date_checkin)
                    {
                        ModelState.AddModelError("", "You can not checkout before checking in.Please select another time window and try again.");
                    }
                    else if (ModelState.IsValid)
                    {
                        db.Entry(reservation).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }
            }
            PopulateUsersDropDownList(reservation.User_Id);
            PopulateRoomsDropDownList(reservation.Room_Id);
            return View(reservation);
        }
        [Authorize]
        // GET: Reservations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }
        [Authorize]
        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            db.Reservations.Remove(reservation);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void PopulateUsersDropDownList(object selectedUser = null)
        {
            var UsersQuery = from d in db.Users
                                   orderby d.Name
                                   select d;
            ViewBag.User_Id = new SelectList(UsersQuery, "Id", "Name", selectedUser);
        } 
        private void PopulateRoomsDropDownList(object selectedRoom = null)
        {
            var RoomsQuery = from d in db.Rooms
                                   orderby d.Number
                                   select d;
            ViewBag.Room_Id = new SelectList(RoomsQuery, "Id", "Number", selectedRoom);
        }
    }
}
