using GreenTeam.Models;
using GreenTeam.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GreenTeam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            IdentityDataInitializer dataInitializer = new IdentityDataInitializer();
            dataInitializer.SeedData(roleManager);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}