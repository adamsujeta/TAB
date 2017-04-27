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
        public ActionResult Zawodnik_Kontuzje(int id)
        {
            return View(db.Kontuzje.Where(k=>k.zawodnik.id==id).ToList());
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
            return View();
        }

        // POST: Kontuzje/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rodzaj,data_od,data_do")] Kontuzje kontuzje)
        {
            int zawodnikid = Int32.Parse(Request.Form["ZawodnikSelected"].ToString());
            kontuzje.zawodnik = db.Zawodnik.Where(d => d.id == zawodnikid).FirstOrDefault();
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
            int zawodnikid = Int32.Parse(Request.Form["ZawodnikSelected"].ToString());
            

            Kontuzje nk = db.Kontuzje.Find(kontuzje.id);

            nk.rodzaj = kontuzje.rodzaj;
            nk.data_od = kontuzje.data_od;
            nk.data_do = kontuzje.data_do;
            nk.zawodnik = db.Zawodnik.Where(d => d.id == zawodnikid).FirstOrDefault();
            if (ModelState.IsValid)
            {
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
