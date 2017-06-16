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
    public class membersController : Controller
    {
        private DeltaImpulsContext db = new DeltaImpulsContext();

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

        // GET: members/Details/5
        public ActionResult Details(int? id)
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

        // GET: members/Create
        public ActionResult Create()
        {
            ViewBag.categorieID = new SelectList(db.categorie, "ID", "name");
            ViewBag.ljID = new SelectList(db.lj, "ID", "license");
            ViewBag.locationID = new SelectList(db.locations, "ID", "city");
            ViewBag.lsID = new SelectList(db.ls, "ID", "license");
            return View();
        }

        // POST: members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstname,lastname,insertion,bondsnr,cg,paratt,dateborn,gender,membersince,adres,postcode,city,phonennumber,mobilenumber,email,categorieID,locationID,ljID,lsID")] members members)
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

        // POST: members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstname,lastname,insertion,bondsnr,cg,paratt,dateborn,gender,membersince,adres,postcode,city,phonennumber,mobilenumber,email,categorieID,locationID,ljID,lsID")] members members)
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
