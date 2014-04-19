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
            model.Rooms = db.Rooms.ToList();//a list of all rooms

            //instantiates a list, that is empty at this point
            model.SelectedRooms = new List<Room>();

            //queries the KidRooms table to retrieve the related rows
            //that contain the Room id passed in (a list of the kids in that room is located there
            model.KidRooms = db.KidRooms.Where(k => k.KidId == id).ToList();
            //loops through KidRooms adds the Room to the SelectedRooms List
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
        public List<Kid> GetKids()
        {
            return db.Kids.ToList();
        }

        public List<Room> GetRooms()
        {
            return db.Rooms.ToList();
        }
      
    }

}