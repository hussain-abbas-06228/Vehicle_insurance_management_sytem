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
    public class vehicleinfoController : Controller
    {
        private vimsEntities db = new vimsEntities();

        // GET: /vehicleinfo/
        public ActionResult Index()
        {
            return View(db.vehicleinfoes.ToList());
        }

        // GET: /vehicleinfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicleinfo vehicleinfo = db.vehicleinfoes.Find(id);
            if (vehicleinfo == null)
            {
                return HttpNotFound();
            }
            return View(vehicleinfo);
        }

        // GET: /vehicleinfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /vehicleinfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Vehicle_ID,Vehicle_Name,Vehicles_Owner_Address,Vehicle_Model,Vehicle_Version,Vehicle_Rate,Vehicle_Body_Number,Vehicle_Engine_Number,Vehicle_Number")] vehicleinfo vehicleinfo)
        {
            if (ModelState.IsValid)
            {
                db.vehicleinfoes.Add(vehicleinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleinfo);
        }

        // GET: /vehicleinfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicleinfo vehicleinfo = db.vehicleinfoes.Find(id);
            if (vehicleinfo == null)
            {
                return HttpNotFound();
            }
            return View(vehicleinfo);
        }

        // POST: /vehicleinfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Vehicle_ID,Vehicle_Name,Vehicles_Owner_Address,Vehicle_Model,Vehicle_Version,Vehicle_Rate,Vehicle_Body_Number,Vehicle_Engine_Number,Vehicle_Number")] vehicleinfo vehicleinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleinfo);
        }

        // GET: /vehicleinfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicleinfo vehicleinfo = db.vehicleinfoes.Find(id);
            if (vehicleinfo == null)
            {
                return HttpNotFound();
            }
            return View(vehicleinfo);
        }

        // POST: /vehicleinfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicleinfo vehicleinfo = db.vehicleinfoes.Find(id);
            db.vehicleinfoes.Remove(vehicleinfo);
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
