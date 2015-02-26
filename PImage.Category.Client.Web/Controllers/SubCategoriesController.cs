using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PImage.Category.Client.Web.Models;
using PImage.Category.DTO;
using PImage.Category.Client.RestRepository;
using System.Configuration;

namespace PImage.Category.Client.Web.Controllers
{
    public class SubCategoriesController : Controller
    {
        private ServiceConnection ws = new ServiceConnection(ConfigurationManager.AppSettings["RestServiceURL"]);

        // GET: SubCategories
        public ActionResult Index()
        {
            var subCategories = ws.SubCategories.Get();
            return View(subCategories.ToList());
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = ws.SubCategories.Get(id.Value);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(ws.Categories.Get(), "Id", "Description");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Slug,CategoryId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                ws.SubCategories.Create(subCategory);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(ws.Categories.Get(), "Id", "Description", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = ws.SubCategories.Get(id.Value);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(ws.Categories.Get(), "Id", "Description", subCategory.CategoryId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Slug,CategoryId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                ws.SubCategories.Update(subCategory);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(ws.Categories.Get(), "Id", "Description", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = ws.SubCategories.Get(id.Value);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory subCategory = ws.SubCategories.Get(id);
            ws.SubCategories.Delete(subCategory.Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //ws.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
