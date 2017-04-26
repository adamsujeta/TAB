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
    public class ZawodnikController : Controller
    {
        private TABprojektContext db = new TABprojektContext();
        // GET: Zawodnik
        public ActionResult Index()
        {
            return View(db.Zawodnik.ToList());
        }
        public ActionResult Druzyna_zawodnicy(int id)
        {
            return View(db.Zawodnik.Where(z=>z.druzyna.id==id).ToList());
        }
        // GET: Zawodnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }
       
        // GET: Zawodnik/Create
        public ActionResult Create()
        {
            List<SelectListItem> Druzynaitems = new List<SelectListItem>();
            List<SelectListItem> Krajitems = new List<SelectListItem>();

            var d = db.Druzyna.ToList();
            foreach (var ll in d)
            {
                Druzynaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }

            var kraj = db.Kraj.ToList();
            foreach (var ll in kraj)
            {
                Krajitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.Druzyna = Druzynaitems;
            ViewBag.kraj = Krajitems;
            return View();
        }

        // POST: Zawodnik/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imie,nazwisko,wzrost,waga,pozycja,numer,data_urodzenia")] Zawodnik zawodnik)
        {
            int druzynaid = Int32.Parse(Request.Form["DruzynaSelected"].ToString());
            int krajid = Int32.Parse(Request.Form["KrajSelected"].ToString());
            zawodnik.druzyna = db.Druzyna.Where(d => d.id == druzynaid).FirstOrDefault();
            zawodnik.kraj = db.Kraj.Where(d => d.id == krajid).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Zawodnik.Add(zawodnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zawodnik);
        }

        // GET: Zawodnik/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> Druzynaitems = new List<SelectListItem>();
            List<SelectListItem> Krajitems = new List<SelectListItem>();

            var d = db.Druzyna.ToList();
            foreach (var ll in d)
            {
                Druzynaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }

            var kraj = db.Kraj.ToList();
            foreach (var ll in kraj)
            {
                Krajitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.Druzyna = Druzynaitems;
            ViewBag.kraj = Krajitems;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }

        // POST: Zawodnik/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imie,nazwisko,wzrost,waga,pozycja,numer,data_urodzenia")] Zawodnik zawodnik)
        {
            int druzynaid = Int32.Parse(Request.Form["DruzynaSelected"].ToString());
            zawodnik.druzyna = db.Druzyna.Where(d => d.id == druzynaid).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Zawodnik.Remove(db.Zawodnik.Where(z=>z.id==zawodnik.id).FirstOrDefault());
                db.Zawodnik.Add(zawodnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zawodnik);
        }

        // GET: Zawodnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }

        // POST: Zawodnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            db.Zawodnik.Remove(zawodnik);
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
