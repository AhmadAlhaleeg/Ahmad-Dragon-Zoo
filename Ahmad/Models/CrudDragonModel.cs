using Microsoft.AspNetCore.Mvc;

namespace Ahmad.Models
{
    public class CrudDragonModel 
    {
        public Dragon Dragon { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
