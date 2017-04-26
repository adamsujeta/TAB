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
    public class MeczeController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Mecze
        public ActionResult Index()
        {
            return View(db.Mecze.ToList());
        }

        // GET: Mecze/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mecze mecze = db.Mecze.Find(id);
            if (mecze == null)
            {
                return HttpNotFound();
            }
            return View(mecze);
        }

        // GET: Mecze/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mecze/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,data,wynikPolowa,wynikKoniec")] Mecze mecze)
        {
            if (ModelState.IsValid)
            {
                db.Mecze.Add(mecze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mecze);
        }

        // GET: Mecze/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mecze mecze = db.Mecze.Find(id);
            if (mecze == null)
            {
                return HttpNotFound();
            }
            return View(mecze);
        }

        // POST: Mecze/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,data,wynikPolowa,wynikKoniec")] Mecze mecze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mecze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mecze);
        }

        // GET: Mecze/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mecze mecze = db.Mecze.Find(id);
            if (mecze == null)
            {
                return HttpNotFound();
            }
            return View(mecze);
        }

        // POST: Mecze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mecze mecze = db.Mecze.Find(id);
            db.Mecze.Remove(mecze);
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
