using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
        public IHttpActionResult GetIngelogdeGebruiker(string id)
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
        public IHttpActionResult PutIngelogdeGebruiker(string id, IngelogdeGebruiker ingelogdeGebruiker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingelogdeGebruiker.Gebruikersnaam)
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

            return Ok();
        }

        // PUT: api/VoegVolgendeOndernemingToe/rubenvdv id is gebruikersnaam
        [Route("IngelogdeGebruikers/VoegVolgendeOndernemingToe/{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoegVolgendeOndernemingToe(string id,[FromBody] int ondernemingsid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



          db.VolgendeOndernemingen.Add(new IngelogdeGebruikerOndernemings() { OndernemingsId = ondernemingsid, Gebruikersnaam = id });
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

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IngelogdeGebruikerExists(ingelogdeGebruiker.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ingelogdeGebruiker.Email }, ingelogdeGebruiker);
        }

        // DELETE: api/IngelogdeGebruikers/5
        [ResponseType(typeof(IngelogdeGebruiker))]
        public IHttpActionResult DeleteIngelogdeGebruiker(string id)
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

        private bool IngelogdeGebruikerExists(string id)
        {
            return db.IngelogdeGebruikers.Count(e => e.Email == id) > 0;
        }
    }
}