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
    public class claim_datailsController : Controller
    {
        private vimsEntities db = new vimsEntities();

        // GET: /claim_datails/
        public ActionResult Index()
        {
            return View(db.claim_datails.ToList());
        }

        // GET: /claim_datails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claim_datails claim_datails = db.claim_datails.Find(id);
            if (claim_datails == null)
            {
                return HttpNotFound();
            }
            return View(claim_datails);
        }

        // GET: /claim_datails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /claim_datails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Claim_ID,Policy_ID,Policy_Start_Date,Policy_End_Date,Customer_Name,Place_Of_Accident,Date_Of_Accident,Insured_Amount,Claimable_Amount")] claim_datails claim_datails)
        {
            if (ModelState.IsValid)
            {
                db.claim_datails.Add(claim_datails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claim_datails);
        }

        // GET: /claim_datails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claim_datails claim_datails = db.claim_datails.Find(id);
            if (claim_datails == null)
            {
                return HttpNotFound();
            }
            return View(claim_datails);
        }

        // POST: /claim_datails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Claim_ID,Policy_ID,Policy_Start_Date,Policy_End_Date,Customer_Name,Place_Of_Accident,Date_Of_Accident,Insured_Amount,Claimable_Amount")] claim_datails claim_datails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claim_datails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claim_datails);
        }

        // GET: /claim_datails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claim_datails claim_datails = db.claim_datails.Find(id);
            if (claim_datails == null)
            {
                return HttpNotFound();
            }
            return View(claim_datails);
        }

        // POST: /claim_datails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            claim_datails claim_datails = db.claim_datails.Find(id);
            db.claim_datails.Remove(claim_datails);
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
