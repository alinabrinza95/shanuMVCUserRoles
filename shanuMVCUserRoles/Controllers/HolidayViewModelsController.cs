using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shanuMVCUserRoles.Models;

namespace shanuMVCUserRoles.Controllers
{
    public class HolidayViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HolidayViewModels
        public ActionResult Index()
        {
            return View(db.AspNetHolidays.ToList());
        }

        // GET: HolidayViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayViewModel holidayViewModel = db.AspNetHolidays.Find(id);
            if (holidayViewModel == null)
            {
                return HttpNotFound();
            }
            return View(holidayViewModel);
        }

        // GET: HolidayViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HolidayViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,TeamLeaderName,StartDate,EndDate,DaysOff,TLEmail,Flag")] HolidayViewModel holidayViewModel)
        {
            if (ModelState.IsValid)
            {
                db.AspNetHolidays.Add(holidayViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(holidayViewModel);
        }

        // GET: HolidayViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayViewModel holidayViewModel = db.AspNetHolidays.Find(id);
            if (holidayViewModel == null)
            {
                return HttpNotFound();
            }
            return View(holidayViewModel);
        }

        // POST: HolidayViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,TeamLeaderName,StartDate,EndDate,DaysOff,TLEmail,Flag")] HolidayViewModel holidayViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holidayViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(holidayViewModel);
        }

        // GET: HolidayViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayViewModel holidayViewModel = db.AspNetHolidays.Find(id);
            if (holidayViewModel == null)
            {
                return HttpNotFound();
            }
            return View(holidayViewModel);
        }

        // POST: HolidayViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HolidayViewModel holidayViewModel = db.AspNetHolidays.Find(id);
            db.AspNetHolidays.Remove(holidayViewModel);
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
