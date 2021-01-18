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
    public class customerinfoController : Controller
    {
        private vimsEntities db = new vimsEntities();

        // GET: /customerinfo/
        public ActionResult Index()
        {
            return View(db.customerinfoes.ToList());
        }

        // GET: /customerinfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerinfo customerinfo = db.customerinfoes.Find(id);
            if (customerinfo == null)
            {
                return HttpNotFound();
            }
            return View(customerinfo);
        }

        // GET: /customerinfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /customerinfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Customer_ID,Customer_Name,Customer_Address,Customer_Phone")] customerinfo customerinfo)
        {
            if (ModelState.IsValid)
            {
                db.customerinfoes.Add(customerinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerinfo);
        }

        // GET: /customerinfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerinfo customerinfo = db.customerinfoes.Find(id);
            if (customerinfo == null)
            {
                return HttpNotFound();
            }
            return View(customerinfo);
        }

        // POST: /customerinfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Customer_ID,Customer_Name,Customer_Address,Customer_Phone")] customerinfo customerinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerinfo);
        }

        // GET: /customerinfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerinfo customerinfo = db.customerinfoes.Find(id);
            if (customerinfo == null)
            {
                return HttpNotFound();
            }
            return View(customerinfo);
        }

        // POST: /customerinfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customerinfo customerinfo = db.customerinfoes.Find(id);
            db.customerinfoes.Remove(customerinfo);
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
