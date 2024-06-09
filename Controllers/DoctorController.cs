using Microsoft.AspNetCore.Mvc;
using Temperaturechecker.Models;

namespace TempretureControllers
{
    public class DoctorController : Controller
    {
        //Get
        public IActionResult Index()
        {
            ViewBag.temperature = 99.5;
            ViewBag.sclae = "celcius";
            ViewBag.message = HttpContext.Session.GetString("message");
            return View();
        }
        public IActionResult FeverCheck()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FeverCheck(float temperature, string scale)
        {
            string message = TemperatureChecker.CheckTemperature(temperature, scale);
            ViewBag.Message = message;
            return View();
        }
    }
}


