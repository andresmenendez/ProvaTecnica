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
    public class UsersController : Controller
    {
        private ProvaDbContext db = new ProvaDbContext();

        // GET: Users
        public ActionResult Index()
        {
            List<User> ListUsers = db.Users.ToList();
            if (ListUsers.Count > 0)
            {
                foreach (User item in ListUsers)
                {
                    item.SetCondominio(db.Condominios.Where(cond => cond.IdCondominio == item.IdCondominio).FirstOrDefault());
                }
            }
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            //Creating generic list
            List<SelectListItem> ObjList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Morador", Value = "1" },
                new SelectListItem { Text = "Sindico", Value = "2" },
                new SelectListItem { Text = "Administradora", Value = "3" },
                new SelectListItem { Text = "Zelador", Value = "4" },

            };
            ViewBag.TipoUsuario = ObjList;
            ViewBag.Condominios = new SelectList(db.Condominios.ToList<Condominio>(), "IdCondominio", "NomeCondominio");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdUser,Nome,Email,IdCondominio,TipoUser")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                if (user.TipoUser == 2)
                {
                    Condominio cond = db.Condominios.Find(user.IdCondominio);
                    if (cond != null)
                    {
                        cond.IdCondominio = user.IdUser;
                        db.Entry(cond).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            //Creating generic list
            List<SelectListItem> ObjList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Morador", Value = "1" },
                new SelectListItem { Text = "Sindico", Value = "2" },
                new SelectListItem { Text = "Administradora", Value = "3" },
                new SelectListItem { Text = "Zelador", Value = "4" },

            };
            ViewBag.TipoUsuario = ObjList;
            ViewBag.Condominios = new SelectList(db.Condominios.ToList<Condominio>(), "IdCondominio", "NomeCondominio");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdUser,Nome,Email,IdCondominio,TipoUser")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                if (user.TipoUser == 2)
                {
                    Condominio cond = db.Condominios.Find(user.IdCondominio);
                    if (cond != null)
                    {
                        cond.IdResponsavel = user.IdUser;
                        db.Entry(cond).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
