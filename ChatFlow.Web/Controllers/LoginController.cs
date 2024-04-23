
using System.Web.Mvc;
using ChatFlow.BusinessLogic.DBModel;

namespace ChatFlow.Web.Controllers
{
	public class LoginController : Controller
    {

		private UserContext db = new UserContext();

		[HttpGet]
		// GET: Login1
		public ActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}


	}
}