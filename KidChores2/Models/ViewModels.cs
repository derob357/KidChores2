using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KidChores2.DataModels;
namespace KidChores2.Models
{
    public class HomeViewModel
    {
        public List<Kid> Kids { get; set; }
    }
    //---Kid View Models---\\
    public class CreateKidViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Room> Rooms { get; set; }
        public int RoomId { get; set; }
        public List<KidRoom> KidRooms { get; set; }
    }

    public class EditKidViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int RoomId { get; set; }
        public Kid Kid { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Room> SelectedRooms { get; set; }
        public List<KidRoom> KidRooms { get; set; }
    }

    public class DeleteKidViewModel
    {
        public int KidId { get; set; }
    }

    public class DetailsKidViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Room> Rooms { get; set; }
        public List<KidRoom> KidRooms { get; set; }
    }

    //---Room View Models---\\

    public class CreateRoomViewModel
    {
        public string RoomName { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Kid> Kids { get; set; }
        public int KidId { get; set; }
        public List<KidRoom> KidRooms { get; set; }
    }
    public class DetailsRoomViewModel
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public List<Kid> Kids { get; set; }
        public List<KidRoom> KidRooms { get; set; }
    }
    public class EditRoomViewModel
    {
        public Room Room { get; set; }
        public string RoomName { get; set; }
        public List<KidRoom> KidRooms { get; set; }
        public int KidId { get; set; }
        public List<Kid> Kids { get; set; }
        public List<Kid> SelectedKids { get; set; }

    }

}