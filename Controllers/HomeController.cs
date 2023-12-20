using ASP.NETSchool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NETSchool.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        private UserManager<AppUser> _userManager;
       

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userMgr)
        {
            _logger = logger;
            _userManager = userMgr;
        }

        [Authorize]
        public async Task <IActionResult> Index() {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            string message = $"Hello {user.UserName}";
            return View("Index", message);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}