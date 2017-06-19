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
    /// This controller handles the junior licenses of this application
    /// </summary>
    [Authorize]
    public class ljsController : Controller
    {
        private DeltaImpulsContext db = new DeltaImpulsContext();

        /// <summary>
        /// Returns the view with the wished junior licenses
        /// </summary>
        /// <returns></returns>
        // GET: ljs
        public ActionResult Index()
        {
            return View(db.lj.ToList());
        }

        /// <summary>
        /// Returns the view for creating a junior licens
        /// </summary>
        /// <returns></returns>
        // GET: ljs/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates and saves the junior license in the database
        /// </summary>
        /// <param name="lj">Junior license that is created</param>
        /// <returns></returns>
        // POST: ljs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,license")] lj lj)
        {
            if (ModelState.IsValid)
            {
                db.lj.Add(lj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lj);
        }

        /// <summary>
        /// Returns the view for editing a junior licens
        /// </summary>
        /// <param name="id">ID of the junior license that is going to edited</param>
        /// <returns></returns>
        // GET: ljs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lj lj = db.lj.Find(id);
            if (lj == null)
            {
                return HttpNotFound();
            }
            return View(lj);
        }

        /// <summary>
        /// Saves the edited junior license in the database
        /// </summary>
        /// <param name="lj">Junior license that is edited</param>
        /// <returns></returns>
        // POST: ljs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,license")] lj lj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lj);
        }

        /// <summary>
        /// Gets the junior license that is going to be deleted
        /// </summary>
        /// <param name="id">ID of the selected junior license</param>
        /// <returns></returns>
        // GET: ljs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lj lj = db.lj.Find(id);
            if (lj == null)
            {
                return HttpNotFound();
            }
            return View(lj);
        }

        /// <summary>
        /// Confirms that the junior license is deleted and deletes it from the database
        /// </summary>
        /// <param name="id">ID of the selected junior license</param>
        /// <returns></returns>
        // POST: ljs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lj lj = db.lj.Find(id);
            if (db.members.All(m => m.ljID != id))
            {
                db.lj.Remove(lj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Het is niet mogelijk om een licentie te verwijderen als er nog een lid aan gekoppeld is!");
            return View(lj);
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
