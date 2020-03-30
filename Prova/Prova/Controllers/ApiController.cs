using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Prova.Models;

namespace Prova.Controllers
{
    public class ApiController : System.Web.Http.ApiController
    {
        private ProvaDbContext db = new ProvaDbContext();

        [ResponseType(typeof(Assunto))]
        public IHttpActionResult EnviarComunicado([Bind(Include = "IdMorador ,Conteudo, TipoAssunto")] Assunto assunto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User morador = db.Users.Find(assunto.IdMorador);
            Condominio cond = db.Condominios.Find(morador.IdCondominio);
            Adm adm = db.Adms.Find(cond.IdAdm);

            if (assunto.TipoAssunto == 1)
            {
                RegistraComunicado.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                RegistraComunicado.Log("O morador " + morador.Nome + " envivou um comunicado para a Administradora " + adm.NomeAdm);
            }
            else
            {
                if (cond.IdResponsavel > 0)
                {
                    User Sindico = db.Users.Find(cond.IdResponsavel);
                    RegistraComunicado.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                    RegistraComunicado.Log("O morador " + morador.Nome + " envivou um comunicado para o Síndico  " + Sindico.Nome);
                }
                else
                {
                    User zelador = db.Users.Where(user => user.IdCondominio == cond.IdCondominio & user.TipoUser == 4).FirstOrDefault();
                    if (zelador != null)
                    {
                        RegistraComunicado.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                        RegistraComunicado.Log("O morador " + morador.Nome + " envivou um comunicado para o Zelador  " + zelador.Nome);
                    }
                    else
                    {
                        RegistraComunicado.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                        RegistraComunicado.Log("O morador " + morador.Nome + " envivou um comunicado para a Administradora " + adm.NomeAdm);
                    }
                }
            }

            return Ok(assunto);
        }

        // GET: api/ApiCond
        public IQueryable<Condominio> GetCondominios()
        {
            return db.Condominios;
        }

        // GET: api/ApiCond/5
        [ResponseType(typeof(Condominio))]
        public IHttpActionResult GetCondominio(int id)
        {
            Condominio condominio = db.Condominios.Find(id);
            if (condominio == null)
            {
                return NotFound();
            }

            return Ok(condominio);
        }

        // PUT: api/ApiCond/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCondominio(int id, Condominio condominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condominio.IdCondominio)
            {
                return BadRequest();
            }

            db.Entry(condominio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondominioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiCond
        [ResponseType(typeof(Condominio))]
        public IHttpActionResult PostCondominio(Condominio condominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Condominios.Add(condominio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = condominio.IdCondominio }, condominio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondominioExists(int id)
        {
            return db.Condominios.Count(e => e.IdCondominio == id) > 0;
        }

        // GET: api/Api
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Api/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Api/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.IdUser)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Api
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.IdUser }, user);
        }
        

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.IdUser == id) > 0;
        }
    }
}