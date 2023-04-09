using Ahmad.Models;
using Ahmad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ahmad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdminService _adminService;


        public HomeController(ILogger<HomeController> logger, AdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var results = _adminService.Load();
            return View(results);
        }

        public IActionResult FindRoom(int dragonId)
        {
            var roomName = _adminService.GetRoomName(dragonId);
            ViewBag.roomName = roomName;
            return Json(new { roomName = roomName });
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