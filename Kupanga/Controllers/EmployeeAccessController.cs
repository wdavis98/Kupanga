using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kupanga.Models;
using Kupanga.Models.Repository;
using System.Drawing;
using System.IO;
using Kupanga.Helpers;
using Microsoft.AspNet.Identity;

namespace Kupanga.Controllers
{
    [Authorize]
    public class EmployeeAccessController : Controller
    {
        private KupangaEntities db = new KupangaEntities();

        // GET: EmployeeAccess
        public ActionResult Index()
        {
            EmployeeAccessViewModel viewModel = new EmployeeAccessViewModel();
            viewModel.SubmittedQuotes = db.SubmittedQuotes.ToList();
            viewModel.Components = db.Components.ToList();
            viewModel.Homes = db.Homes.ToList();
            return View(viewModel);
        }

        public ActionResult _UnhandledQuotes()
        {
            return View(db.SubmittedQuotes.ToList());
        }

        public ActionResult QuoteDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmittedQuote quote = db.SubmittedQuotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return PartialView("PartialViews/_QuoteDetails", quote);
        }
        [HttpGet]
        public ActionResult CreateHome()
        {
            ViewBag.CategoryId = new SelectList(db.HomeCategories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHome([Bind(Include = "HomeName, HomeDescription, BasePrice, CategoryId, NumberOfDoors, UnitsOfFlooring, UnitsOfRoofing, Windows")] Home home, HttpPostedFileBase image, HttpPostedFileBase blueprint)
        {
            try
            {
                if (image != null)
                {
                    MemoryStream target = new MemoryStream();
                    image.InputStream.CopyTo(target);
                    home.Image = target.ToArray();
                    ViewBag.spnHomeImageValidation = string.Empty;
                }
                else
                {
                    ViewBag.spnHomeImageValidation = "Image cannot be empty";
                }
                if (blueprint != null)
                {
                    MemoryStream target = new MemoryStream();
                    blueprint.InputStream.CopyTo(target);
                    home.Blueprint = target.ToArray();
                    ViewBag.spnHomeBlueprintValidation = string.Empty;
                }
                {
                    ViewBag.spnHomeBlueprintValidation = "Floor plan cannot be empty";
                }
            }
            catch (Exception)
            {
                Session["ErrorMessages"] = "Image(s) are not valid"; 
            }
            if (ModelState.IsValid)
            {
                db.Homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.CategoryId = new SelectList(db.HomeCategories, "CategoryId", "CategoryName");
            return View(home);
        }
        [HttpGet]
        public ActionResult EditHome(int? id)
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
            ViewBag.CategoryId = new SelectList(db.HomeCategories, "CategoryId", "CategoryName", home.CategoryId);


            return View(home);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHome([Bind(Include = "HomeName, HomeDescription, BasePrice, CategoryId, NumberOfDoors, UnitsOfFlooring, UnitsOfRoofing, Windows")] Home home, HttpPostedFileBase image, HttpPostedFileBase blueprint)
        {
            try
            {
                if (image != null)
                {
                    MemoryStream target = new MemoryStream();
                    image.InputStream.CopyTo(target);
                    home.Image = target.ToArray();
                    ViewBag.spnHomeImageValidation = string.Empty;
                }
                else
                {
                    ViewBag.spnHomeImageValidation = "Image cannot be empty";
                }
                if (blueprint != null)
                {
                    MemoryStream target = new MemoryStream();
                    blueprint.InputStream.CopyTo(target);
                    home.Blueprint = target.ToArray();
                    ViewBag.spnHomeBlueprintValidation = string.Empty;
                }
                {
                    ViewBag.spnHomeBlueprintValidation = "Floor plan cannot be empty";
                }
            }
            catch (Exception)
            {
                Session["ErrorMessages"] = "Image(s) are not valid";
            }
            if (ModelState.IsValid)
            {
                db.Entry(home).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            ViewBag.CategoryId = new SelectList(db.HomeCategories, "CategoryId", "CategoryName");
            return View(home);
        }
        [HttpGet]
        public ActionResult CreateComponent()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComponent([Bind(Include = "ComponentName, CategoryId, ComponentPrice")] Component component, HttpPostedFileBase image)
        {
            try
            {
                if (image != null)
                {
                    MemoryStream target = new MemoryStream();
                    image.InputStream.CopyTo(target);
                    component.Image = target.ToArray();
                    ViewBag.spnHomeImageValidation = string.Empty;
                }
                else
                {
                    ViewBag.spnHomeImageValidation = "Image cannot be empty";
                }
            }
            catch (Exception)
            {
                // Do nothing
            }
            if (ModelState.IsValid)
            {
                db.Components.Add(component);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View(component);
        }

        [HttpGet]

        public ActionResult EditComponent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", component.CategoryId);

            return View(component);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComponent([Bind(Include = "ComponentName, CategoryId, ComponentPrice")] Component component, HttpPostedFileBase image)
        {
            try
            {
                if (image != null)
                {
                    MemoryStream target = new MemoryStream();
                    image.InputStream.CopyTo(target);
                    component.Image = target.ToArray();
                    ViewBag.spnHomeImageValidation = string.Empty;
                }
                else
                {
                    ViewBag.spnHomeImageValidation = "Image cannot be empty";
                }
            }
            catch (Exception)
            {
                // Do nothing
            }
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View(component);
        }

        public ActionResult HandleQuote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmittedQuote quote = db.SubmittedQuotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            quote.HandledBy = User.Identity.GetUserId();
            quote.Status = 2;
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            return View("index");
        }

        public ActionResult ArchiveQuote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmittedQuote quote = db.SubmittedQuotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            quote.Status = 3;
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            return View("index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
