using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineToss.Models;

namespace OnlineToss.Controllers
{
    public class BornTimesController : Controller
    {
        private testpro2Entities db = new testpro2Entities();

        // GET: BornTimes
        public ActionResult Index()
        {
            
            return View(db.BornTimes.ToList());
        }

        // GET: BornTimes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BornTimes bornTimes = db.BornTimes.Find(id);
            if (bornTimes == null)
            {
                return HttpNotFound();
            }
            return View(bornTimes);
        }

        // GET: BornTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BornTimes/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BornTimeID,BornTimeName")] BornTimes bornTimes)
        {
            if (ModelState.IsValid)
            {
                db.BornTimes.Add(bornTimes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bornTimes);
        }

        // GET: BornTimes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BornTimes bornTimes = db.BornTimes.Find(id);
            if (bornTimes == null)
            {
                return HttpNotFound();
            }
            return View(bornTimes);
        }

        // POST: BornTimes/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BornTimeID,BornTimeName")] BornTimes bornTimes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bornTimes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bornTimes);
        }

        // GET: BornTimes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BornTimes bornTimes = db.BornTimes.Find(id);
            if (bornTimes == null)
            {
                return HttpNotFound();
            }
            return View(bornTimes);
        }

        // POST: BornTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BornTimes bornTimes = db.BornTimes.Find(id);
            db.BornTimes.Remove(bornTimes);
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
