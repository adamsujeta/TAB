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

        public ActionResult Search(string search)
        {

            return View(db.Druzyna.Where(e => e.nazwa.ToLower().Contains(search.ToLower())).ToList());
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
           
            List<SelectListItem> ligaitems = new List<SelectListItem>();
            List<SelectListItem> treneritems = new List<SelectListItem>();
            List<SelectListItem> stadionitems = new List<SelectListItem>();
            List<SelectListItem> Krajitems = new List<SelectListItem>();

            var liga = db.Liga.ToList();
            foreach (var ll in liga)
            {
                ligaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }

            var trener = db.Trener.ToList();
            foreach (var ll in trener)
            {
                treneritems.Add(new SelectListItem
                {
                    Text = ll.imie + ll.nazwisko,
                    Value = ll.id.ToString()
                });
            }

            var stadion = db.Stadion.ToList();
            foreach (var ll in stadion)
            {
                stadionitems.Add(new SelectListItem
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



            ViewBag.liga = ligaitems;
            ViewBag.trener = treneritems;
            ViewBag.stadion = stadionitems;
            ViewBag.kraj = Krajitems;

            return View();
        }

        // POST: Druzyna/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa")] Druzyna druzyna)
        {
            int ligaid = Int32.Parse(Request.Form["LigaSelected"].ToString());
            int stadionid = Int32.Parse(Request.Form["StadionSelected"].ToString());
            int krajid = Int32.Parse(Request.Form["KrajSelected"].ToString());
            int trenerid = Int32.Parse(Request.Form["TrenerSelected"].ToString());

            druzyna.liga = db.Liga.Where(l =>l.id== ligaid).FirstOrDefault();
            druzyna.stadion = db.Stadion.Where(l => l.id == stadionid).FirstOrDefault();
            druzyna.kraj = db.Kraj.Where(l => l.id == krajid).FirstOrDefault();
            druzyna.trener = db.Trener.Where(l => l.id == trenerid).FirstOrDefault();
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
            List<SelectListItem> ligaitems = new List<SelectListItem>();
            List<SelectListItem> treneritems = new List<SelectListItem>();
            List<SelectListItem> stadionitems = new List<SelectListItem>();
            List<SelectListItem> Krajitems = new List<SelectListItem>();

            var liga = db.Liga.ToList();
            foreach (var ll in liga)
            {
                ligaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }

            var trener = db.Trener.ToList();
            foreach (var ll in trener)
            {
                treneritems.Add(new SelectListItem
                {
                    Text = ll.imie + ll.nazwisko,
                    Value = ll.id.ToString()
                });
            }

            var stadion = db.Stadion.ToList();
            foreach (var ll in stadion)
            {
                stadionitems.Add(new SelectListItem
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



            ViewBag.liga = ligaitems;
            ViewBag.trener = treneritems;
            ViewBag.stadion = stadionitems;
            ViewBag.kraj = Krajitems;

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
            int ligaid = Int32.Parse(Request.Form["LigaSelected"].ToString());
            int stadionid = Int32.Parse(Request.Form["StadionSelected"].ToString());
            int krajid = Int32.Parse(Request.Form["KrajSelected"].ToString());
            int trenerid = Int32.Parse(Request.Form["TrenerSelected"].ToString());

            Druzyna nd = db.Druzyna.Find(druzyna.id);
            nd.nazwa = druzyna.nazwa;
            nd.liga = db.Liga.Where(l => l.id == ligaid).FirstOrDefault();
            nd.stadion = db.Stadion.Where(l => l.id == stadionid).FirstOrDefault();
            nd.kraj = db.Kraj.Where(l => l.id == krajid).FirstOrDefault();
            nd.trener = db.Trener.Where(l => l.id == trenerid).FirstOrDefault();

            if (ModelState.IsValid)
            {
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
