using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineToss.Models;

namespace OnlineToss.Controllers
{
    public class EmployeesController : Controller
    {
        private testpro2Entities db = new testpro2Entities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        //[HttpGet]
        //public ActionResult Gender()
        //{
        //    //上下架的下拉選單的資料清單
        //    ViewData["Gender"] = new List<SelectListItem>()
        //    {
        //      new SelectListItem(){ Text="請選擇",Value="-1",Selected=true},
        //      new SelectListItem(){ Text="女",Value="true" },
        //      new SelectListItem(){ Text="男",Value="false" },
        //    };

        //    //IEnumerable<Employees> result = this.QueryData(10, 0, new FormCollection());

        //    return View();
        //}

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        //GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        //public ActionResult Create(Employees employee)
        //{
        //    using (SqlConnection connection = new SqlConnection("connectionString"))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("getEmpID", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            SqlParameter returnParameter = command.Parameters.Add("@returnVal", SqlDbType.Char, 6);
        //            returnParameter.Direction = ParameterDirection.ReturnValue;

        //            command.ExecuteNonQuery();

        //            string empID = (string)returnParameter.Value;

        //            employee.EmpID = empID;

        //            // Save the employee object to the database
        //            // ...

        //            return RedirectToAction("Index");
        //        }
        //    }
        //}

        //public string getEmpID()
        //{
        //    string newID = "";
        //    string lastID = "";

        //    using (SqlConnection connection = new SqlConnection("connectionString"))
        //    {
        //        connection.Open();

        //        SqlCommand cmd = new SqlCommand("getEmpID", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            lastID = reader.GetString(0);
        //        }

        //        if (lastID == "")
        //        {
        //            newID = "E00001";
        //        }
        //        else
        //        {
        //            int num = int.Parse(lastID.Substring(1)) + 1;
        //            newID = "E" + num.ToString().PadLeft(5, '0');
        //        }

        //        reader.Close();
        //    }

        //    return newID;
        //}



        // POST: Employees/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpName,Gender,Phone,Address,Birthday,Salary,Bdate,Notes,Manager,Email,Account,Password")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpName,Gender,Phone,Address,Birthday,Salary,Bdate,Notes,Manager,Email,Account,Password")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
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
