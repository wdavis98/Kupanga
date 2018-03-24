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

        public ActionResult CreateHome()
        {
            //ViewBag.SongbookId = new SelectList(db.Songbooks, "SongbookId", "SongbookName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHome([Bind(Include = "HomeName, HomeDescription, BasePrice")] Home home, HttpPostedFileBase image, HttpPostedFileBase blueprint)
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
                // Do nothing
            }
            if (ModelState.IsValid)
            {
                db.Homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(home);
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
