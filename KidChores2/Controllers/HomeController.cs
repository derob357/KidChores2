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
    public class HomeController : Controller
    {
        private IHome _homeAdapter;
        public HomeController()
        {
            _homeAdapter = new HomeAdapter();
        }

        public ActionResult Index()
        {
            HomeViewModel model = _homeAdapter.GetHomeViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateKid()
        {
            CreateKidViewModel model = new CreateKidViewModel();
            model.Rooms = _homeAdapter.GetRooms();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateKid(CreateKidViewModel model)
        {
            _homeAdapter.AddKidViewModel(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditKid(int id)
        {
            EditKidViewModel model = new EditKidViewModel();
            model = _homeAdapter.GetEditKidViewModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditKid(int id, EditKidViewModel model)
        {
            _homeAdapter.SaveKidViewModel(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteKid(int id)
        {
            _homeAdapter.GetDeleteKidViewModel(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DetailKid(int id)
        {
            DetailsKidViewModel model = _homeAdapter.GetDetailsKidViewModel(id);
            return View(model);
        }


    }
}