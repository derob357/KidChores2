using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidChores2.DataModels
{
    public class Kid
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<KidRoom> KidRooms { get; set; }
    }

    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public List<KidRoom> KidRooms { get; set; }
    }

    public class KidRoom
    {
        public int Id { get; set; }
        public int KidId { get; set; }
        public virtual Kid Kid { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
