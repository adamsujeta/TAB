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
    public class KontuzjeController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Kontuzje
        public ActionResult Index()
        {
            return View(db.Kontuzje.ToList());
        }

        // GET: Kontuzje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontuzje kontuzje = db.Kontuzje.Find(id);
            if (kontuzje == null)
            {
                return HttpNotFound();
            }
            return View(kontuzje);
        }

        // GET: Kontuzje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kontuzje/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rodzaj,data_od,data_do")] Kontuzje kontuzje)
        {
            if (ModelState.IsValid)
            {
                db.Kontuzje.Add(kontuzje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kontuzje);
        }

        // GET: Kontuzje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontuzje kontuzje = db.Kontuzje.Find(id);
            if (kontuzje == null)
            {
                return HttpNotFound();
            }
            return View(kontuzje);
        }

        // POST: Kontuzje/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rodzaj,data_od,data_do")] Kontuzje kontuzje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontuzje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kontuzje);
        }

        // GET: Kontuzje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontuzje kontuzje = db.Kontuzje.Find(id);
            if (kontuzje == null)
            {
                return HttpNotFound();
            }
            return View(kontuzje);
        }

        // POST: Kontuzje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kontuzje kontuzje = db.Kontuzje.Find(id);
            db.Kontuzje.Remove(kontuzje);
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
