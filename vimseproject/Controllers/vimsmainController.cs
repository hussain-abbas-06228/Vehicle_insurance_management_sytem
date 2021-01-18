using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vimseproject.Models;

namespace vimseproject.Controllers
{
    public class vimsmainController : Controller
    {
        vimsEntities db = new vimsEntities();
        //
        // GET: /vimsmain/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loginemp()
        {
            return View();
        }

        public ActionResult loginuser()
        {
            return View();
        }

        public ActionResult postuser(userinfo us)
        {
          userinfo user = db.userinfoes.Where(i=>i.userName.Equals(us.userName)&& i.userpassword.Equals(us.userpassword)).FirstOrDefault();
          if (user != null)
          {
              return RedirectToAction("Index", "vimscustomer");
          }
          else
          {
              return RedirectToAction("loginuser");
          }
        }

        public ActionResult postemp(userinfo us)
        {
            userinfo user = db.userinfoes.Where(i => i.userName.Equals(us.userName) && i.userpassword.Equals(us.userpassword)).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("Index", "vimsemployee");
            }
            else
            {
                return RedirectToAction("loginemp");
            }
        }

        

	}
}