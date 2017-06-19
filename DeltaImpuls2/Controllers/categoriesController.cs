using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DeltaImpuls2.DAL;
using DeltaImpuls2.Models;

namespace DeltaImpuls2.Controllers
{
    /// <summary>
    /// This controller handles the categories for this application
    /// </summary>
    [Authorize]
    public class categoriesController : Controller
    {
        private DeltaImpulsContext db = new DeltaImpulsContext();
        /// <summary>
        /// Returns the view with the wished categories 
        /// </summary>
        /// <returns></returns>
        // GET: categories
        public ActionResult Index()
        {
            return View(db.categorie.ToList());
        }

        /// <summary>
        /// Returns the view for creating a categorie
        /// </summary>
        /// <returns></returns>
        // GET: categories/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// creates and saves the categorie in the database
        /// </summary>
        /// <param name="categorie">is the created categorie</param>
        /// <returns></returns>
        // POST: categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,age")] categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.categorie.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorie);
        }

        /// <summary>
        /// Returns the view for editing a categorie
        /// </summary>
        /// <param name="id">ID of the categorie that is going to be edited</param>
        /// <returns></returns>
        // GET: categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorie categorie = db.categorie.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        /// <summary>
        /// Saves the edited categorie in the database
        /// </summary>
        /// <param name="categorie">Edited categorie</param>
        /// <returns></returns>
        // POST: categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,age")] categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        /// <summary>
        /// Gets the categorie that is going to be deleted
        /// </summary>
        /// <param name="id">ID of the categorie that is going to be deleted</param>
        /// <returns></returns>
        // GET: categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categorie categorie = db.categorie.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }


        /// <summary>
        /// Confirms that the categorie is deleted and deletes it from the database
        /// </summary>
        /// <param name="id">ID of the selected categorie</param>
        /// <returns></returns>
        // POST: categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categorie categorie = db.categorie.Find(id);
            if (db.members.All(m => m.categorieID != id))
            {
                categorie = db.categorie.Find(id);
                db.categorie.Remove(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Het is niet mogelijk om een categorie te verwijderen als er nog een lid aan gekoppeld is!");
            return View(categorie);
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
