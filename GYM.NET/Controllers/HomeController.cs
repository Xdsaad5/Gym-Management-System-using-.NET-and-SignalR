using GYM.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Web;
namespace GYM.NET.Controllers
{
	public class HomeController : Controller
	{
		public void CreateCookie(string key, string value)
		{
			// Create a new cookie instance
			HttpContext context = HttpContext;
			CookieOptions options = new CookieOptions();

			// Set the cookie values
			options.Expires = DateTime.Now.AddMinutes(5); // Cookie expiration date
			options.Path = "/"; // Cookie path (available to all pages)

			// Add values to the cookie
			context.Response.Cookies.Append(key, value, options);
		}
		public IActionResult Index()
		{
			return View();
		}
		public ViewResult traineeSignup()
		{
			return View();
		}
		[HttpPost]
		public ViewResult traineeInfo(Trainee obj)
		{
			traineeRep traineeRep = new traineeRep();
			var status = traineeRep.alreadyExist(obj);
			if (status)
				return View("traineeSignup", "Username Already Exist.");
			status = traineeRep.insertTrainee(obj);
			if (status == false)
				return View("traineeSignup", "Wrong Credentials.Try again");
			CreateCookie("Username", obj.Username.ToString());
			return View("home");
		}
		public ViewResult trainerSignup()
		{
			return View();
		}
		[HttpPost]
		public ViewResult trainerInfo(Trainer obj)
		{
			trainerRep trainerRep = new trainerRep();
			var status = trainerRep.alreadyExist(obj);
			if (status)
				return View("trainerSignup", "Email Already Exist.");
			status = trainerRep.insertTrainer(obj);
			if (status == false)
				return View("trainerSignup", "Wrong Credentials.Try again");
			CreateCookie("Email", obj.Email.ToString());
			return View("/Views/Trainer/trainerHome.cshtml");

		}
		public ViewResult traineeLogin()
		{
			return View();
		}
		[HttpPost]
		public ViewResult traineeLoginInfo(Trainee obj)
		{
			traineeRep traineeRep = new traineeRep();
			var status = traineeRep.alreadyExist(obj);
			if (status == false)
				return View("traineeLogin", "User Not Found.");
			status = traineeRep.traineeVarification(obj);
			if (status == false)
				return View("traineeLogin", "Wrong Username or Password.Try again");
			CreateCookie("Username", obj.Username.ToString());
			
			return View("home", obj.Username.ToString());
		}
		public ViewResult trainerLogin()
		{
			return View();
		}
		[HttpPost]
		public ViewResult trainerLoginInfo(Trainer obj)
		{
			trainerRep trainerRep = new trainerRep();
			var status = trainerRep.alreadyExist(obj);
			if (status == false)
				return View("trainerLogin", "Email Not Found.");
			status = trainerRep.trainerVarification(obj);
			if (status == false)
				return View("trainerLogin", "Wrong Email or Password.Try again");
			string name = obj.Name;
			CreateCookie("Email", obj.Email.ToString());
			return View("/Views/Trainer/trainerHome.cshtml", "Saad");
		}
       

       
    }
}