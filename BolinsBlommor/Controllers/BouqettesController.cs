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
using BolinsBlommor.Models;

namespace BolinsBlommor.Controllers
{
    public class BouqettesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Bouqettes
        public IQueryable<Bouqette> GetBouqettes()
        {
            return db.Bouqettes;
        }

        // GET: api/Bouqettes/5
        [ResponseType(typeof(Bouqette))]
        public IHttpActionResult GetBouqette(int id)
        {
            Bouqette bouqette = db.Bouqettes.Find(id);
            if (bouqette == null)
            {
                return NotFound();
            }

            return Ok(bouqette);
        }

        // PUT: api/Bouqettes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBouqette(int id, Bouqette bouqette)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bouqette.Id)
            {
                return BadRequest();
            }

            db.Entry(bouqette).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BouqetteExists(id))
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

        // POST: api/Bouqettes
        [ResponseType(typeof(Bouqette))]
        public IHttpActionResult PostBouqette(Bouqette bouqette)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bouqettes.Add(bouqette);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bouqette.Id }, bouqette);
        }

        // DELETE: api/Bouqettes/5
        [ResponseType(typeof(Bouqette))]
        public IHttpActionResult DeleteBouqette(int id)
        {
            Bouqette bouqette = db.Bouqettes.Find(id);
            if (bouqette == null)
            {
                return NotFound();
            }

            db.Bouqettes.Remove(bouqette);
            db.SaveChanges();

            return Ok(bouqette);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BouqetteExists(int id)
        {
            return db.Bouqettes.Count(e => e.Id == id) > 0;
        }
    }
}