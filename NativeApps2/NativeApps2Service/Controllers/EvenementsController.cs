using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using NativeApps2Service.Models;

namespace NativeApps2Service.Controllers
{
    public class EvenementsController : ApiController
    {
        private NativeApps2ServiceContext db = new NativeApps2ServiceContext();

        // GET: api/Evenements
        public IQueryable<Evenement> GetEvenements()
        {
            return db.Evenements;
        }

        // GET: api/Evenements/5
        [ResponseType(typeof(Evenement))]
        public IHttpActionResult GetEvenement(int id)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return NotFound();
            }

            return Ok(evenement);
        }

        // PUT: api/Evenements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvenement(int id, Evenement evenement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evenement.EvenementID)
            {
                return BadRequest();
            }

            db.Entry(evenement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvenementExists(id))
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

        // POST: api/Evenements
        [ResponseType(typeof(Evenement))]
        public IHttpActionResult PostEvenement(Evenement evenement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Evenements.Add(evenement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = evenement.EvenementID }, evenement);
        }

        // DELETE: api/Evenements/5
        [ResponseType(typeof(Evenement))]
        public IHttpActionResult DeleteEvenement(int id)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return NotFound();
            }

            db.Evenements.Remove(evenement);
            db.SaveChanges();

            return Ok(evenement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvenementExists(int id)
        {
            return db.Evenements.Count(e => e.EvenementID == id) > 0;
        }
    }
}