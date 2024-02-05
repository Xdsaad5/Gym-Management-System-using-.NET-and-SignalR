using Microsoft.AspNetCore.Mvc;

namespace GYM.NET.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Blog()
		{
			return View();
		}
	}
}
