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
using MalkiaParkWebAPi;

namespace MalkiaParkWebAPi.Controllers
{
    public class AdoptersController : ApiController
    {
        private MalkiaParkDB db = new MalkiaParkDB();

        // GET: api/Adopters
        public IQueryable<Adopters> GetAdopters()
        {
            return db.Adopters;
        }

        // GET: api/Adopters/5
        [ResponseType(typeof(Adopters))]
        public IHttpActionResult GetAdopters(int id)
        {
            Adopters adopters = db.Adopters.Find(id);
            if (adopters == null)
            {
                return NotFound();
            }

            return Ok(adopters);
        }

        // PUT: api/Adopters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdopters(int id, Adopters adopters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adopters.OId)
            {
                return BadRequest();
            }

            db.Entry(adopters).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptersExists(id))
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

        // POST: api/Adopters
        [ResponseType(typeof(Adopters))]
        public IHttpActionResult PostAdopters(Adopters adopters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adopters.Add(adopters);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdoptersExists(adopters.OId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adopters.OId }, adopters);
        }

        // DELETE: api/Adopters/5
        [ResponseType(typeof(Adopters))]
        public IHttpActionResult DeleteAdopters(int id)
        {
            Adopters adopters = db.Adopters.Find(id);
            if (adopters == null)
            {
                return NotFound();
            }

            db.Adopters.Remove(adopters);
            db.SaveChanges();

            return Ok(adopters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdoptersExists(int id)
        {
            return db.Adopters.Count(e => e.OId == id) > 0;
        }
    }
}