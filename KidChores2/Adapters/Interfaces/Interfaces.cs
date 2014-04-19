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
        //-----Kid Interfaces-----\\
        void AddKidViewModel(CreateKidViewModel model);
        EditKidViewModel GetEditKidViewModel(int id);
        void SaveKidViewModel(int id, EditKidViewModel model);
        void GetDeleteKidViewModel(int id);
        DetailsKidViewModel GetDetailsKidViewModel(int id);
        List<Room> GetRooms();
        
        

    }
}
