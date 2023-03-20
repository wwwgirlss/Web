using OnlineToss.Models;
using OnlineToss.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;//去連資料庫的
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;//DataSet去連到網頁的
using System.Configuration;//讀取Web.config

namespace OnlineToss.Controllers
{
    //[LoginCheck]
    public class HomeManagerController : Controller
    {
        testpro2Entities db = new testpro2Entities();
        // GET: HomeManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            var Memp = db.Employees.Where(e => e.Account == vMLogin.Account && e.Password == vMLogin.Password).FirstOrDefault();

            if (Memp == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return View();
            }

            //若帳號密碼打對,則登入成功,跳轉至後台管理首頁
            Session["Memp"] = Memp; 
            //把登入成功的狀態保留在Session["emp"]裡面 //View只要跨過action就沒有了
            //Session可以判斷使用者的身分跟可以使用的功能

            return RedirectToAction("Index", "HomeManager");
        }

        public ActionResult Logout()
        {
            Session["Memp"] = null;
            return RedirectToAction("Login");
        }
    }
}