using Microsoft.AspNetCore.Mvc;

namespace GYM.NET.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Contact()
		{
			return View("Contact");
		}
	}
}
