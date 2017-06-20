using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeltaImpuls2.DAL;
using DeltaImpuls2.Models;

namespace DeltaImpuls2.Controllers
{
    /// <summary>
    /// This controller handles the locations for this application
    /// </summary>
    [Authorize]
    public class locationsController : Controller
    {
        private DeltaImpulsContext db = new DeltaImpulsContext();

        /// <summary>
        /// Returns the view with the wished locations 
        /// </summary>
        /// <returns></returns>
        // GET: locations
        public ActionResult Index()
        {
            return View(db.locations.ToList());
        }

        /// <summary>
        /// Returns the view for creating a location
        /// </summary>
        /// <returns></returns>
        // GET: locations/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// creates and saves the location in the database
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        // POST: locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,city,postcode,adres,housenumber,suffix")] location location)
        {
            if (ModelState.IsValid)
            {
                db.locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        /// <summary>
        /// Returns the view for editing a location
        /// </summary>
        /// <param name="id">ID of the location that is going to be edited</param>
        /// <returns></returns>
        // GET: locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        /// <summary>
        /// Saves the edited location in the database
        /// </summary>
        /// <param name="location">Edited location</param>
        /// <returns></returns>
        // POST: locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,city,postcode,adres,housenumber,suffix")] location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        /// <summary>
        /// Gets the location that is going to be deleted
        /// </summary>
        /// <param name="id">ID of the location that is going to be deleted</param>
        /// <returns></returns>
        // GET: locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            location location = db.locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        /// <summary>
        /// Confirms that the location is deleted and deletes it from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            location location = db.locations.Find(id);
            if (db.members.All(m => m.locationID != id))
            {
                db.locations.Remove(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Het is niet mogelijk om een locatie te verwijderen als er nog een lid aan gekoppeld is!");
            return View(location);
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
