﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04ViewModel.Models;
using _04ViewModel.ViewModels;

namespace _04ViewModel.Controllers
{
    public class tEmployeesController : Controller
    {
        //第一件事要做的是建立dbContext
        dbEmployeeEntities db = new dbEmployeeEntities();
        // private 是預設的
        //讀出tEmployee資料表,並建立成List
        public ActionResult Index(int deptId = 1)
        {
            //EmpDept emp = new EmpDept();

            //emp.department = db.tDepartment.ToList();
            //emp.employee = db.tEmployee.Where(e => e.fDepId == 1).ToList();


            //tDepartment department = new tDepartment()
            //{
            //    fDepName = "財務部",
            //    fDepId = 9
            //};



            EmpDept emp = new EmpDept()
            {
                department = db.tDepartment.ToList(),
                employee = db.tEmployee.Where(e => e.fDepId == deptId).ToList()
            };

            ViewBag.deptName = db.tDepartment.Find(deptId).fDepName;
            ViewBag.deptId = deptId;

            return View(emp);

            //var Emp=db.tEmployee.ToList();

            //Index Action
            //1讀出table.ToList
            //2.Return View 
            //3.建立View
            //4.在View裡讀出Date,並先 做測試

            //Model (新增模型是新增類別)
            //1.View model
            //2.Data model
        }
        public ActionResult Create()
        {
            ViewBag.Dept=db.tDepartment.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tEmployee employee)
        {
            var emp = db.tEmployee.Find(employee.fEmpId);
            if (emp != null) //PK重複
            {
                ViewBag.PKCheck = "警告!! 員工代號重複!!";
                //ViewBag.Dept = db.tDepartment.ToList();
                //return View(employee);
            }

            else if (ModelState.IsValid)
            {
                db.tEmployee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", new { deptId = employee.fDepId });
            }
            else
            { 
                ViewBag.Msg = "警告!! 驗證未通過,請檢查表單資料是否填寫正確!!";
            }

                ViewBag.Dept = db.tDepartment.ToList();
                return View(employee);
        }

        public ActionResult Edit(string id) //修改功能//(string id) //需要傳參數
        {
            var emp = db.tEmployee.Find(id);

            ViewBag.Dept = db.tDepartment.ToList();
            return View(emp);

         }

        [HttpPost]
        public ActionResult Edit(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                //db.tEmployee.Add(employee);
                //把dbContext設定為可被修改的狀態
                db.Entry(employee).State = EntityState.Modified; //Modified修改

                db.SaveChanges();
                return RedirectToAction("Index", new { deptId = employee.fDepId });
            }

            ViewBag.Msg = "警告!! 驗證未通過,請填寫正確!!";
            ViewBag.Dept = db.tDepartment.ToList();
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var emp = db.tEmployee.Find(id);
            db.tEmployee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { deptId = emp.fDepId });
        }


    }
}