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
    public class RoomAdapter : IRoom
    {
        public KidChore2Context db;
        public RoomAdapter()
        {
            db = new KidChore2Context();
        }

        public void AddRoomViewModel(CreateRoomViewModel model)
        {
            Room Room = db.Rooms.Create();
            Room.RoomName = model.RoomName;
            db.Rooms.Add(Room);
            //Creating the relationship in the KidRoom table between the two
            //Tables.
            KidRoom kr = new KidRoom() { KidId = model.KidId, RoomId = Room.Id };
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
        public List<Room> GetRooms()
        {
            return db.Rooms.ToList();
        }
        public List<DataModels.Kid> GetKids()
        {
            return db.Kids.ToList();
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
    }
}
