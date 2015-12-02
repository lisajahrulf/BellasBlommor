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
    public class DeliveryPersonsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/DeliveryPersons
        public IQueryable<DeliveryPerson> GetDeliveryPersons()
        {
            return db.DeliveryPersons;
        }

        // GET: api/DeliveryPersons/5
        [ResponseType(typeof(DeliveryPerson))]
        public IHttpActionResult GetDeliveryPerson(int id)
        {
            DeliveryPerson deliveryPerson = db.DeliveryPersons.Find(id);
            if (deliveryPerson == null)
            {
                return NotFound();
            }

            return Ok(deliveryPerson);
        }

        // PUT: api/DeliveryPersons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeliveryPerson(int id, DeliveryPerson deliveryPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryPerson.Id)
            {
                return BadRequest();
            }

            db.Entry(deliveryPerson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryPersonExists(id))
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

        // POST: api/DeliveryPersons
        [ResponseType(typeof(DeliveryPerson))]
        public IHttpActionResult PostDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliveryPersons.Add(deliveryPerson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deliveryPerson.Id }, deliveryPerson);
        }

        // DELETE: api/DeliveryPersons/5
        [ResponseType(typeof(DeliveryPerson))]
        public IHttpActionResult DeleteDeliveryPerson(int id)
        {
            DeliveryPerson deliveryPerson = db.DeliveryPersons.Find(id);
            if (deliveryPerson == null)
            {
                return NotFound();
            }

            db.DeliveryPersons.Remove(deliveryPerson);
            db.SaveChanges();

            return Ok(deliveryPerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryPersonExists(int id)
        {
            return db.DeliveryPersons.Count(e => e.Id == id) > 0;
        }
    }
}