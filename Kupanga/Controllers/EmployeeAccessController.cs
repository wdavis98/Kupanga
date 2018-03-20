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
            return PartialView("PartialViews/_QuoteDetails",quote);
        }

        public ActionResult CreateHome()
        {
            //ViewBag.SongbookId = new SelectList(db.Songbooks, "SongbookId", "SongbookName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHome([Bind(Include = "HomeName, HomeDescription, BasePrice")] Home home)
        {
            if (ModelState.IsValid)
            {
                db.Homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("CreateHomeImage?homeId=" + home.HomeId);
            }

            //ViewBag.SongbookId = new SelectList(db.Songbooks, "SongbookId", "SongbookName", song.SongbookId);
            return View(home);
        }

        //public ActionResult CreateHomeImage()
        //{
        //    ViewBag.ImageTypeId = new SelectList(db.ImageTypes, "ImageTypeId", "ImageTypeName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateHomeImage([Bind(Include = "ImageTypeId")] HomeImage homeImage, HttpPostedFileBase file, string homeId, string Submit)
        //{
        //    try
        //    {
        //        //string path = Path.Combine(Server.MapPath("~/Images"),
        //                                   //Path.GetFileName(file.FileName));
        //        if(file != null)
        //        {
        //            MemoryStream target = new MemoryStream();
        //            file.InputStream.CopyTo(target);
        //            homeImage.Image = target.ToArray();
        //            //using (StreamReader reader = new StreamReader(file.InputStream))
        //            //{
        //            //    homeImage.Image = reader.read
        //            //}

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // Do nothing
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        int dummy;
        //        int.TryParse(homeId, out dummy);
        //        homeImage.HomeId = dummy;
        //        db.HomeImages.Add(homeImage);
        //        db.SaveChanges();
        //        if (Submit == "Create")
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return RedirectToAction("CreateHomeImage?homeId=" + homeId);
        //        }
        //    }

            //ViewBag.SongbookId = new SelectList(db.Songbooks, "SongbookId", "SongbookName", song.SongbookId);
            //return View(homeImage);
        //}

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
