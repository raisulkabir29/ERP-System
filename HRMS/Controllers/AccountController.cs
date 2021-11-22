using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Threading;


namespace HRMS.Controllers
{
	public class AccountController : Controller
	{
		//
		SIContext db = new SIContext();
		// GET: /Account/
		public ActionResult login()
		{
			if (Env.GetUserInfo("name").Length > 0)
				return Redirect("~/Home/Index");
			else
				return View();
		}

		[HttpPost]
		public ActionResult login(System.Web.Mvc.FormCollection frmCollection)
		{
			string email = frmCollection["email"].ToString();
			string password = frmCollection["password"].ToString();
			var login = db.Users.FirstOrDefault(i => i.UserName == email && i.Password == password);
			if (login != null)
			{
				var claims = new List<Claim>();
				claims.Add(new Claim(ClaimTypes.Name, login.UserName.ToString())); // store username of user
				claims.Add(new Claim(ClaimTypes.Role, login.RoleUser_UserIds.FirstOrDefault().RoleId.ToString()));
				claims.Add(new Claim(ClaimTypes.Sid, login.Id.ToString())); // store id of user
				claims.Add(new Claim(ClaimTypes.GivenName, login.Office_OfficeId.CompanyId.ToString()));//store company id of user
				claims.Add(new Claim(ClaimTypes.GroupSid, login.OfficeId.ToString()));//sore office id of user
				claims.Add(new Claim(ClaimTypes.Actor,login.Office_OfficeId.Company_CompanyId.Name.ToString()));
				claims.Add(new Claim(ClaimTypes.Locality, login.Office_OfficeId.Title.ToString()));
				//claims.Add(new Claim(ClaimTypes.Picture, login.ProfilePicture.ToString())); // store username of user

				var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
				var authenticationManager = Request.GetOwinContext().Authentication;
				authenticationManager.SignIn(identity);

				var claimsPrincipal = new ClaimsPrincipal(identity);
				Thread.CurrentPrincipal = claimsPrincipal;

				return Redirect("~/Home/Index");
			}
			else
			{
				ViewBag.Msg = "!Invalid UserName and Password";
			}
			return View();
		}

		public ActionResult register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult register(System.Web.Mvc.FormCollection frmCollection)
		{
			User user = new User();
			user.UserName = frmCollection["name"];
			user.Password = frmCollection["password2"];
			db.Users.Add(user);

			//REGISTER USER ROLE
			RoleUser roleuser = new RoleUser();
			roleuser.RoleId = 1;
			roleuser.UserId = user.Id;
			db.RoleUsers.Add(roleuser);
			db.SaveChanges();
			
			ViewBag.Msg = "Register Successfully";
			return View();
		}

		public ActionResult signout()
		{
			AuthenticationManager.SignOut(); 
			HttpCookie c = new HttpCookie(".AspNet.ApplicationCookie");
			c.Expires = DateTime.Now.AddDays(-1);
			Response.Cookies.Add(c); 

			HttpCookie d = new HttpCookie("__RequestVerificationToken");
			d.Expires = DateTime.Now.AddDays(-1);
			Response.Cookies.Add(d);

			return RedirectToAction("login", "Account");
		}
		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}
		
		public ActionResult unauthorized()
		{
			return View();
		}
	}
}

