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
        public ActionResult Zawodnik_Statystyki(int id)
        {
            return View(db.Statystyki.Where(s=>s.zawodnik.id==id).ToList());
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

            List<SelectListItem> meczitems = new List<SelectListItem>();

            var dd = db.Mecze.ToList();
            foreach (var ll in dd)
            {
                meczitems.Add(new SelectListItem
                {
                    Text = ll.data.ToString("yyyy-MM-dd"),
                    Value = ll.id.ToString()
                });
            }
            ViewBag.mecz = meczitems;
            return View();
        }

        // POST: Statystyki/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bramki,kartkiCzerwone,kartkiZolte")] Statystyki statystyki)
        {
            int zawodnikid = Int32.Parse(Request.Form["ZawodnikSelected"].ToString());
            int meczid = Int32.Parse(Request.Form["MeczSelected"].ToString());

            statystyki.zawodnik = db.Zawodnik.Where(d => d.id == meczid).FirstOrDefault();
            statystyki.mecz = db.Mecze.Where(d => d.id == meczid).FirstOrDefault();
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

            List<SelectListItem> meczitems = new List<SelectListItem>();

            var dd = db.Mecze.ToList();
            foreach (var ll in dd)
            {
                meczitems.Add(new SelectListItem
                {
                    Text = ll.data.ToString("yyyy-MM-dd"),
                    Value = ll.id.ToString()
                });
            }
            ViewBag.mecz = meczitems;
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
            int zawodnikid = Int32.Parse(Request.Form["ZawodnikSelected"].ToString());
            int meczid = Int32.Parse(Request.Form["MeczSelected"].ToString());

            Statystyki ns = db.Statystyki.Where(i => i.id == statystyki.id).FirstOrDefault();

            ns.bramki = statystyki.bramki;
            ns.kartkiCzerwone = statystyki.kartkiCzerwone;
            ns.kartkiZolte = statystyki.kartkiZolte;

            ns.zawodnik = db.Zawodnik.Where(d => d.id == meczid).FirstOrDefault();
            ns.mecz = db.Mecze.Where(d => d.id == meczid).FirstOrDefault();

            if (ModelState.IsValid)
            {
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
