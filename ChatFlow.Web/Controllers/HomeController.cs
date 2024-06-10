using ChatFlow.BusinessLogic.Interfaces;
using ChatFlow.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatFlow.Web.Controllers
{
    public class HomeController : BaseController
    {
          private readonly ISession _session;
          public HomeController()
          {
               var bl = new BusinesLogic();
               _session = bl.GetSessionBL();
          }

        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

          // GET: Home
          public ActionResult Index()
        {
               GetUser();
            if(ViewBag.User == null)
            {
				return RedirectToAction("Login", "Account");
			}
            return View();

        }
          public void GetUser()
          {
               SessionStatus();
               var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];

               string userStatus = (string)System.Web.HttpContext.Current.Session["LoginStatus"];
               if (userStatus != "logout")
               {
                    var profile = _session.GetUserByCookie(apiCookie.Value);
                    ViewBag.User = profile;
               }
               else if (userStatus == "logout")
               {
                    ViewBag.User = null;
               }
          }
     }
}