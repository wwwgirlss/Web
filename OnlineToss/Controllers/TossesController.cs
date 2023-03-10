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
    public class TossesController : Controller
    {
        private testpro2Entities db = new testpro2Entities();

        // GET: Tosses
        public ActionResult Index()
        {
            return View(db.Toss.ToList());
        }

        // GET: Tosses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toss toss = db.Toss.Find(id);
            if (toss == null)
            {
                return HttpNotFound();
            }
            return View(toss);
        }

        // GET: Tosses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tosses/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TossID,TossName,Content,Poetry,Explain,Description,TPhoto,PhotoPath")] Toss toss)
        {
            if (ModelState.IsValid)
            {
                db.Toss.Add(toss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toss);
        }

        // GET: Tosses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toss toss = db.Toss.Find(id);
            if (toss == null)
            {
                return HttpNotFound();
            }
            return View(toss);
        }

        // POST: Tosses/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TossID,TossName,Content,Poetry,Explain,Description,TPhoto,PhotoPath")] Toss toss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toss);
        }

        // GET: Tosses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toss toss = db.Toss.Find(id);
            if (toss == null)
            {
                return HttpNotFound();
            }
            return View(toss);
        }

        // POST: Tosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Toss toss = db.Toss.Find(id);
            db.Toss.Remove(toss);
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
