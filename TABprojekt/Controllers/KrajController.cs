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
    public class KrajController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Kraj
        public ActionResult Index()
        {
            return View(db.Kraj.ToList());
        }

        // GET: Kraj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kraj kraj = db.Kraj.Find(id);
            if (kraj == null)
            {
                return HttpNotFound();
            }
            return View(kraj);
        }

        // GET: Kraj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kraj/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa")] Kraj kraj)
        {
            if (ModelState.IsValid)
            {
                db.Kraj.Add(kraj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kraj);
        }

        // GET: Kraj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kraj kraj = db.Kraj.Find(id);
            if (kraj == null)
            {
                return HttpNotFound();
            }
            return View(kraj);
        }

        // POST: Kraj/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwa")] Kraj kraj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kraj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kraj);
        }

        // GET: Kraj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kraj kraj = db.Kraj.Find(id);
            if (kraj == null)
            {
                return HttpNotFound();
            }
            return View(kraj);
        }

        // POST: Kraj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kraj kraj = db.Kraj.Find(id);
            db.Kraj.Remove(kraj);
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
