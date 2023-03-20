using OnlineToss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Net;
using OnlineToss.ViewModels;

namespace OnlineToss.Controllers
{
    public class HomeController : Controller
    {
        testpro2Entities db = new testpro2Entities();
        // GET: Home
        public ActionResult Index()
        {
            var products = db.Products.ToList();


            return View(products);

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            

            var user = db.Members.Where(m => m.Account == vMLogin.Account && m.Password == vMLogin.Password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return View(vMLogin);
            }

            Session["member"] = user;//Session來判斷使用者是誰
            return RedirectToAction("Index");
        }


        [LoginCheck(id = 1)]
        public ActionResult Logout()
        {
            Session["member"] = null;
            return RedirectToAction("Login");
        }


        public ActionResult Display(string id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        public ActionResult MyCart()
        {
            return View();
        }
    }
}