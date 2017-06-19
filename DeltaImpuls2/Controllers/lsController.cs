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
    /// This controller handles the senior licenses of this application
    /// </summary>
    [Authorize]
    public class lsController : Controller
    {
        private DeltaImpulsContext db = new DeltaImpulsContext();

        /// <summary>
        /// Returns the view with the wished senior licenses
        /// </summary>
        /// <returns></returns>
        // GET: ls
        public ActionResult Index()
        {
            return View(db.ls.ToList());
        }

        /// <summary>
        /// Returns the view for creating a senior licens
        /// </summary>
        /// <returns></returns>
        // GET: ls/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates and saves the senior license in the database
        /// </summary>
        /// <param name="ls">Senior license thas is created</param>
        /// <returns></returns>
        // POST: ls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,license")] ls ls)
        {
            if (ModelState.IsValid)
            {
                db.ls.Add(ls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ls);
        }

        /// <summary>
        /// Returns the view for editing a senior licens
        /// </summary>
        /// <param name="id">ID of the senior license that is going to edited</param>
        /// <returns></returns>
        // GET: ls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ls ls = db.ls.Find(id);
            if (ls == null)
            {
                return HttpNotFound();
            }
            return View(ls);
        }

        /// <summary>
        /// Saves the edited senior license in the database
        /// </summary>
        /// <param name="ls">Senior lincse that is edited</param>
        /// <returns></returns>
        // POST: ls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,license")] ls ls)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ls);
        }

        /// <summary>
        /// Gets the senior license that is going to be deleted
        /// </summary>
        /// <param name="id">ID of the selected senior license</param>
        /// <returns></returns>
        // GET: ls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ls ls = db.ls.Find(id);
            if (ls == null)
            {
                return HttpNotFound();
            }
            return View(ls);
        }

        /// <summary>
        /// Confirms that the senior license is deleted and deletes it from the database
        /// </summary>
        /// <param name="id">ID of the selected senior license</param>
        /// <returns></returns>
        // POST: ls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ls ls = db.ls.Find(id);
            if (db.members.All(m => m.lsID != id))
            {
                db.ls.Remove(ls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Het is niet mogelijk om een licentie te verwijderen als er nog een lid aan gekoppeld is!");
            return View(ls);
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
