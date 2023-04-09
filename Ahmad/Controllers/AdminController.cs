using Ahmad.Models;
using Ahmad.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ahmad.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _service;
        private readonly RoomService _roomService;

        public AdminController(AdminService service, RoomService roomService)
        {
            _service = service;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var dragons = _service.GetAllDragons();
            return View(dragons);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dragon = _service.GetDragonById(id.Value);
            if (dragon == null)
            {
                return NotFound();
            }

            return View(dragon);
        }

        public IActionResult Create()
        {
            var result = _roomService.GetAllRooms();

            return View(new CrudDragonModel
            {
                Rooms = result
            }) ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,RoomId")] Dragon dragon)
        {
            if (ModelState.IsValid)
            {
                _service.AddDragon(dragon);
                return RedirectToAction(nameof(Index));
            }
            return View(dragon);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dragon = _service.GetDragonById(id.Value);
            var rooms = _roomService.GetAllRooms();
            if (dragon == null)
            {
                return NotFound();
            }
            return View(new CrudDragonModel
            {
                Dragon = dragon,
                Rooms = rooms
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,RoomId")] Dragon dragon)
        {
            if (id != dragon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.UpdateDragon(dragon);
                return RedirectToAction(nameof(Index));
            }
            return View(dragon);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dragon = _service.GetDragonById(id.Value);
            if (dragon == null)
            {
                return NotFound();
            }

            return View(dragon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteDragonById(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
