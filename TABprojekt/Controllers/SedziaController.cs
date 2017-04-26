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
    public class SedziaController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Sedzia
        public ActionResult Index()
        {
            return View(db.Sedzia.ToList());
        }
        public ActionResult Mecze_Sedzia(int id)
        {
            return View(db.Sedzia.Where(s=>s.mecz.id==id).ToList());
        }
        // GET: Sedzia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sedzia sedzia = db.Sedzia.Find(id);
            if (sedzia == null)
            {
                return HttpNotFound();
            }
            return View(sedzia);
        }

        // GET: Sedzia/Create
        public ActionResult Create()
        {
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

        // POST: Sedzia/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imie,nazwisko,ranga")] Sedzia sedzia)
        {
            int meczid = Int32.Parse(Request.Form["MeczSelected"].ToString());

            sedzia.mecz = db.Mecze.Where(d => d.id == meczid).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Sedzia.Add(sedzia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sedzia);
        }

        // GET: Sedzia/Edit/5
        public ActionResult Edit(int? id)
        {
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
            Sedzia sedzia = db.Sedzia.Find(id);
            if (sedzia == null)
            {
                return HttpNotFound();
            }
            return View(sedzia);
        }

        // POST: Sedzia/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imie,nazwisko,ranga")] Sedzia sedzia)
        {
            int meczid = Int32.Parse(Request.Form["MeczSelected"].ToString());

            sedzia.mecz = db.Mecze.Where(d => d.id == meczid).FirstOrDefault();

            if (ModelState.IsValid)
            {
                db.Entry(sedzia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sedzia);
        }

        // GET: Sedzia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sedzia sedzia = db.Sedzia.Find(id);
            if (sedzia == null)
            {
                return HttpNotFound();
            }
            return View(sedzia);
        }

        // POST: Sedzia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sedzia sedzia = db.Sedzia.Find(id);
            db.Sedzia.Remove(sedzia);
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
