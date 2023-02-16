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
    public class ShippingMethodsController : Controller
    {
        private testpro2Entities db = new testpro2Entities();

        // GET: ShippingMethods
        public ActionResult Index()
        {
            return View(db.ShippingMethod.ToList());
        }

        // GET: ShippingMethods/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = db.ShippingMethod.Find(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // GET: ShippingMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingMethods/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipID,ShipName,Fee")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                db.ShippingMethod.Add(shippingMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shippingMethod);
        }

        // GET: ShippingMethods/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = db.ShippingMethod.Find(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: ShippingMethods/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipID,ShipName,Fee")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shippingMethod);
        }

        // GET: ShippingMethods/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = db.ShippingMethod.Find(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: ShippingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ShippingMethod shippingMethod = db.ShippingMethod.Find(id);
            db.ShippingMethod.Remove(shippingMethod);
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
