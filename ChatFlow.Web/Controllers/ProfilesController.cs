using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatFlow.Web.Controllers
{
    public class ProfilesController : Controller
    {
        // GET: Profiles
        public ActionResult Index()
        {
            return View();
        }
    }
}