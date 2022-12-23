//本區是Name Space(命名空間)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class Home1Controller : Controller
    {
        //修飾詞
        //public (指大家都能存取)
        //protected  (指我的家人才能存取,或跟我有關係的親戚)
        //private  (指我的家人才能存取)

        //這種函數是Controller裡的專用函數,稱做Action
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string ShowAry()
        {
            int[] score = { 99, 88, 77, 66, 55, 44 };
            int sum = 0;
            string show = "";

            foreach(int s in score)
            {
                sum += s;  //把陣列的值加總起來 sum=sum+s
                show += s + ", "; //把陣列讀出來,串成字串
            }

            show += " 總成績為" + sum;

            return show;

        }

        public string ShowImages()
        {
            string show = "";
            for (int i = 1; i <= 8; i++)
            {
                show += "<a href ='ShowImagesIndex?index="+i+"'> <img src ='../images/"+i+".jpg' width='300'/>";


            }
            return show;
            
            


        }
    }
}