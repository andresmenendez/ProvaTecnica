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
    public class CondominiosController : Controller
    {
        private ProvaDbContext db = new ProvaDbContext();

        // GET: Condominios
        public ActionResult Index()
        {
            List<Condominio> ListCond = db.Condominios.ToList();
            if (ListCond.Count > 0)
            {
                foreach (Condominio item in ListCond)
                {
                    item.SetAdministradora(db.Adms.Where(adm => adm.IdAdm == item.IdAdm).FirstOrDefault());
                    item.SetResponsavel(db.Users.Where(user => user.IdUser == item.IdResponsavel).FirstOrDefault());
                }
            }
            return View(ListCond);
        }

        // GET: Condominios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = db.Condominios.Find(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // GET: Condominios/Create
        public ActionResult Create()
        {
            ViewBag.Adms = new SelectList(db.Adms.ToList<Adm>(), "IdAdm", "NomeAdm");
            List<User> ListUsers = db.Users.Where(user => user.TipoUser == 4 | user.TipoUser == 2).ToList<User>();
            ListUsers.Insert(0, new User() { IdUser = 0, Nome = "Sem Responsável" });
            return View();
        }

        // POST: Condominios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdCondominio,NomeCondominio,IdAdm, IdResponsavel")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                db.Condominios.Add(condominio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condominio);
        }

        // GET: Condominios/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Adms = new SelectList(db.Adms.ToList<Adm>(), "IdAdm", "NomeAdm");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = db.Condominios.Find(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // POST: Condominios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdCondominio,NomeCondominio,IdAdm, IdResponsavel")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condominio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condominio);
        }

        // GET: Condominios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = db.Condominios.Find(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // POST: Condominios/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Condominio condominio = db.Condominios.Find(id);
            db.Condominios.Remove(condominio);
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
