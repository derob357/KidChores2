using KidChores2.DataModels;
using KidChores2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidChores2.Adapters.Interfaces
{
    public interface IHome
    {
        HomeViewModel GetHomeViewModel();
        void AddKidViewModel(CreateKidViewModel model);
        EditKidViewModel GetEditKidViewModel(int id);
        void SaveKidViewModel(int id, EditKidViewModel model);
        void GetDeleteKidViewModel(int id);
        DetailsKidViewModel GetDetailsKidViewModel(int id);
        List<Room> GetRooms();
    
        void AddRoomViewModel(CreateRoomViewModel model);
        EditRoomViewModel GetEditRoomViewModel(int id);
        List<Kid> GetKids();
        void SaveRoomViewModel(int id, EditRoomViewModel model);
        void GetDeleteRoomViewModel(int id);
        DetailsRoomViewModel GetDetailsRoomViewModel(int id);
    }
}
