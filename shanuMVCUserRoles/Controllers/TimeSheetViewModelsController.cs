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
    public class TimeSheetViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeSheetViewModels
        public ActionResult Index()
        {
            return View(db.TimeSheetViewModel.ToList());
        }

        // GET: TimeSheetViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetViewModel timeSheetViewModel = db.TimeSheetViewModel.Find(id);
            if (timeSheetViewModel == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetViewModel);
        }

        // GET: TimeSheetViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSheetViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mark,FirstName,LastName,CNP,TeamLeaderEmail,Flag")] TimeSheetViewModel timeSheetViewModel)
        {
            if (ModelState.IsValid)
            {
                db.TimeSheetViewModel.Add(timeSheetViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeSheetViewModel);
        }

        // GET: TimeSheetViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetViewModel timeSheetViewModel = db.TimeSheetViewModel.Find(id);
            if (timeSheetViewModel == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetViewModel);
        }

        // POST: TimeSheetViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mark,FirstName,LastName,CNP,TeamLeaderEmail,Flag")] TimeSheetViewModel timeSheetViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSheetViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeSheetViewModel);
        }

        // GET: TimeSheetViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetViewModel timeSheetViewModel = db.TimeSheetViewModel.Find(id);
            if (timeSheetViewModel == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetViewModel);
        }

        // POST: TimeSheetViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSheetViewModel timeSheetViewModel = db.TimeSheetViewModel.Find(id);
            db.TimeSheetViewModel.Remove(timeSheetViewModel);
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
