using KidChores2.Adapters.Adapters;
using KidChores2.Adapters.Interfaces;
using KidChores2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidChores2.Controllers
{
    public class RoomController : Controller
    {
        private IRoom _roomAdapter;
        public RoomController() { 
        _roomAdapter = new RoomAdapter();
        }
        // GET: Room
        public ActionResult Index()
        {
            CreateRoomViewModel model = new CreateRoomViewModel();
            model.Rooms = _roomAdapter.GetRooms();
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateRoom()
        {

            CreateRoomViewModel model = new CreateRoomViewModel();
            model.Kids = _roomAdapter.GetKids();
            model.Rooms = _roomAdapter.GetRooms();//for the modal that launches from the CreateRoom page
            return View(_roomAdapter.GetKids());
        }

        [HttpPost]
        public ActionResult CreateRoom(CreateRoomViewModel model)
        {
            _roomAdapter.AddRoomViewModel(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditRoom(int id)
        {
            EditRoomViewModel model = new EditRoomViewModel();
            model = _roomAdapter.GetEditRoomViewModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditRoom(int id, EditRoomViewModel model)
        {
            _roomAdapter.SaveRoomViewModel(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteRoom(int id)
        {
            _roomAdapter.GetDeleteRoomViewModel(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DetailRoom(int id)
        {
            DetailsRoomViewModel model = _roomAdapter.GetDetailsRoomViewModel(id);
            return View(model);
        }

        //[HttpGet]
        //public JsonResult EditRoom(int id)
        //{

        //    EditRoomViewModel model = new EditRoomViewModel();
        //    model = _roomAdapter.GetEditRoomViewModel(id);

        //    return Json(model.Room, JsonRequestBehavior.AllowGet);
        //}

    }
}