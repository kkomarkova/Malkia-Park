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
using MalkiaWebApi;

namespace MalkiaWebApi.Controllers
{
    public class AnimalsAdoptersController : ApiController
    {
        private MalkiaDB db = new MalkiaDB();

        // GET: api/AnimalsAdopters
        public IQueryable<AnimalsAdopters> GetAnimalsAdopters()
        {
            return db.AnimalsAdopters;
        }

        // GET: api/AnimalsAdopters/5
        [ResponseType(typeof(AnimalsAdopters))]
        public IHttpActionResult GetAnimalsAdopters(int id)
        {
            AnimalsAdopters animalsAdopters = db.AnimalsAdopters.Find(id);
            if (animalsAdopters == null)
            {
                return NotFound();
            }

            return Ok(animalsAdopters);
        }

        // PUT: api/AnimalsAdopters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnimalsAdopters(int id, AnimalsAdopters animalsAdopters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animalsAdopters.AdoptionId)
            {
                return BadRequest();
            }

            db.Entry(animalsAdopters).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalsAdoptersExists(id))
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

        // POST: api/AnimalsAdopters
        [ResponseType(typeof(AnimalsAdopters))]
        public IHttpActionResult PostAnimalsAdopters(AnimalsAdopters animalsAdopters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnimalsAdopters.Add(animalsAdopters);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = animalsAdopters.AdoptionId }, animalsAdopters);
        }

        // DELETE: api/AnimalsAdopters/5
        [ResponseType(typeof(AnimalsAdopters))]
        public IHttpActionResult DeleteAnimalsAdopters(int id)
        {
            AnimalsAdopters animalsAdopters = db.AnimalsAdopters.Find(id);
            if (animalsAdopters == null)
            {
                return NotFound();
            }

            db.AnimalsAdopters.Remove(animalsAdopters);
            db.SaveChanges();

            return Ok(animalsAdopters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalsAdoptersExists(int id)
        {
            return db.AnimalsAdopters.Count(e => e.AdoptionId == id) > 0;
        }
    }
}