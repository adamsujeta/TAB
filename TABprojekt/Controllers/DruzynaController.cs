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
    public class DruzynaController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Druzyna
        public ActionResult Index()
        {
            return View(db.Druzyna.ToList());
        }


        // GET: Druzyna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Druzyna druzyna = db.Druzyna.Find(id);
            if (druzyna == null)
            {
                return HttpNotFound();
            }
            return View(druzyna);
        }

        // GET: Druzyna/Create
        public ActionResult Create()
        {
           
            ViewBag.liga = new SelectList(db.Liga.ToList(), "nazwa");
            return View();
        }

        // POST: Druzyna/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa")] Druzyna druzyna)
        {
            
            if (ModelState.IsValid)
            {
                db.Druzyna.Add(druzyna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(druzyna);
        }

        // GET: Druzyna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Druzyna druzyna = db.Druzyna.Find(id);
            if (druzyna == null)
            {
                return HttpNotFound();
            }
            return View(druzyna);
        }

        // POST: Druzyna/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwa")] Druzyna druzyna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(druzyna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(druzyna);
        }

        // GET: Druzyna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Druzyna druzyna = db.Druzyna.Find(id);
            if (druzyna == null)
            {
                return HttpNotFound();
            }
            return View(druzyna);
        }

        // POST: Druzyna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Druzyna druzyna = db.Druzyna.Find(id);
            db.Druzyna.Remove(druzyna);
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
