using OnlineToss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

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
    }
}