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
    public class StatystykiController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Statystyki
        public ActionResult Index()
        {
            return View(db.Statystyki.ToList());
        }

        // GET: Statystyki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statystyki statystyki = db.Statystyki.Find(id);
            if (statystyki == null)
            {
                return HttpNotFound();
            }
            return View(statystyki);
        }

        // GET: Statystyki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statystyki/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bramki,kartkiCzerwone,kartkiZolte")] Statystyki statystyki)
        {
            if (ModelState.IsValid)
            {
                db.Statystyki.Add(statystyki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statystyki);
        }

        // GET: Statystyki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statystyki statystyki = db.Statystyki.Find(id);
            if (statystyki == null)
            {
                return HttpNotFound();
            }
            return View(statystyki);
        }

        // POST: Statystyki/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bramki,kartkiCzerwone,kartkiZolte")] Statystyki statystyki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statystyki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statystyki);
        }

        // GET: Statystyki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statystyki statystyki = db.Statystyki.Find(id);
            if (statystyki == null)
            {
                return HttpNotFound();
            }
            return View(statystyki);
        }

        // POST: Statystyki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statystyki statystyki = db.Statystyki.Find(id);
            db.Statystyki.Remove(statystyki);
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
