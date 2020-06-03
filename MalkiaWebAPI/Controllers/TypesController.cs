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
    public class TypesController : ApiController
    {
        private MalkiaDB db = new MalkiaDB();

        // GET: api/Types
        public IQueryable<Types> GetTypes()
        {
            return db.Types;
        }

        // GET: api/Types/5
        [ResponseType(typeof(Types))]
        public IHttpActionResult GetTypes(int id)
        {
            Types types = db.Types.Find(id);
            if (types == null)
            {
                return NotFound();
            }

            return Ok(types);
        }

        // PUT: api/Types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypes(int id, Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != types.TId)
            {
                return BadRequest();
            }

            db.Entry(types).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesExists(id))
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

        // POST: api/Types
        [ResponseType(typeof(Types))]
        public IHttpActionResult PostTypes(Types types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Types.Add(types);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TypesExists(types.TId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = types.TId }, types);
        }

        // DELETE: api/Types/5
        [ResponseType(typeof(Types))]
        public IHttpActionResult DeleteTypes(int id)
        {
            Types types = db.Types.Find(id);
            if (types == null)
            {
                return NotFound();
            }

            db.Types.Remove(types);
            db.SaveChanges();

            return Ok(types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypesExists(int id)
        {
            return db.Types.Count(e => e.TId == id) > 0;
        }
    }
}