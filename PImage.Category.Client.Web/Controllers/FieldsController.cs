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
    public class FieldsController : Controller
    {
        //private CategoryDataContext ws = new CategoryDataContext();
        private ServiceConnection ws = new ServiceConnection(ConfigurationManager.AppSettings["RestServiceURL"]);

        // GET: Fields
        public ActionResult Index()
        {
            return View(ws.Fields.Get());
        }

        // GET: Fields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = ws.Fields.Get(id.Value);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        // GET: Fields/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubCategoryId,Order,Description,Type")] Field field)
        {
            if (ModelState.IsValid)
            {
                ws.Fields.Create(field);
                return RedirectToAction("Index");
            }

            return View(field);
        }

        // GET: Fields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = ws.Fields.Get(id.Value);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubCategoryId,Order,Description,Type")] Field field)
        {
            if (ModelState.IsValid)
            {
                ws.Fields.Update(field);
                return RedirectToAction("Index");
            }
            return View(field);
        }

        // GET: Fields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = ws.Fields.Get(id.Value);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ws.Fields.Delete(id);
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
