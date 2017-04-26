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
        public ActionResult Zawodnik_Kary(int id)
        {
            return View(db.Kary.Where(k=>k.zawodnik.id==id).ToList());
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
            List<SelectListItem> zawodnikitems = new List<SelectListItem>();

            var d = db.Zawodnik.ToList();
            foreach (var ll in d)
            {
                zawodnikitems.Add(new SelectListItem
                {
                    Text = ll.imie+" "+ll.nazwisko,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.Zawodnik= zawodnikitems;
            return View();
        }

        // POST: Karie/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rodzaj,opis,data")] Kary kary)
        {
            int zawodnikid = Int32.Parse(Request.Form["ZawodnikSelected"].ToString());
            kary.zawodnik = db.Zawodnik.Where(d => d.id == zawodnikid).FirstOrDefault();
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
            List<SelectListItem> zawodnikitems = new List<SelectListItem>();

            var d = db.Zawodnik.ToList();
            foreach (var ll in d)
            {
                zawodnikitems.Add(new SelectListItem
                {
                    Text = ll.imie + " " + ll.nazwisko,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.Zawodnik = zawodnikitems;
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
            int zawodnikid = Int32.Parse(Request.Form["ZawodnikSelected"].ToString());
            kary.zawodnik = db.Zawodnik.Where(d => d.id == zawodnikid).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Kary.Remove(db.Kary.Where(k=>k.id==kary.id).FirstOrDefault());
                db.Kary.Add(kary);
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
