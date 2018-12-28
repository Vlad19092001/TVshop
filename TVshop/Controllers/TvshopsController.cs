using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TVshop.Models;

namespace TVshop.Controllers
{
    public class TvshopsController : Controller
    {
        private TvContext db = new TvContext();
        public PagingInfo PagingInfo { get; set; }
        public int pageSize = 2;

        // GET: Tvshops

        public ActionResult Index(int page = 1)
        {
            IEnumerable<Tvshop> tvs = db.TvShops;
            var Tvs = tvs
            .OrderBy(tv => tv.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = tvs.Count()
            };
            ViewBag.Tv = Tvs;
            ViewBag.PagingInfo = PagingInfo;
            return View();
        }

        // GET: Tvshops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvshop tvshop = db.TvShops.Find(id);
            if (tvshop == null)
            {
                return HttpNotFound();
            }
            return View(tvshop);
        }

        // GET: Tvshops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tvshops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Marka,Dioganal,Model,Colors")] Tvshop tvshop)
        {
            if (ModelState.IsValid)
            {
                db.TvShops.Add(tvshop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tvshop);
        }

        // GET: Tvshops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvshop tvshop = db.TvShops.Find(id);
            if (tvshop == null)
            {
                return HttpNotFound();
            }
            return View(tvshop);
        }

        // POST: Tvshops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Marka,Dioganal,Model,Colors")] Tvshop tvshop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tvshop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tvshop);
        }

        // GET: Tvshops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tvshop tvshop = db.TvShops.Find(id);
            if (tvshop == null)
            {
                return HttpNotFound();
            }
            return View(tvshop);
        }

        // POST: Tvshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tvshop tvshop = db.TvShops.Find(id);
            db.TvShops.Remove(tvshop);
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
