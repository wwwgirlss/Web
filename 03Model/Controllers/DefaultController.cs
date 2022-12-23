using _03Model.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03Model.Controllers
{
    public class DefaultController : Controller
    {
        //建立一個dbStudentEntities物件取名叫db
       dbSutdentEntities db=new dbSutdentEntities();
        public ActionResult Index()
        {
            //var r = from s in db.tSrudent
            //        select s;

            var students = db.tStudent.ToList();

            
            return View(students);

        }
        //新增
        public ActionResult Create() 
        {
         return View();
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken] //網頁權杖,等於驗證器
        public ActionResult Create(tStudent student)
        {
            //檢查PK是否重複
            var id = student.fStuId;
            var result = db.tStudent.Find(id);
            if (result != null)  //代表PK重複
            {
                ViewBag.ErrMsg = "學號錯誤或重複!!";
                return View(student);
            }




            if (ModelState.IsValid)
            {

                db.tStudent.Add(student);//把表單值新增至模型
                db.SaveChanges();//把資料寫入資料庫
                                 //Insert into tStudent values(tStudent.fStuId,tStudent.fName,tStudent.Email,tStudent.Score)


                return RedirectToAction("Index");
            }

            return View(student);

        }

        public ActionResult Delete(string id)
        {
            //delete from tStudent where fStuId=id

            var student = db.tStudent.Find(id);//Find只能用在primary key
            db.tStudent.Remove(student);
            db.SaveChanges();



            return RedirectToAction("Index");


        }
            
    }
}

//套件1:jquery.validation
//套件2:Microsoft.jQuery.Unobtrusive.Validation