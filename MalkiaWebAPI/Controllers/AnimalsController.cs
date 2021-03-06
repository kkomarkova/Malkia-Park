﻿using System;
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
    public class AnimalsController : ApiController
    {
        private MalkiaDB db = new MalkiaDB();

        // GET: api/Animals
        public IQueryable<Animals> GetAnimals()
        {
            return db.Animals;
        }

        // GET: api/Animals/5
        [ResponseType(typeof(Animals))]
        public IHttpActionResult GetAnimals(int id)
        {
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return NotFound();
            }

            return Ok(animals);
        }

        // PUT: api/Animals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnimals(int id, Animals animals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animals.AId)
            {
                return BadRequest();
            }

            db.Entry(animals).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalsExists(id))
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

        // POST: api/Animals
        [ResponseType(typeof(Animals))]
        public IHttpActionResult PostAnimals(Animals animals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Animals.Add(animals);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnimalsExists(animals.AId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = animals.AId }, animals);
        }

        // DELETE: api/Animals/5
        [ResponseType(typeof(Animals))]
        public IHttpActionResult DeleteAnimals(int id)
        {
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return NotFound();
            }

            db.Animals.Remove(animals);
            db.SaveChanges();

            return Ok(animals);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalsExists(int id)
        {
            return db.Animals.Count(e => e.AId == id) > 0;
        }
    }
}