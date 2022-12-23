﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _04ViewModel.Models;


namespace _04ViewModel.ViewModels
{
    public class EmpDept
    {
        public List<tDepartment> department { get; set; }
        public List<tEmployee> employee { get; set; }
        //List是泛型的資料型態<tEmployee> employee是資料表名稱 
    }
}