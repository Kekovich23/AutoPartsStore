using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoPartsStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<User> manager)
        {
            _logger = logger;
            _userManager = manager;
        }
        
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
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
    }
}