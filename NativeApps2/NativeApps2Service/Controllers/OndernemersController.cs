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
using NativeApps2Service.Models;

namespace NativeApps2Service.Controllers
{
    public class OndernemersController : ApiController
    {
        private NativeApps2ServiceContext db = new NativeApps2ServiceContext();

        // GET: api/Ondernemers
        public IQueryable<Ondernemer> GetOndernemers()
        {
            return db.Ondernemers;
        }

        // GET: api/Ondernemers/5
        [ResponseType(typeof(Ondernemer))]
        public IHttpActionResult GetOndernemer(int id)
        {
            Ondernemer ondernemer = db.Ondernemers.Find(id);
            if (ondernemer == null)
            {
                return NotFound();
            }

            return Ok(ondernemer);
        }

        // PUT: api/Ondernemers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOndernemer(int id, Ondernemer ondernemer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ondernemer.OndernemerID)
            {
                return BadRequest();
            }

            db.Entry(ondernemer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OndernemerExists(id))
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

        // POST: api/Ondernemers
        [ResponseType(typeof(Ondernemer))]
        public IHttpActionResult PostOndernemer(Ondernemer ondernemer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ondernemers.Add(ondernemer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ondernemer.OndernemerID }, ondernemer);
        }

        // DELETE: api/Ondernemers/5
        [ResponseType(typeof(Ondernemer))]
        public IHttpActionResult DeleteOndernemer(int id)
        {
            Ondernemer ondernemer = db.Ondernemers.Find(id);
            if (ondernemer == null)
            {
                return NotFound();
            }

            db.Ondernemers.Remove(ondernemer);
            db.SaveChanges();

            return Ok(ondernemer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OndernemerExists(int id)
        {
            return db.Ondernemers.Count(e => e.OndernemerID == id) > 0;
        }
    }
}