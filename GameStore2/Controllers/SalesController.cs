﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameStore2.Models;
using Microsoft.AspNet.Identity;

namespace GameStore2.Controllers
{
    [RequireHttps]
    [Authorize]
    [HandleError]
    public class SalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Game).Include(s => s.Quality).Include(s => s.User);
            return View(sales.ToList());
        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Include(s => s.Game).Include(s => s.Quality).Include(s => s.User).SingleOrDefault(x => x.Id == id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {

            ViewBag.GameId = new SelectList(db.Games, "Id", "Title");
            ViewBag.QualityID = new SelectList(db.Qualities, "Id", "Type");
            
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameId,Quantity,QualityID,price,Userid")] Sale sale)
        {
            sale.Userid = User.Identity.GetUserId();
            
            {

            }
            try
            {
                if (ModelState.IsValid)
                {

                    db.Sales.Add(sale);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

                ViewBag.GameId = new SelectList(db.Games, "Id", "Title", sale.GameId);
                ViewBag.QualityID = new SelectList(db.Qualities, "Id", "Type", sale.QualityID);

                return View(sale);
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Title", sale.GameId);
            ViewBag.QualityID = new SelectList(db.Qualities, "Id", "Type", sale.QualityID);

            return View(sale);
        }
           
        

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sale sale = db.Sales.Include(s => s.Game).Include(s => s.Quality).Include(s => s.User).SingleOrDefault(x => x.Id == id);
            var loggedInUser = User.Identity.GetUserId();
            if (sale.Userid != loggedInUser)
            {
                return RedirectToAction("Index");
            }
            ViewBag.userid = User.Identity.GetUserId();
            if (sale == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.GameId = new SelectList(db.Games, "Id", "Title", sale.GameId);
            ViewBag.QualityID = new SelectList(db.Qualities, "Id", "Type", sale.QualityID);
          
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameId,Quantity,QualityID,price,Userid")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Title", sale.GameId);
            ViewBag.QualityID = new SelectList(db.Qualities, "Id", "Type", sale.QualityID);
            
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sale sale = db.Sales.Include(s => s.Game).Include(s => s.Quality).Include(s => s.User).SingleOrDefault(x => x.Id == id);

            ViewBag.userid = User.Identity.GetUserId();
            var loggedInUser = User.Identity.GetUserId();
            if (sale.Userid != loggedInUser)
            {
                return RedirectToAction("Index");
            }

            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Title", sale.GameId);
            ViewBag.QualityID = new SelectList(db.Qualities, "Id", "Type", sale.QualityID);
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
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
