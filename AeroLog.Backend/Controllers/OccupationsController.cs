using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AeroLog.Backend.Models;

namespace AeroLog.Backend.Controllers
{
    public class OccupationsController : Controller
    {
        private AeroLogContext db = new AeroLogContext();

        // GET: Occupations
        public ActionResult Index()
        {
            return View(db.Occupations.ToList());
        }

        // GET: Occupations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        // GET: Occupations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Occupations/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OccupationID,OccupationName")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Occupations.Add(occupation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occupation);
        }

        // GET: Occupations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        // POST: Occupations/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OccupationID,OccupationName")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occupation);
        }

        // GET: Occupations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        // POST: Occupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occupation occupation = db.Occupations.Find(id);
            db.Occupations.Remove(occupation);
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
