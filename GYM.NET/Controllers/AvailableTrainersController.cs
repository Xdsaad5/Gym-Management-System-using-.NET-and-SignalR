using GYM.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace GYM.NET.Controllers
{
    public class AvailableTrainersController : Controller
    {

        public IActionResult Index()
        {
            trainerRep Trainers = new trainerRep();
            List<Trainer> avlTrainers=Trainers.getTrainers();

            return View(avlTrainers);
        }
    }
}
