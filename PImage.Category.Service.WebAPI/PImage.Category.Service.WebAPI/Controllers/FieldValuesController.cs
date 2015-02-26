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
using PImage.Category.DTO;
using PImage.Category.DataModel;

namespace PImage.Category.Service.WebAPI.Controllers
{
    public class FieldValuesController : ApiController
    {
        private CategoryDataContext db = new CategoryDataContext();

        // GET: api/FieldValues
        public IQueryable<FieldValues> GetFieldValues()
        {
            return db.FieldValues;
        }

        // GET: api/FieldValues/5
        [ResponseType(typeof(FieldValues))]
        public IHttpActionResult GetFieldValues(int id)
        {
            FieldValues fieldValues = db.FieldValues.Find(id);
            if (fieldValues == null)
            {
                return NotFound();
            }

            return Ok(fieldValues);
        }

        // PUT: api/FieldValues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFieldValues(int id, FieldValues fieldValues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fieldValues.Id)
            {
                return BadRequest();
            }

            db.Entry(fieldValues).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldValuesExists(id))
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

        // POST: api/FieldValues
        [ResponseType(typeof(FieldValues))]
        public IHttpActionResult PostFieldValues(FieldValues fieldValues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FieldValues.Add(fieldValues);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fieldValues.Id }, fieldValues);
        }

        // DELETE: api/FieldValues/5
        [ResponseType(typeof(FieldValues))]
        public IHttpActionResult DeleteFieldValues(int id)
        {
            FieldValues fieldValues = db.FieldValues.Find(id);
            if (fieldValues == null)
            {
                return NotFound();
            }

            db.FieldValues.Remove(fieldValues);
            db.SaveChanges();

            return Ok(fieldValues);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FieldValuesExists(int id)
        {
            return db.FieldValues.Count(e => e.Id == id) > 0;
        }
    }
}