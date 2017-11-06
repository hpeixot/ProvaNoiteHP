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
using Prova1.Models;
using Web.Models.Contexto;

namespace Prova1.API
{
    public class PersonagensController : ApiController
    {
        private MeuContexto db = new MeuContexto();

        // GET: api/Personagens
        public IQueryable<Personagens> GetPersonagens()
        {
            return db.Personagens;
        }

        // GET: api/Personagens/5
        [ResponseType(typeof(Personagens))]
        public IHttpActionResult GetPersonagens(int id)
        {
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return NotFound();
            }

            return Ok(personagens);
        }

        // PUT: api/Personagens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonagens(int id, Personagens personagens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personagens.PersonagensID)
            {
                return BadRequest();
            }

            db.Entry(personagens).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonagensExists(id))
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

        // POST: api/Personagens
        [ResponseType(typeof(Personagens))]
        public IHttpActionResult PostPersonagens(Personagens personagens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personagens.Add(personagens);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personagens.PersonagensID }, personagens);
        }

        // DELETE: api/Personagens/5
        [ResponseType(typeof(Personagens))]
        public IHttpActionResult DeletePersonagens(int id)
        {
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return NotFound();
            }

            db.Personagens.Remove(personagens);
            db.SaveChanges();

            return Ok(personagens);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonagensExists(int id)
        {
            return db.Personagens.Count(e => e.PersonagensID == id) > 0;
        }
    }
}