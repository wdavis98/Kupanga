using Kupanga.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kupanga.Models;
using System.Net;
using Kupanga.Helpers;

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
            ViewBag.Message = "About Page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
        //This is the page that will submit the quote. You can see the quote via the employee access screen
        [HttpGet]
        public ActionResult Confirm()
        {
            object currentQutoe = Session["CurrentQuote"];
            string destination = Helpers.NavigationHelper.ValidateSessionQuote("confirm", currentQutoe);
            if (destination.ToUpper() != "CONFIRM")
            {
                Session["ErrorMessages"] = "Please Select a product";
                return RedirectToAction(destination);
            }
            return View("Confirm");
        }
        [HttpPost]
        public ActionResult Confirm([Bind(Include = "ContactFirstName, ContactLastName, ContactPhoneNumber, ContactEmail, ContactStreetAddress, ContactCity, ContactState, ContactZip")] SubmittedQuote quote)
        {
            try
            {
                SubmittedQuote sessionQuote = ((SubmittedQuote)Session["CurrentQuote"]);
                quote.HomeId = sessionQuote.HomeId;
                quote.DoorId = sessionQuote.DoorId;
                quote.FloorId = sessionQuote.FloorId;
                quote.RoofId = sessionQuote.RoofId;
                quote.WindowId = sessionQuote.WindowId;

                quote.Status = 1;
                if (ModelState.IsValid)
                {
                    db.SubmittedQuotes.Add(quote);
                    db.SaveChanges();
                    return RedirectToAction("thankyou");
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Confirm");
            }
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

        public ActionResult SaveSelectedHouse(int? homeId)
        {
            SubmittedQuote newQuote = new SubmittedQuote();
            Session["CurrentQuote"] = newQuote;
            try
            {
                ((SubmittedQuote)Session["CurrentQuote"]).HomeId = (int)homeId;
                ((SubmittedQuote)Session["CurrentQuote"]).Home = db.Homes.Find((int)homeId);
            }
            catch (Exception)
            {
                return RedirectToAction("OneStory");
            }

            return RedirectToAction("Doors");
        }


        [HttpGet]
        public ActionResult Doors()
        {
            if(Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            List<Component> components = db.Components.ToList();
            ComponentsViewModel doors = new ComponentsViewModel();
            doors.components = (from door in components
                                where door.Category.CategoryName == "Door"
                                select door).ToList();
            return View(doors);
        }
        [HttpPost]
        public ActionResult Doors(int? doorId)
        {
            if (Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            try
            {
                ((SubmittedQuote)Session["CurrentQuote"]).DoorId = doorId;
                ((SubmittedQuote)Session["CurrentQuote"]).Component = db.Components.Find(doorId);
            }
            catch (Exception)
            {
                return RedirectToAction("OneStory");
            }
            return RedirectToAction("Windows");
        }
        [HttpGet]
        public ActionResult Windows()
        {
            if (Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            List<Component> components = db.Components.ToList();
            ComponentsViewModel windows = new ComponentsViewModel();
            windows.components = (from door in components
                                  where door.Category.CategoryName == "Window"
                                  select door).ToList();

            return View(windows);
        }
        [HttpPost]
        public ActionResult Windows(int? windowId)
        {
            if (Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            try
            {
                ((SubmittedQuote)Session["CurrentQuote"]).WindowId = windowId;
                ((SubmittedQuote)Session["CurrentQuote"]).Component1 = db.Components.Find(windowId);
            }
            catch (Exception)
            {
                return RedirectToAction("OneStory");
            }
            return RedirectToAction("Roof");
        }
        [HttpGet]
        public ActionResult Roof()
        {
            if (Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            List<Component> components = db.Components.ToList();
            ComponentsViewModel roofs = new ComponentsViewModel();
            roofs.components = (from door in components
                                where door.Category.CategoryName == "Roof"
                                select door).ToList();

            return View(roofs);
        }
        [HttpPost]
        public ActionResult Roof(int? roofId)
        {
            if (Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            try
            {
                ((SubmittedQuote)Session["CurrentQuote"]).RoofId = roofId;
                ((SubmittedQuote)Session["CurrentQuote"]).Component3 = db.Components.Find(roofId);
            }
            catch (Exception)
            {
                return RedirectToAction("OneStory");
            }
            return RedirectToAction("Flooring");
        }
        [HttpGet]
        public ActionResult Flooring()
        {
            if (Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            List<Component> components = db.Components.ToList();
            ComponentsViewModel floors = new ComponentsViewModel();
            floors.components = (from door in components
                                 where door.Category.CategoryName == "Floor"
                                 select door).ToList();

            return View(floors);
        }
        [HttpPost]
        public ActionResult Flooring(int? floorId)
        {
            if (Session["CurrentQuote"] == null)
            {
                return RedirectToAction("OneStory");
            }
            try
            {
                ((SubmittedQuote)Session["CurrentQuote"]).FloorId = floorId;
                ((SubmittedQuote)Session["CurrentQuote"]).Component2 = db.Components.Find(floorId);
            }
            catch (Exception)
            {
                return RedirectToAction("OneStory");
            }
            return RedirectToAction("Confirm");
        }

        public ActionResult Feedback()
        {
            ViewBag.Message = "Your feedback page.";

            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}