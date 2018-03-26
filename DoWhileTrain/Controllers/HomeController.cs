using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoWhileTrain.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Trainings()
        {
            return View("~/Views/Training/Trainings.cshtml");
        }
        public ActionResult TrainingTypes()
        {
            return View("~/Views/Training/TrainingTypes.cshtml");
        }
        public ActionResult TrainingApparatus()
        {
            return View("~/Views/Training/TrainingApparatus.cshtml");
        }
    }
}