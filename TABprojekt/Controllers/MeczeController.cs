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
        public ActionResult Druzyna_mecze(int id)
        {
            var result = db.Mecze.Where(m => m.druzyna1.id == id).ToList();

            if (result.Count==0) {
                result = db.Mecze.Where(m => m.druzyna2.id == id).ToList();
            }

            return View(result);
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
            List<SelectListItem> stadionitems = new List<SelectListItem>();
            List<SelectListItem> druzynaitems = new List<SelectListItem>();

            var stadion = db.Stadion.ToList();
            foreach (var ll in stadion)
            {
                stadionitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            var druzyna = db.Druzyna.ToList();
            foreach (var ll in druzyna)
            {
                druzynaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.stadion = stadionitems;
            ViewBag.druzyna = druzynaitems;
            return View();
        }

        // POST: Mecze/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,data,wynikPolowa,wynikKoniec")] Mecze mecze)
        {
            int stadionid = Int32.Parse(Request.Form["StadionSelected"].ToString());
            int druzyna1id = Int32.Parse(Request.Form["druzyna1Selected"].ToString());
            int druzyna2id = Int32.Parse(Request.Form["druzyna2Selected"].ToString());

            mecze.stadion = db.Stadion.Where(l => l.id == stadionid).FirstOrDefault();
            mecze.druzyna1 = db.Druzyna.Where(l => l.id == druzyna1id).FirstOrDefault();
            mecze.druzyna2 = db.Druzyna.Where(l => l.id == druzyna2id).FirstOrDefault();
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
            List<SelectListItem> stadionitems = new List<SelectListItem>();
            List<SelectListItem> druzynaitems = new List<SelectListItem>();

            var stadion = db.Stadion.ToList();
            foreach (var ll in stadion)
            {
                stadionitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            var druzyna = db.Druzyna.ToList();
            foreach (var ll in druzyna)
            {
                druzynaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.stadion = stadionitems;
            ViewBag.druzyna = druzynaitems;
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
            int stadionid = Int32.Parse(Request.Form["StadionSelected"].ToString());
            int druzyna1id = Int32.Parse(Request.Form["druzyna1Selected"].ToString());
            int druzyna2id = Int32.Parse(Request.Form["druzyna2Selected"].ToString());

            mecze.stadion = db.Stadion.Where(l => l.id == stadionid).FirstOrDefault();
            mecze.druzyna1 = db.Druzyna.Where(l => l.id == druzyna1id).FirstOrDefault();
            mecze.druzyna2 = db.Druzyna.Where(l => l.id == druzyna2id).FirstOrDefault();

            if (ModelState.IsValid)
            {
                db.Mecze.Remove(db.Mecze.Where(dd => dd.id == mecze.id).FirstOrDefault());
                db.Mecze.Add(mecze);
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
