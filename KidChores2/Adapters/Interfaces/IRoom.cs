using KidChores2.DataModels;
using KidChores2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KidChores2.Adapters.Interfaces
{
    public interface IRoom
    {
        //-----Room Interfaces-----\\
        // Grab the CreateRoomViewModel for HttpPOST
        void AddRoomViewModel(CreateRoomViewModel model);

        // Grab the Edit Room 
        EditRoomViewModel GetEditRoomViewModel(int id);

        // List of all Kids. Used in HttpGET portion of CreateRoom
        List<Kid> GetKids();
        List<Room> GetRooms();

        // Save the edits
        void SaveRoomViewModel(int id, EditRoomViewModel model);

        // Delete the selected room
        void GetDeleteRoomViewModel(int id);

        // Show room details
        DetailsRoomViewModel GetDetailsRoomViewModel(int id);
    }
}
