using Ahmad.Models;
using Microsoft.EntityFrameworkCore;

namespace Ahmad
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Dragon> Dragons { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
