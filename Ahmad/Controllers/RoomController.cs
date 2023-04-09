using Ahmad.Models;
using Ahmad.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ahmad.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomService _service;

        public RoomController(RoomService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var rooms = _service.GetAllRooms();
            return View(rooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _service.AddRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        public IActionResult Edit(int id)
        {
            var room = _service.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            var room = _service.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        [HttpPost]
        public IActionResult Delete(Room room)
        {
            _service.DeleteRoom(room.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
