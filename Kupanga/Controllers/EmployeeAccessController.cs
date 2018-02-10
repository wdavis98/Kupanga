﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kupanga.Models;
using Kupanga.Models.Repository;

namespace Kupanga.Controllers
{
    public class EmployeeAccessController : Controller
    {
        private KupangaEntities db = new KupangaEntities();

        // GET: EmployeeAccess
        public ActionResult Index()
        {
            EmployeeAccessViewModel viewModel = new EmployeeAccessViewModel();
            viewModel.SubmittedQuotes = db.SubmittedQuotes.ToList();
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
            return View("PartialViews/_QuoteDetails",quote);
        }

        // GET: EmployeeAccess/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeAccess/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAccess/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAccess/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeAccess/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAccess/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeAccess/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
