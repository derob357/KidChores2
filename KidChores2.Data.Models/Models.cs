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
  //public List<KidRoom> KidRooms { get; set; }//When we serialize with JSON you will have to remove this list
    }

    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
     //   public List<KidRoom> KidRooms { get; set; }//When we serialize with JSON you will have to remove this list
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
