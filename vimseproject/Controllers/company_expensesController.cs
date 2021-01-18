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
    public class company_expensesController : Controller
    {
        private vimsEntities db = new vimsEntities();

        // GET: /company_expenses/
        public ActionResult Index()
        {
            return View(db.company_expenses.ToList());
        }

        // GET: /company_expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_expenses company_expenses = db.company_expenses.Find(id);
            if (company_expenses == null)
            {
                return HttpNotFound();
            }
            return View(company_expenses);
        }

        // GET: /company_expenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /company_expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Expence_ID,Date_of_Expence,Type_of_Expence,Amount_of_Expence")] company_expenses company_expenses)
        {
            if (ModelState.IsValid)
            {
                db.company_expenses.Add(company_expenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company_expenses);
        }

        // GET: /company_expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_expenses company_expenses = db.company_expenses.Find(id);
            if (company_expenses == null)
            {
                return HttpNotFound();
            }
            return View(company_expenses);
        }

        // POST: /company_expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Expence_ID,Date_of_Expence,Type_of_Expence,Amount_of_Expence")] company_expenses company_expenses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_expenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company_expenses);
        }

        // GET: /company_expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_expenses company_expenses = db.company_expenses.Find(id);
            if (company_expenses == null)
            {
                return HttpNotFound();
            }
            return View(company_expenses);
        }

        // POST: /company_expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            company_expenses company_expenses = db.company_expenses.Find(id);
            db.company_expenses.Remove(company_expenses);
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
