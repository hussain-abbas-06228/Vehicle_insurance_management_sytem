using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vimseproject.Models;

namespace vimseproject.Controllers
{
    public class estimateController : Controller
    {
        private vimsEntities db = new vimsEntities();

        // GET: /estimate/
        public ActionResult Index()
        {
            return View(db.estimates.ToList());
        }

        // GET: /estimate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estimate estimate = db.estimates.Find(id);
            if (estimate == null)
            {
                return HttpNotFound();
            }
            return View(estimate);
        }

        // GET: /estimate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /estimate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Customer_ID,Estimate_Number,Customer_Name,Customer_Phone,Vehicle_Name,Vehicle_Model,Vehicle_Rate,Vehicle_Waranty,Vehicle_Policy_type")] estimate estimate)
        {
            if (ModelState.IsValid)
            {
                db.estimates.Add(estimate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estimate);
        }

        // GET: /estimate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estimate estimate = db.estimates.Find(id);
            if (estimate == null)
            {
                return HttpNotFound();
            }
            return View(estimate);
        }

        // POST: /estimate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Customer_ID,Estimate_Number,Customer_Name,Customer_Phone,Vehicle_Name,Vehicle_Model,Vehicle_Rate,Vehicle_Waranty,Vehicle_Policy_type")] estimate estimate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estimate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estimate);
        }

        // GET: /estimate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estimate estimate = db.estimates.Find(id);
            if (estimate == null)
            {
                return HttpNotFound();
            }
            return View(estimate);
        }

        // POST: /estimate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estimate estimate = db.estimates.Find(id);
            db.estimates.Remove(estimate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
