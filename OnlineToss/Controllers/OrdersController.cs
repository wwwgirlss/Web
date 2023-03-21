using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineToss.Models;
using System.Data.SqlClient;

namespace OnlineToss.Controllers
{
    [LoginCheck]
    public class OrdersController : Controller
    {
        public testpro2Entities db = new testpro2Entities();
        


        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Employees).Include(o => o.Members).Include(o => o.PaymentType).Include(o => o.ShippingMethod);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var result = db.Database.SqlQuery<string>("SELECT dbo.getOrderID()").FirstOrDefault();

            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "EmpName");
            ViewBag.MemID = new SelectList(db.Members, "MemID", "MemName");
            ViewBag.PayID = new SelectList(db.PaymentType, "PayID", "PayName");
            ViewBag.ShipID = new SelectList(db.ShippingMethod, "ShipID", "ShipName");
            return View();
        }

        // POST: Orders/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,MemID,OrderDate,PayID,ShipID,ShipAdd,ShipName,ShipDate,EmpID")] Orders orders, string connectionString)
        {
            if (ModelState.IsValid)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("getOrderID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@orderId";
                    outputParameter.SqlDbType = SqlDbType.Int;
                    outputParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);

                    connection.Open();
                    command.ExecuteNonQuery();
                    int orderId = (int)outputParameter.Value;

                    // 使用 orderId 新增資料
                }


                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "EmpName", orders.EmpID);
            ViewBag.MemID = new SelectList(db.Members, "MemID", "MemName", orders.MemID);
            ViewBag.PayID = new SelectList(db.PaymentType, "PayID", "PayName", orders.PayID);
            ViewBag.ShipID = new SelectList(db.ShippingMethod, "ShipID", "ShipName", orders.ShipID);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "EmpName", orders.EmpID);
            ViewBag.MemID = new SelectList(db.Members, "MemID", "MemName", orders.MemID);
            ViewBag.PayID = new SelectList(db.PaymentType, "PayID", "PayName", orders.PayID);
            ViewBag.ShipID = new SelectList(db.ShippingMethod, "ShipID", "ShipName", orders.ShipID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,MemID,OrderDate,PayID,ShipID,ShipAdd,ShipName,ShipDate,EmpID")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "EmpName", orders.EmpID);
            ViewBag.MemID = new SelectList(db.Members, "MemID", "MemName", orders.MemID);
            ViewBag.PayID = new SelectList(db.PaymentType, "PayID", "PayName", orders.PayID);
            ViewBag.ShipID = new SelectList(db.ShippingMethod, "ShipID", "ShipName", orders.ShipID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
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
