using OnlineToss.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineToss.Controllers
{
    [LoginCheck(id = 1)]
    public class MemberOrderController : Controller
    {
        // GET: MemberOrder

         testpro2Entities db = new testpro2Entities();

        // GET: MemberOrder
        public ActionResult Order()
        {
            //ViewBag.MemID = new SelectList(db.Members, "MemID", "MemName");
            ViewBag.ShipID = new SelectList(db.ShippingMethod, "ShipID", "ShipName");
            ViewBag.PayID = new SelectList(db.PaymentType, "PayID", "PayName");
            ViewBag.OrderDate = DateTime.Today.ToShortDateString();

            //隨機取一個員工處理訂單
            int endNum = db.Employees.Count();
            //Random()幾個人
            Random r = new Random();
            ViewBag.Employee = db.Employees.OrderBy(m => m.EmpID).Skip(r.Next(endNum)).Take(1).FirstOrDefault();//隨機塞一個員工處理訂單

            return View();
        }

        [HttpPost]
        public ActionResult Order(Orders orders, string cartData)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("MemID", ((Members)Session["member"]).MemID ),
                 new SqlParameter("PayID",orders.PayID),
                  new SqlParameter("ShipID",orders.ShipID),
                   new SqlParameter("ShipAdd",orders.ShipAdd),
                    new SqlParameter("ShipName",orders.ShipName),
                     new SqlParameter("EmpID",orders.EmpID),
                     new SqlParameter("cart",cartData)

            };
            setData sd = new setData();
            sd.executeSqlBySP("addOrders", list);
            TempData["cartFlag"] = "OK";

            return RedirectToAction("MyOrderList");
        }

        public ActionResult MyOrderList()
        {
            
            var memID = ((Members)Session["member"]).MemID;
            var orders = db.Orders.Where(m => m.MemID == memID).ToList();

            return View(orders);
        }
    }
}