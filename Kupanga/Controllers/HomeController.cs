using Kupanga.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kupanga.Models;
using System.Net;

namespace Kupanga.Controllers
{
    public class HomeController : Controller
    {
        private KupangaEntities db = new KupangaEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Confirm()
        {
            ViewBag.Message = "Your test choose page.";

            return View();
        }

        public ActionResult HomeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return PartialView("PartialViews/_HomeDetails", home);
        }

        public ActionResult OneStory()
        {
            HomesViewModel viewModel = new HomesViewModel();
            viewModel.Homes = (from home in db.Homes.ToList()
                               where home.CategoryId == 1
                               select home).ToList();

            return View(viewModel);
        }

        public ActionResult TwoStory()
        {
            HomesViewModel viewModel = new HomesViewModel();
            viewModel.Homes = (from home in db.Homes.ToList()
                               where home.CategoryId == 2
                               select home).ToList();

            return View(viewModel);
        }

        public ActionResult SingleFamily()
        {
            HomesViewModel viewModel = new HomesViewModel();
            viewModel.Homes = (from home in db.Homes.ToList()
                               where home.CategoryId == 3
                               select home).ToList();

            return View(viewModel);
        }

        public ActionResult RanchStyle()
        {
            HomesViewModel viewModel = new HomesViewModel();
            viewModel.Homes = (from home in db.Homes.ToList()
                               where home.CategoryId == 4
                               select home).ToList();

            return View(viewModel);
        }

        public ActionResult Doors()
        {
            List<Component> components = db.Components.ToList();
            ComponentsViewModel doors = new ComponentsViewModel();
            doors.components = (from door in components
                                where door.Category.CategoryName == "Door"
                                select door).ToList();
            return View(doors);
        }

        public ActionResult Windows()
        {
            List<Component> components = db.Components.ToList();
            ComponentsViewModel windows = new ComponentsViewModel();
            windows.components = (from door in components
                                  where door.Category.CategoryName == "Window"
                                  select door).ToList();

            return View(windows);
        }

        public ActionResult Roof()
        {
            List<Component> components = db.Components.ToList();
            ComponentsViewModel roofs = new ComponentsViewModel();
            roofs.components = (from door in components
                                where door.Category.CategoryName == "Roof"
                                select door).ToList();

            return View(roofs);
        }

        public ActionResult Flooring()
        {
            List<Component> components = db.Components.ToList();
            ComponentsViewModel floors = new ComponentsViewModel();
            floors.components = (from door in components
                                 where door.Category.CategoryName == "Floor"
                                 select door).ToList();

            return View(floors);
        }

        public ActionResult Feedback()
        {
            ViewBag.Message = "Your feedback page.";

            return View();
        }
    }
}