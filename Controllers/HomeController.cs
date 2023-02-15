using DitributiveSystem.Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DitributiveSystem.Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string firstName, string lastName, string email)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "One of the fields is empty.";
                return View();
            }
            ViewBag.ErrorMessage = "";
            //return Content($"FirstName: {firstName}\nLastName: {lastName}\nEmail: {email}");
            return View("Answer", new UserViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            });
        }
        [Route("ToBack")]
        public ActionResult ToBack()
        {
            return View("Index");
        }
    }
}