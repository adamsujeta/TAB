using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TABprojekt.Models;

namespace TABprojekt.Controllers
{
    public class KaryController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Karie
        public ActionResult Index()
        {
            return View(db.Kary.ToList());
        }

        // GET: Karie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kary kary = db.Kary.Find(id);
            if (kary == null)
            {
                return HttpNotFound();
            }
            return View(kary);
        }

        // GET: Karie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Karie/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rodzaj,opis,data")] Kary kary)
        {
            if (ModelState.IsValid)
            {
                db.Kary.Add(kary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kary);
        }

        // GET: Karie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kary kary = db.Kary.Find(id);
            if (kary == null)
            {
                return HttpNotFound();
            }
            return View(kary);
        }

        // POST: Karie/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rodzaj,opis,data")] Kary kary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kary);
        }

        // GET: Karie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kary kary = db.Kary.Find(id);
            if (kary == null)
            {
                return HttpNotFound();
            }
            return View(kary);
        }

        // POST: Karie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kary kary = db.Kary.Find(id);
            db.Kary.Remove(kary);
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
