using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prova.Models;

namespace Prova.Controllers
{
    public class AdmsController : Controller
    {
        private ProvaDbContext db = new ProvaDbContext();

        // GET: Adms
        public ActionResult Index()
        {
            return View(db.Adms.ToList());
        }

        // GET: Adms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm adm = db.Adms.Find(id);
            if (adm == null)
            {
                return HttpNotFound();
            }
            return View(adm);
        }

        // GET: Adms/Create
        public ActionResult Create()
        {
            Adm adm = new Adm();
            adm.IdAdm = 1;
            return View(adm);
        }

        // POST: Adms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,NomeAdm")] Adm adm)
        {
            if (ModelState.IsValid)
            {
                db.Adms.Add(adm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adm);
        }

        // GET: Adms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm adm = db.Adms.Find(id);
            if (adm == null)
            {
                return HttpNotFound();
            }
            return View(adm);
        }

        // POST: Adms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeAdm")] Adm adm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adm);
        }

        // GET: Adms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm adm = db.Adms.Find(id);
            if (adm == null)
            {
                return HttpNotFound();
            }
            return View(adm);
        }

        // POST: Adms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adm adm = db.Adms.Find(id);
            db.Adms.Remove(adm);
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
