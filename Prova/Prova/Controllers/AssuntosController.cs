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
    public class AssuntosController : Controller
    {
        private ProvaDbContext db = new ProvaDbContext();
        
        // GET: Assunto/Create
        public ActionResult Create()
        {
            //Creating generic list
            List<SelectListItem> ObjList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Administrativo", Value = "1" },
                new SelectListItem { Text = "Condominal", Value = "2" }

            };
            ViewBag.TipoAssunto = ObjList;

            List<User> ListUsers = db.Users.Where(user => user.TipoUser == 1).ToList();
            ViewBag.Moradores = new SelectList(ListUsers, "IdUser", "Nome");
            return View();
        }

        // POST: Assunto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdMorador ,Conteudo, TipoAssunto")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                var controller = new ApiController();
                var result = controller.EnviarComunicado(assunto) as ViewResult;
                return RedirectToAction("Index", "Home");
            }

            return View(assunto);
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
