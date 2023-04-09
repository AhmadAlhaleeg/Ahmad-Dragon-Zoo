using Ahmad.Models;

namespace Ahmad.Services
{
    public class RoomService
    {
        private readonly DBContext _dbContext;

        public RoomService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Room> GetAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }

        public void AddRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
        }

        public Room GetRoomById(int id)
        {
            return _dbContext.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateRoom(Room room)
        {
            _dbContext.Rooms.Update(room);
            _dbContext.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var roomToDelete = GetRoomById(id);
            if (roomToDelete != null)
            {
                _dbContext.Rooms.Remove(roomToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
