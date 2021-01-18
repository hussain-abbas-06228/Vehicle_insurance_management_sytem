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
    public class billinginfoController : Controller
    {
        private vimsEntities db = new vimsEntities();

        // GET: /billinginfo/
        public ActionResult Index()
        {
            return View(db.billinginfoes.ToList());
        }

        // GET: /billinginfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billinginfo billinginfo = db.billinginfoes.Find(id);
            if (billinginfo == null)
            {
                return HttpNotFound();
            }
            return View(billinginfo);
        }

        // GET: /billinginfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /billinginfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Customer_ID,Customer_Name,Policy_ID,Customer_Add_Prove,Customer_Phone,Bill_ID,Vehicle_Name,Vehicle_Model,Vehicle_Rate,Vehicle_Body_Number,Vehicle_Engine_Number,Date,Amount")] billinginfo billinginfo)
        {
            if (ModelState.IsValid)
            {
                db.billinginfoes.Add(billinginfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billinginfo);
        }

        // GET: /billinginfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billinginfo billinginfo = db.billinginfoes.Find(id);
            if (billinginfo == null)
            {
                return HttpNotFound();
            }
            return View(billinginfo);
        }

        // POST: /billinginfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Customer_ID,Customer_Name,Policy_ID,Customer_Add_Prove,Customer_Phone,Bill_ID,Vehicle_Name,Vehicle_Model,Vehicle_Rate,Vehicle_Body_Number,Vehicle_Engine_Number,Date,Amount")] billinginfo billinginfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billinginfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billinginfo);
        }

        // GET: /billinginfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billinginfo billinginfo = db.billinginfoes.Find(id);
            if (billinginfo == null)
            {
                return HttpNotFound();
            }
            return View(billinginfo);
        }

        // POST: /billinginfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            billinginfo billinginfo = db.billinginfoes.Find(id);
            db.billinginfoes.Remove(billinginfo);
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
