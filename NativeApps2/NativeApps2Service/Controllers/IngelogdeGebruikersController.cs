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
    public class IngelogdeGebruikersController : ApiController
    {
        private NativeApps2ServiceContext db = new NativeApps2ServiceContext();

        // GET: api/IngelogdeGebruikers
        public IQueryable<IngelogdeGebruiker> GetIngelogdeGebruikers()
        {
            return db.IngelogdeGebruikers;
        }

        // GET: api/IngelogdeGebruikers/5
        [ResponseType(typeof(IngelogdeGebruiker))]
        public IHttpActionResult GetIngelogdeGebruiker(int id)
        {
            IngelogdeGebruiker ingelogdeGebruiker = db.IngelogdeGebruikers.Find(id);
            if (ingelogdeGebruiker == null)
            {
                return NotFound();
            }

            return Ok(ingelogdeGebruiker);
        }

        // PUT: api/IngelogdeGebruikers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngelogdeGebruiker(int id, IngelogdeGebruiker ingelogdeGebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingelogdeGebruiker.IngelogdeGebruikerID)
            {
                return BadRequest();
            }

            db.Entry(ingelogdeGebruiker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngelogdeGebruikerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
            //return Ok();
        }

        // PUT: api/VoegVolgendeOndernemingToe/rubenvdv id is gebruikersId
        [Route("IngelogdeGebruikers/VoegVolgendeOndernemingToe/{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoegVolgendeOndernemingToe(int id, [FromBody] int ondernemingsId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            db.VolgendeOndernemingen.Add(new IngelogdeGebruikerOndernemings() { OndernemingsId = ondernemingsId, IngelogdeGebruikersId = id });
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngelogdeGebruikerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/IngelogdeGebruikers
        [ResponseType(typeof(IngelogdeGebruiker))]
        public IHttpActionResult PostIngelogdeGebruiker(IngelogdeGebruiker ingelogdeGebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IngelogdeGebruikers.Add(ingelogdeGebruiker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingelogdeGebruiker.IngelogdeGebruikerID }, ingelogdeGebruiker);
        }

        // DELETE: api/IngelogdeGebruikers/5
        [ResponseType(typeof(IngelogdeGebruiker))]
        public IHttpActionResult DeleteIngelogdeGebruiker(int id)
        {
            IngelogdeGebruiker ingelogdeGebruiker = db.IngelogdeGebruikers.Find(id);
            if (ingelogdeGebruiker == null)
            {
                return NotFound();
            }

            db.IngelogdeGebruikers.Remove(ingelogdeGebruiker);
            db.SaveChanges();

            return Ok(ingelogdeGebruiker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngelogdeGebruikerExists(int id)
        {
            return db.IngelogdeGebruikers.Count(e => e.IngelogdeGebruikerID == id) > 0;
        }
    }
}