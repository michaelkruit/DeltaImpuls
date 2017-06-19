using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeltaImpuls2.DAL;
using DeltaImpuls2.Models;
using PagedList;

namespace DeltaImpuls2.Controllers
{
    /// <summary>
    /// This controller handles the members of this application, the index is also the main page of this application
    /// </summary>
    [Authorize]
    public class membersController : Controller
    {
        private DeltaImpulsContext db = new DeltaImpulsContext();

        /// <summary>
        /// Returns the view with the wished members
        /// </summary>
        /// <param name="searchString">String for searching a member</param>
        /// <param name="locationFilter">Int for filtering on location</param>
        /// <param name="categorieFilter">Int for filtering on categorie</param>
        /// <param name="page">Int for knowing on wich page of the pagintion the user is on</param>
        /// <returns></returns>
        // GET: members
        public ActionResult Index(string searchString, int? locationFilter, int? categorieFilter, int? page)
        {
            var members = db.members.Include(m => m.categorie).Include(m => m.lj).Include(m => m.location).Include(m => m.ls);

            var seniorAmount = members.Where(m => m.categorie.age > 17).Count();
            var juniorAmount = members.Where(m => m.categorie.age < 18).Count();

            ViewBag.SearchValue = searchString;
            ViewBag.CurrentLocation = locationFilter;
            ViewBag.CurrentCategorie = categorieFilter;
            ViewBag.SeniorAmount = seniorAmount;
            ViewBag.JuniorAmount = juniorAmount;
            ViewBag.location_ID = new SelectList(db.locations, "ID", "city");
            ViewBag.categorie_id = new SelectList(db.categorie, "ID", "name");

            if (locationFilter.HasValue)
            {
                members = members.Where(m => m.locationID == locationFilter);
                seniorAmount = members.Where(m => m.categorie.age > 17).Where(m => m.locationID == locationFilter).Count();
                ViewBag.SeniorAmount = seniorAmount;

                juniorAmount = members.Where(m => m.categorie.age < 18).Where(m => m.locationID == locationFilter).Count();
                ViewBag.JuniorAmount = juniorAmount;
            }

            if (categorieFilter != null)
            {
                members = members.Where(m => m.categorieID == categorieFilter);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(m =>
                m.firstname.Contains(searchString)
                || m.lastname.Contains(searchString)
                );
            }

            if (searchString != null)
            {
                page = 1;
            }

            int pageSize = 10;
            int pageNumber = page ?? 1;

            return View(members.OrderBy(m => m.firstname).ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Returns the view for creating a member
        /// </summary>
        /// <returns></returns>
        // GET: members/Create
        public ActionResult Create()
        {
            ViewBag.categorieID = new SelectList(db.categorie, "ID", "name");
            ViewBag.ljID = new SelectList(db.lj, "ID", "license");
            ViewBag.locationID = new SelectList(db.locations, "ID", "city");
            ViewBag.lsID = new SelectList(db.ls, "ID", "license");
            return View();
        }

        /// <summary>
        /// Creates and saves a member in the database
        /// </summary>
        /// <param name="members">Member that is created</param>
        /// <returns></returns>
        // POST: members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstname,lastname,insertion,bondsnr,cg,paratt,dateborn,gender,membersince,adres,postcode,city,phonennumber,mobilenumber,email,categorieID,locationID,ljID,lsID,housenumber,suffix")] members members)
        {
            if (ModelState.IsValid)
            {
                db.members.Add(members);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categorieID = new SelectList(db.categorie, "ID", "name", members.categorieID);
            ViewBag.ljID = new SelectList(db.lj, "ID", "license", members.ljID);
            ViewBag.locationID = new SelectList(db.locations, "ID", "city", members.locationID);
            ViewBag.lsID = new SelectList(db.ls, "ID", "license", members.lsID);
            return View(members);
        }

        /// <summary>
        /// Returns the view for editing a member
        /// </summary>
        /// <param name="id">ID of the member that is going to be edited</param>
        /// <returns></returns>
        // GET: members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            members members = db.members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorieID = new SelectList(db.categorie, "ID", "name", members.categorieID);
            ViewBag.ljID = new SelectList(db.lj, "ID", "license", members.ljID);
            ViewBag.locationID = new SelectList(db.locations, "ID", "city", members.locationID);
            ViewBag.lsID = new SelectList(db.ls, "ID", "license", members.lsID);
            return View(members);
        }

        /// <summary>
        /// Saves the edited member in the database
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        // POST: members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstname,lastname,insertion,bondsnr,cg,paratt,dateborn,gender,membersince,adres,housenumber,suffix,postcode,city,phonennumber,mobilenumber,email,categorieID,locationID,ljID,lsID")] members members)
        {
            if (ModelState.IsValid)
            {
                db.Entry(members).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categorieID = new SelectList(db.categorie, "ID", "name", members.categorieID);
            ViewBag.ljID = new SelectList(db.lj, "ID", "license", members.ljID);
            ViewBag.locationID = new SelectList(db.locations, "ID", "city", members.locationID);
            ViewBag.lsID = new SelectList(db.ls, "ID", "license", members.lsID);
            return View(members);
        }

        /// <summary>
        /// Gets the member that is going to be deleted
        /// </summary>
        /// <param name="id">ID of the selected member</param>
        /// <returns></returns>
        // GET: members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            members members = db.members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        /// <summary>
        /// Confirms that the member is deleted and deletes it from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            members members = db.members.Find(id);
            db.members.Remove(members);
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
