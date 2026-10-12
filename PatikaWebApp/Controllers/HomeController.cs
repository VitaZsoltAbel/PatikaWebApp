using Microsoft.AspNetCore.Mvc;
using PatikaWebApp.Models;
using PatikaWebApp.Services;
using System.Diagnostics;


namespace PatikaWebApp.Controllers
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
            var gyogyszerek = new GyogyszerService().GetAllGyogyszer();
            return View(gyogyszerek);
        }

        public IActionResult Gyogyszerek()
        {
            var model = new GyogyszerService(); 
            return View(model);
        }

        public IActionResult Reszletek(int id)
        {
            var gyogyszer = new GyogyszerService().GetById(id); 
            if (gyogyszer == null)
            {
                return NotFound();
            }
            return View(gyogyszer);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Sajat()
        {
            List<Gyogyszer> gyogyszerek = new GyogyszerService().GetAllGyogyszer();
            return View(gyogyszerek);
        }

        public IActionResult Gyogyszer(int id)
        {
            Gyogyszer customer = new GyogyszerService().GetById(id);
            return View(customer);
        }
    }
}
