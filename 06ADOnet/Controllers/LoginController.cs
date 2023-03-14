using _06ADOnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;//DataSet去連到網頁的
using System.Data.SqlClient;//去連資料庫的
using System.Configuration;//讀取Web.config



namespace _06ADOnet.Controllers
{
    public class LoginController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        GetData gd = new GetData();


        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(VMLogin vMLogin)
        //{
        //    var emp= db.Employees.Where(e => e.LastName == vMLogin.Account && e.FirstName == vMLogin.Password).FirstOrDefault();

        //    if (emp == null)
        //    {
        //        ViewBag.ErrMsg = "帳號或密碼有誤";
        //        return View();
        //    }

        //    //若帳號密碼打對,則登入成功,跳轉至後台管理首頁
        //    Session["emp"] = emp; //把登入成功的狀態報留在Session["emp"]裡面 //View只要跨過action就沒有了//Session可以判斷使用者的身分跟可以使用的功能

        //    return RedirectToAction("Index", "Customers");
        //}
        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            //string sql = "Select * from Employees where LastName='" + vMLogin.Account +"' and FirstName='" + vMLogin.Password +"'";

            string sql = "Select * from Employees where LastName=@id and FirstName=@pw";

            List<SqlParameter> list = new List<SqlParameter>
            {
            new SqlParameter("id", vMLogin.Account),
            new SqlParameter("pw", vMLogin.Password)
            };


            var rd = gd.LoginQuery(sql, list);
            if (rd == null)
            {
                return View();
            }

            if (rd.HasRows)
            {
                Session["emp"] = rd;
                rd.Close();
                return RedirectToAction("Index", "Customers");
            }

            ViewBag.ErrMsg = "帳號或密碼有誤";
            rd.Close();
            return View();


        }


            public ActionResult Logout()
            {
                Session["emp"] = null; /*登出的重點*/
                return RedirectToAction("Login"); /*讓使用者導回去("Login")登入頁面*/
            }
        }
    }
