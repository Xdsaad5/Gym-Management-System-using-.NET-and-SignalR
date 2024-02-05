using Microsoft.AspNetCore.Mvc;

namespace GYM.NET.Controllers
{
	public class CoursesController : Controller
	{
		public IActionResult Courses()
		{
			return View();
		}
	}
}
