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
    public class TrenerController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Trener
        public ActionResult Index()
        {
            return View(db.Trener.ToList());
        }

        // GET: Trener/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = db.Trener.Find(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }

        // GET: Trener/Create
        public ActionResult Create()
        {
            List<SelectListItem> Krajitems = new List<SelectListItem>();

            var kraj = db.Kraj.ToList();
            foreach (var ll in kraj)
            {
                Krajitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.kraj = Krajitems;
            return View();
        }

        // POST: Trener/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imie,nazwisko,data_urodzenia")] Trener trener)
        {
            int krajid = Int32.Parse(Request.Form["KrajSelected"].ToString());

            trener.kraj = db.Kraj.Where(d => d.id == krajid).FirstOrDefault();


            if (ModelState.IsValid)
            {
                db.Trener.Add(trener);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trener);
        }

        // GET: Trener/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> Krajitems = new List<SelectListItem>();

            var kraj = db.Kraj.ToList();
            foreach (var ll in kraj)
            {
                Krajitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.kraj = Krajitems;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = db.Trener.Find(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }

        // POST: Trener/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imie,nazwisko,data_urodzenia")] Trener trener)
        {
            int krajid = Int32.Parse(Request.Form["KrajSelected"].ToString());
            Trener nl = db.Trener.Find(trener.id);
            nl.imie = trener.imie;
            nl.nazwisko = trener.nazwisko;
            nl.data_urodzenia = trener.data_urodzenia;
            nl.kraj = db.Kraj.Where(d => d.id == krajid).FirstOrDefault();

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trener);
        }

        // GET: Trener/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = db.Trener.Find(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }

        // POST: Trener/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trener trener = db.Trener.Find(id);
            db.Trener.Remove(trener);
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
