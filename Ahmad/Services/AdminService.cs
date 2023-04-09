using Ahmad.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace Ahmad.Services
{
    public class AdminService
    {
        private readonly DBContext _dbContext;



        public AdminService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public AdminService(DBContext context) {
        //    _context = context;
        //}

        //public void Add(Dragon dragon)
        //{
        //    _context.Add(dragon);
        //    _context.SaveChanges();
        //}
        public List<Dragon> Load()
        {
            var dragonList = _dbContext.Dragons.ToList();
            return dragonList;
        }

        //internal void Update(Dragon item)
        //{
        //    var refData = _context.Dragons.Local.FirstOrDefault(d => d.Id == item.Id);

        //    if (refData == null)
        //    {
        //        refData = _context.Dragons.First(e => e.Id == item.Id);
        //    }

        //    refData.Name = item.Name;
        //    refData.RoomId = item.RoomId;

        //    _context.SaveChanges();
        //    _context.Entry(refData).State = EntityState.Detached;
        //}

        internal string GetRoomName(int dragonId)
        {
            var dragon = _dbContext.Dragons.FirstOrDefault(e => e.Id == dragonId);

            if (dragon == null)
                return string.Empty;

            var room = _dbContext.Rooms.FirstOrDefault(e => e.Id == dragon.RoomId);
            if (room == null)
                return string.Empty;
            return room.Name;
        }


        

        public List<Dragon> GetAllDragons()
        {
            return _dbContext.Dragons.ToList();
        }

        public Dragon GetDragonById(int id)
        {
            return _dbContext.Dragons.FirstOrDefault(d => d.Id == id);
        }

        public void AddDragon(Dragon dragon)
        {
            _dbContext.Dragons.Add(dragon);
            _dbContext.SaveChanges();
        }

        public void UpdateDragon(Dragon dragon)
        {
            _dbContext.Dragons.Update(dragon);
            _dbContext.SaveChanges();
        }

        public void DeleteDragonById(int id)
        {
            var dragon = GetDragonById(id);
            if (dragon != null)
            {
                _dbContext.Dragons.Remove(dragon);
                _dbContext.SaveChanges();
            }
        }
    }
}
