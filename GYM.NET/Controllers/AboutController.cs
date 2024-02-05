using Microsoft.AspNetCore.Mvc;

namespace GYM.NET.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult About()
		{
			return View("About");
		}
	}
}
