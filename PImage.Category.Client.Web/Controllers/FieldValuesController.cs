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
    public class FieldValuesController : Controller
    {
        private ServiceConnection ws = new ServiceConnection(ConfigurationManager.AppSettings["RestServiceURL"]);

        // GET: FieldValues
        public ActionResult Index()
        {
            return View(ws.FieldValues.Get());
        }

        // GET: FieldValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldValues fieldValues = ws.FieldValues.Get(id.Value);
            if (fieldValues == null)
            {
                return HttpNotFound();
            }
            return View(fieldValues);
        }

        // GET: FieldValues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FieldValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FieldId,Order,FieldValue")] FieldValues fieldValues)
        {
            if (ModelState.IsValid)
            {
                ws.FieldValues.Create(fieldValues);
                return RedirectToAction("Index");
            }

            return View(fieldValues);
        }

        // GET: FieldValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldValues fieldValues = ws.FieldValues.Get(id.Value);
            if (fieldValues == null)
            {
                return HttpNotFound();
            }
            return View(fieldValues);
        }

        // POST: FieldValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FieldId,Order,FieldValue")] FieldValues fieldValues)
        {
            if (ModelState.IsValid)
            {
                ws.FieldValues.Update(fieldValues);
                return RedirectToAction("Index");
            }
            return View(fieldValues);
        }

        // GET: FieldValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldValues fieldValues = ws.FieldValues.Get(id.Value);
            if (fieldValues == null)
            {
                return HttpNotFound();
            }
            return View(fieldValues);
        }

        // POST: FieldValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ws.FieldValues.Delete(id);
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
