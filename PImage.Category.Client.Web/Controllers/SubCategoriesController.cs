﻿using System;
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
        public ActionResult Index(int? id = null)
        {
            return View(ws.SubCategories.Get());
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

        //// GET: SubCategories/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create(int id)
        {
            SubCategory sub = new SubCategory() {CategoryId = id};
            return View(sub);
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
                //return RedirectToAction("Index");
                //return RedirectToAction("Index", "Categories");
                return RedirectToAction("Edit", "Categories", new { id = subCategory.CategoryId });
            }

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
                //return RedirectToAction("Index");
                return RedirectToAction("Edit", "Categories", new { id = subCategory.CategoryId});
            }
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
            ws.SubCategories.Delete(id);
            //return RedirectToAction("Index");
            return RedirectToAction("Edit", "Categories", new { id = id });
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
