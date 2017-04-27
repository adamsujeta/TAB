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
    public class LigaController : Controller
    {
        private TABprojektContext db = new TABprojektContext();

        // GET: Liga
        public ActionResult Index()
        {
            return View(db.Liga.ToList());
        }


        // GET: Liga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liga liga = db.Liga.Find(id);
            if (liga == null)
            {
                return HttpNotFound();
            }
            return View(liga);
        }

        // GET: Liga/Create
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

        // POST: Liga/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa")] Liga liga)
        {
            int krajid = Int32.Parse(Request.Form["KrajSelected"].ToString());

            liga.kraj = db.Kraj.Where(d => d.id == krajid).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Liga.Add(liga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(liga);
        }

        // GET: Liga/Edit/5
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
            Liga liga = db.Liga.Find(id);
            if (liga == null)
            {
                return HttpNotFound();
            }
            return View(liga);
        }

        // POST: Liga/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwa")] Liga liga)
        {
            int krajid = Int32.Parse(Request.Form["KrajSelected"].ToString());

            Liga newLiga = db.Liga.Where(l => l.id == liga.id).FirstOrDefault();
            newLiga.kraj = db.Kraj.Where(d => d.id == krajid).FirstOrDefault();
            newLiga.nazwa = liga.nazwa;
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liga);
        }

        // GET: Liga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liga liga = db.Liga.Find(id);
            if (liga == null)
            {
                return HttpNotFound();
            }
            return View(liga);
        }

        // POST: Liga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Liga liga = db.Liga.Find(id);
            db.Liga.Remove(liga);
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
