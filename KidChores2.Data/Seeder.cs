using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using KidChores2.DataModels;

namespace KidChores2.Data
{
    public static class Seeder
    {
        public static void Seed(KidChore2Context db)
        {
            CreateKids(db);
            db.SaveChanges();
            CreateRooms(db);
            db.SaveChanges();
            CreateKidRoom(db);
            db.SaveChanges();
        }

        public static void CreateKids(KidChore2Context db)
        {
            db.Kids.AddOrUpdate(k => new { k.FirstName, k.LastName },
                new Kid { FirstName = "Tyrone", LastName = "Cannon" },
                new Kid { FirstName = "Shaniqua", LastName = "Cannon" },
                new Kid { FirstName = "Johnny", LastName = "Cannon" },
                new Kid { FirstName = "Chad", LastName = "Cannon" },
                new Kid { FirstName = "TomMacklemoreSlimShady", LastName = "Cannon" },
                new Kid { FirstName = "David", LastName = "Cannon" },
                new Kid { FirstName = "KanyeWest", LastName = "Cannon" }
                );
        }

        public static void CreateRooms(KidChore2Context db)
        {
            db.Rooms.AddOrUpdate(r => new { r.RoomName },
                new Room { RoomName = "Living Room" },
                new Room { RoomName = "Kitchen" },
                new Room { RoomName = "Bathroom" },
                new Room { RoomName = "Master Bathroom" },
                new Room { RoomName = "Game Room" },
                new Room { RoomName = "Front Room" }
                );
        }

        public static void CreateKidRoom(KidChore2Context db)
        {
            db.KidRooms.AddOrUpdate(k => new { k.KidId, k.RoomId },
                new KidRoom { KidId = 1, RoomId = 1 },
                new KidRoom { KidId = 2, RoomId = 2 },
                new KidRoom { KidId = 3, RoomId = 3 },
                new KidRoom { KidId = 4, RoomId = 4 },
                new KidRoom { KidId = 5, RoomId = 5 },
                new KidRoom { KidId = 6, RoomId = 6 },
                new KidRoom { KidId = 6, RoomId = 1 },
                new KidRoom { KidId = 5, RoomId = 2 },
                new KidRoom { KidId = 4, RoomId = 3 },
                new KidRoom { KidId = 3, RoomId = 4 },
                new KidRoom { KidId = 2, RoomId = 5 },
                new KidRoom { KidId = 1, RoomId = 6 }
                );
        }
    }
}
