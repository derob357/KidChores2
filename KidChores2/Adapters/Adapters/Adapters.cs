using KidChores2.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KidChores2.Data;
using KidChores2.DataModels;
using KidChores2.Models;
using System.Data.Entity.Migrations;

namespace KidChores2.Adapters.Adapters
{
    public class HomeAdapter : IHome
    {
        public KidChore2Context db;
        public HomeAdapter()
        {
            db = new KidChore2Context();
        }

        public HomeViewModel GetHomeViewModel()
        {
            HomeViewModel model = new HomeViewModel();
            model.Kids = db.Kids.ToList();
            return model;
        }

        public void AddKidViewModel(CreateKidViewModel model)
        {
            Kid Kid = new Kid();
            Kid.FirstName = model.FirstName;
            Kid.LastName = model.LastName;
            db.Kids.Add(Kid);
            db.SaveChanges();
            KidRoom KR = new KidRoom() { KidId = Kid.Id, RoomId = model.RoomId };
            db.KidRooms.Add(KR);
            db.SaveChanges();
        }

        public EditKidViewModel GetEditKidViewModel(int id)
        {
            Kid Kid = db.Kids.Find(id);
            EditKidViewModel model = new EditKidViewModel();
            model.Kid = Kid;
            model.FirstName = Kid.FirstName;
            model.LastName = Kid.LastName;
            model.Rooms = db.Rooms.ToList();
            model.SelectedRooms = new List<Room>();
            model.KidRooms = db.KidRooms.Where(k => k.KidId == id).ToList();
            foreach (var room in model.KidRooms)
            {
                model.SelectedRooms.Add(room.Room);
            }
            return model;
        }

        public void SaveKidViewModel(int id, EditKidViewModel model)
        {
            Kid Kid = db.Kids.Find(id);
            Kid.FirstName = model.FirstName;
            Kid.LastName = model.LastName;
            model.SelectedRooms.Add(db.Rooms.Find(model.RoomId));
            foreach (var room in model.SelectedRooms)
            {
                db.KidRooms.AddOrUpdate(k => new { k.KidId, k.RoomId },
                    new KidRoom {KidId = id, RoomId = room.Id }
                    );
            }
            db.SaveChanges();
        }

        public void GetDeleteKidViewModel(int id)
        {
            Kid kid = db.Kids.Find(id);
            db.Kids.Remove(kid);
            db.SaveChanges();
        }

        public DetailsKidViewModel GetDetailsKidViewModel(int id)
        {
            DetailsKidViewModel model = new DetailsKidViewModel();
            Kid kid = db.Kids.Find(id);
            model.FirstName = kid.FirstName;
            model.LastName = kid.LastName;
            model.Rooms = new List<Room>();
            model.KidRooms = db.KidRooms.Where(k => k.KidId == id).ToList();
            foreach (var room in model.KidRooms)
            {
                model.Rooms.Add(room.Room);
            }
            return model;
        }
        //-----Room Adapters-----\\
        public DetailsRoomViewModel GetDetailsRoomViewModel(int id)
        {
            DetailsRoomViewModel model = new DetailsRoomViewModel();
            Room room = db.Rooms.Find(id);
            model.RoomName = room.RoomName;
            model.RoomId = room.Id;
            model.Kids = new List<Kid>();
            model.KidRooms = db.KidRooms.Where(k => k.RoomId == id).ToList();
            foreach (var kid in model.KidRooms)
            {
                model.Kids.Add(kid.Kid);
            }
            return model;
        }

        public void AddRoomViewModel(CreateRoomViewModel model)
        {
            Room Room = db.Rooms.Create();
            Room.RoomName = model.RoomName;
            db.Rooms.Add(Room);
            //Creating the relationship in the KidRoom table between the two
            //Tables.
            KidRoom kr = new KidRoom(){KidId = model.KidId, RoomId = Room.Id};
            db.KidRooms.Add(kr);
            db.SaveChanges();
        }

        public EditRoomViewModel GetEditRoomViewModel(int id)
        {
            Room Room = db.Rooms.Find(id);
            EditRoomViewModel model = new EditRoomViewModel();
            model.Room = Room;
            model.RoomName = Room.RoomName;
            model.Kids = db.Kids.ToList();
            model.SelectedKids = new List<Kid>(); //Create empty list of type Kid
            model.KidRooms = db.KidRooms.Where(k => k.RoomId == id).ToList(); 
            foreach (var kid in model.KidRooms)
            {
                model.SelectedKids.Add(kid.Kid);
            }
            return model;
        }

        public List<Kid> GetKids()
        {
            return db.Kids.ToList();
        }

        public List<Room> GetRooms()
        {
            return db.Rooms.ToList();
        }

        public void SaveRoomViewModel(int id, EditRoomViewModel model)
        {
            Room Room = db.Rooms.Find(id);
            Room.RoomName = model.RoomName;
            model.SelectedKids.Add(db.Kids.Find(model.KidId));
            foreach (var kid in model.SelectedKids)
            {
                db.KidRooms.AddOrUpdate(k => new { k.KidId, k.RoomId },
                    new KidRoom { KidId = kid.Id, RoomId = id }
                    );
            }
            db.SaveChanges();
        }

        public void GetDeleteRoomViewModel(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
        }
    }

}