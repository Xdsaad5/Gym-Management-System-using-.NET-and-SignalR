using GYM.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace GYM.NET.Controllers
{
	public class GalleryController : Controller
	{
		public IActionResult Gallery()
		{
			return View();
		}
        public IActionResult VideosGallery()
        {
            trainerRep Trainers = new trainerRep();
            List<TrainerVideo> avlTrainers = Trainers.getTrainersVideos();

            return View(avlTrainers);
        }

    }
}
