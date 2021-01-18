using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vimseproject.Models;

namespace vimseproject.Controllers
{
    public class vimscustomerController : Controller
    {
        vimsEntities db = new vimsEntities();

        //
        // GET: /vimscustomer/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Testimonials()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult typesofinsurance()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        // add view of buy policy from ado.net
        public ActionResult Buy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy([Bind(Include = "Customer_ID,Customer_Name,Customer_Address,Customer_Phone,Policy_ID,Policy_Date,Policy_duration,Vehicle_ID,Vehicle_Name,Vehicle_Model,Vehicle_Version,Vehicle_Rate,Vehicle_Warranty,Vehicle_Body_Number,Vehicle_Engine_Number,Customer_Add_Prove")] customer_policy_records customer_policy_records)
        {
            if (ModelState.IsValid)
            {
                db.customer_policy_records.Add(customer_policy_records);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        // add view of claim policy from ado.net
        public ActionResult claim()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult claim([Bind(Include = "Claim_ID,Policy_ID,Policy_Start_Date,Policy_End_Date,Customer_Name,Place_Of_Accident,Date_Of_Accident,Insured_Amount,Claimable_Amount")] claim_datails claim_datails)
        {
            if (ModelState.IsValid)
            {
                db.claim_datails.Add(claim_datails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claim_datails);
        }







        public ActionResult changepass()
        {
            return View();
        }









	}
}