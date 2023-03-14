using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineToss.Models;

namespace OnlineToss.Controllers
{
    public class ProductsController : Controller
    {
        private testpro2Entities db = new testpro2Entities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Categories);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }
        
        //[ChildActionOnly]
        // GET: Products/Create
        public ActionResult _Create()
        {
            ViewBag.CaID = new SelectList(db.Categories, "CaID", "CaName");

            return PartialView();
        }

        // POST: Products/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProID,CaID,ProName,UnitPrice,Quantity,Photo,CreatedDate")] Products products)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(products);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CaID = new SelectList(db.Categories, "CaID", "CaName", products.CaID);
        //    return View(products);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,CaID,ProName,UnitPrice,Quantity,Photo,CreatedDate")] Products products, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    if (img.ContentLength > 0)
                    {
                        if (img.ContentLength <= 5242880)
                        {
                            var PhotoType = img.ContentType;//取得圖片類型

                            if (PhotoType == "image/jpg" || PhotoType == "image/png" || PhotoType == "image/jpeg")
                            {
                                products.Photo = new byte[img.ContentLength];
                                img.InputStream.Read(products.Photo, 0, img.ContentLength);
                                //products.ImageMimeType = imageMimeType;
                                products.PhotoType = img.ContentType;
                            }
                            else
                            {
                                ViewBag.Message = "圖片類型不支持";
                                return View(products);
                            }
                        }
                        else
                        {
                            ViewBag.Message = "檔案大於5M";
                            return View(products);
                        }
                    }
                    else
                    {
                        ViewBag.Message = "您傳的一個空檔案";
                        return View(products);
                    }
                }
                else
                {
                    ViewBag.Message = "您沒有上傳任何檔案";
                    return View(products);
                }

                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaID = new SelectList(db.Categories, "CaID", "CaName", products.CaID);
            return View(products);
        }


        public FileContentResult GetImage(string id)
        {
            var img = db.Products.Find(id);
            if (img != null)
            {
                return File(img.Photo, "image/jpeg");
            }
            
            return null;
        }

        //public FileResult GetImage(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    Products products = db.Products.Find(id);

        //    byte[] img = products.Photo.Skip(78).ToArray();

        //    //MemoryStream ms =new MemoryStream(photo);

        //    return File(img, "image/bmp");

        //}




        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaID = new SelectList(db.Categories, "CaID", "CaName", products.CaID);
            return View(products);
        }

        // POST: Products/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,CaID,ProName,UnitPrice,Quantity,Photo,CreatedDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaID = new SelectList(db.Categories, "CaID", "CaName", products.CaID);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
