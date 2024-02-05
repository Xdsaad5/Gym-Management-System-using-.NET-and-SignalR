using Microsoft.AspNetCore.Mvc;

namespace GYM.NET.Controllers
{
	public class PricingController : Controller
	{
		public IActionResult Pricing()
		{
			return View();
		}
	}
}
