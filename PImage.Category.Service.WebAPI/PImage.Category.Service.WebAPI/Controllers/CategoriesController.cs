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
using PImage.Category.DataModel;
using Model = PImage.Category.DataModel;

namespace PImage.Category.Service.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class CategoriesController : ApiController
    {
        private CategoryEntities db = new CategoryEntities();

        #region Category
        // GET: api/Categories
        [Route("Categories")]
        public IQueryable<Model.Category> GetCategory()
        {
            return db.Category;
        }

        // GET: api/Categories/5
        [Route("Categories")]
        [ResponseType(typeof(Model.Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Model.Category category = db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [Route("Categories")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Model.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [Route("Categories")]
        [ResponseType(typeof(Model.Category))]
        public IHttpActionResult PostCategory(Model.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Category.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [Route("Categories")]
        [ResponseType(typeof(Model.Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Model.Category category = db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Category.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        private bool CategoryExists(int id)
        {
            return db.Category.Count(e => e.Id == id) > 0;
        }

        #endregion

        #region SubCategory
        // GET: api/Categories
        [Route("SubCategories")]
        public IQueryable<Model.SubCategory> GetSubCategory()
        {
            return db.SubCategory;
        }

        // GET: api/Categories/5
        [Route("SubCategories")]
        [ResponseType(typeof(Model.SubCategory))]
        public IHttpActionResult GetSubCategory(int id)
        {
            Model.Category category = db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [Route("SubCategories")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Model.SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(subCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST: api/Categories
        [Route("SubCategories")]
        [ResponseType(typeof(Model.SubCategory))]
        public IHttpActionResult PostCategory(Model.SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategory.Add(subCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subCategory.Id }, subCategory);
        }

        // DELETE: api/Categories/5
        [Route("SubCategories")]
        [ResponseType(typeof(Model.SubCategory))]
        public IHttpActionResult DeleteSubCategory(int id)
        {
            Model.SubCategory subCategory = db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            db.SubCategory.Remove(subCategory);
            db.SaveChanges();

            return Ok(subCategory);
        }
        
        private bool SubCategoryExists(int id)
        {
            return db.SubCategory.Count(e => e.Id == id) > 0;
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}