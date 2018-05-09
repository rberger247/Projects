using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NLog;
using resterauntWeb.Models;

namespace RestaurantsWeb.Controllers
{
    public class RestaurantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Restaurants
        public ActionResult Index()
        {


            return View(db.Resteraunt.ToList());
        }

        public ActionResult Inde(string option, string search)
        {


            if (option == "Name")
            {
                var results = db.Resteraunt.Where(x => x.Name.StartsWith(search) || search == null).ToList();

                if (results.Count() < 1)
                {


                    return View();
                }
                return View(db.Resteraunt.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
            else if (option == "City")
            {
                return View(db.Resteraunt.Where(x => x.City.StartsWith(search) || search == null).ToList());
            }
            else if (option == "Rating")
            {
                return View(db.Resteraunt.Where(x => x.City.StartsWith(search) || search == null).OrderByDescending(x => x.AvgRating).ToList());
            }
            else if (option == "Sort by Descending")
            {
                return View(db.Resteraunt.Where(x => x.City.StartsWith(search) || search == null).OrderByDescending(x => x.Name).ToList());
            }
            else
            {

                return View(db.Resteraunt.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }

        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Resteraunt.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Street1,City,State,Country,phone,Zipcode,AvgRating,Created,Modified")] Restaurant restaurant)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Resteraunt.Add(restaurant);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetLogger("databaseLogger");

                // add custom message and pass in the exception
                logger.Error(ex, "Whoops!");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            Restaurant restaurant = new Restaurant();
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    restaurant = db.Resteraunt.Find(id);
                    if (restaurant == null)
                    {
                        return HttpNotFound();
                    }

                }

            }
            catch(Exception ex)
            {
                Logger logger = LogManager.GetLogger("databaseLogger");

                // add custom message and pass in the exception
                logger.Error(ex, "Whoops!");
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Street1,City,State,Country,phone,Zipcode,AvgRating,Created,Modified")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Resteraunt.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Resteraunt.Find(id);
            db.Resteraunt.Remove(restaurant);
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
