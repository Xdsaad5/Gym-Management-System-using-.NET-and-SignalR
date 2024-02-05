using GYM.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Web;
namespace GYM.NET.Controllers
{
	public class TrainerController : Controller
	{
		public string GetCookieValue( string key)
		{
			HttpContext context = HttpContext;
			string? v = context.Request.Cookies[key];
			string value = v;
			return value;

		}
		public ViewResult trainerHome()
		{
			if (this.GetCookieValue("Email") == null)
				return View("/Views/Home/trainerLogin.cshtml", "Please Login First");
			return View();
		}
		public ViewResult Image()
		{
			if (this.GetCookieValue("Email") == null)
				return View("/Views/Home/trainerLogin.cshtml", "Please Login First");
			return View();
		}
		[HttpPost]
		public IActionResult UploadImage(IFormFile imgFile)
		{
			Random r = new Random();
			int random = r.Next();
			if (imgFile != null && imgFile.Length > 0)
			{
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "uploadTrainerImages", random.ToString() + imgFile.FileName);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					imgFile.CopyTo(stream);
				}
				Console.WriteLine(path);
				TrainerImage tImg = new TrainerImage
				{
					Email = this.GetCookieValue("Email"),
					ImageUrl = path
				};
				trainerRep tRep = new trainerRep();
				tRep.insertTrainerImages(tImg);
				return View("Image", "Successfully Updated.");
			}

			return View("Image", "Select Image to upload.");
		}
		public ViewResult Video()
		{
			if (this.GetCookieValue("Email") == null)
				return View("/Views/Home/trainerLogin.cshtml", "Please Login First");
			return View();
		}
		[HttpPost]
		public IActionResult UploadVideo(IFormFile vidFile)
		{
			Random r = new Random();
			int random = r.Next();
			if (vidFile != null && vidFile.Length > 0)
			{
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "uploadTrainerVideos", random.ToString() + vidFile.FileName);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					vidFile.CopyTo(stream);
				}
				Console.WriteLine(path);
				TrainerVideo tVid = new TrainerVideo
				{
					Email = this.GetCookieValue("Email"),
					VideoUrl = path
				};
				trainerRep tRep = new trainerRep();
				tRep.insertTrainerVideo(tVid);
				return View("Video", "Successfully Updated.");
			}

			return View("Video", "Select Video to upload.");
		}
		public ViewResult Logout()
		{
			if(this.GetCookieValue("Email") == null)
				return View("/Views/Home/trainerLogin.cshtml", "You didn't Login."); 
			HttpContext context = HttpContext;
			context.Response.Cookies.Delete("Email");
			return View("/Views/Home/Index.cshtml");
		}

	}
}
