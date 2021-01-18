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
    public class customer_policy_recordsController : Controller
    {
        private vimsEntities db = new vimsEntities();

        // GET: /customer_policy_records/
        public ActionResult Index()
        {
            return View(db.customer_policy_records.ToList());
        }

        // GET: /customer_policy_records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_policy_records customer_policy_records = db.customer_policy_records.Find(id);
            if (customer_policy_records == null)
            {
                return HttpNotFound();
            }
            return View(customer_policy_records);
        }

        // GET: /customer_policy_records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /customer_policy_records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Customer_ID,Customer_Name,Customer_Address,Customer_Phone,Policy_ID,Policy_Date,Policy_duration,Vehicle_ID,Vehicle_Name,Vehicle_Model,Vehicle_Version,Vehicle_Rate,Vehicle_Warranty,Vehicle_Body_Number,Vehicle_Engine_Number,Customer_Add_Prove")] customer_policy_records customer_policy_records)
        {
            if (ModelState.IsValid)
            {
                db.customer_policy_records.Add(customer_policy_records);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_policy_records);
        }

        // GET: /customer_policy_records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_policy_records customer_policy_records = db.customer_policy_records.Find(id);
            if (customer_policy_records == null)
            {
                return HttpNotFound();
            }
            return View(customer_policy_records);
        }

        // POST: /customer_policy_records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Customer_ID,Customer_Name,Customer_Address,Customer_Phone,Policy_ID,Policy_Date,Policy_duration,Vehicle_ID,Vehicle_Name,Vehicle_Model,Vehicle_Version,Vehicle_Rate,Vehicle_Warranty,Vehicle_Body_Number,Vehicle_Engine_Number,Customer_Add_Prove")] customer_policy_records customer_policy_records)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_policy_records).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_policy_records);
        }

        // GET: /customer_policy_records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_policy_records customer_policy_records = db.customer_policy_records.Find(id);
            if (customer_policy_records == null)
            {
                return HttpNotFound();
            }
            return View(customer_policy_records);
        }

        // POST: /customer_policy_records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customer_policy_records customer_policy_records = db.customer_policy_records.Find(id);
            db.customer_policy_records.Remove(customer_policy_records);
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
