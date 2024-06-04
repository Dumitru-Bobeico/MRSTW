using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatFlow.BusinessLogic.DBModel;
using ChatFlow.Web.ViewModels;
using ChatFlow.Domains.Entities;
namespace ChatFlow.Web.Controllers
{
    public class AccountController : Controller
    {
		// GET: Account
		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterViewModel user)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (UserContext db = new UserContext())
					{
						var userAlreadyExists = db.Users.Any(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password));

						if (!userAlreadyExists)
						{
								User _user = new User();
							_user.Email = user.Email;
							_user.Password = user.Password;
							_user.Username = user.Username;
							_user.Imageurl = "";
							_user.CreatedOn = DateTime.Now;
							
							db.Users.Add(_user);
							db.SaveChanges();
						}
						else
						{
							// User already exists, handle accordingly (e.g., display an error message)
							ModelState.AddModelError(string.Empty, "User with this email already exists.");
							return View(user);
						}
					}
				}
				else
				{
					// Handle invalid model state (e.g., display validation errors)
					return View(user);
				}
			}
			catch (Exception ex)
			{
				// Log the exception or handle it in a way appropriate for your application
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(user);
			}

			return RedirectToAction("Index", "Home"); // Assuming redirect to the home page upon successful registration
		}


		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel user)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (UserContext db = new UserContext())
					{
						var obj = db.Users.Where(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password)).FirstOrDefault();
						if (obj != null)
						{
							// User is authenticated, handle accordingly (e.g., set session variables, redirect to home page)
							Session["UserID"] = obj.Id.ToString();
							Session["UserName"] = obj.Username;
							return RedirectToAction("Index", "Home");
						}
						else
						{
							// User is not authenticated, handle accordingly (e.g., display an error message)
							ModelState.AddModelError(string.Empty, "Invalid email or password.");
							return View(user);
						}
					}
				}
				else
				{
					// Handle invalid model state (e.g., display validation errors)
					return View(user);
				}
			}
			catch (Exception ex)
			{
				// Log the exception or handle it in a way appropriate for your application
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(user);
			}
		}	
	}
}