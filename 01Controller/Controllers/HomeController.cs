//本區是Name Space(命名空間)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class HomeController : Controller
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
            int[] score = { 78, 90, 20, 100, 66, 77 };
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
            for(int i = 1; i <= 8; i++)
            {
                show += "<a href='ShowImagesIndex?index="+i+"'><img src='../images/"+i+".jpg' width='300' /></a>";
            }

            return show;
        }


        public string ShowImagesIndex(int index)
        {
            string show = "";

            string[] name = { "櫻桃鴨", "鴨油高麗菜", "鴨油麻婆豆腐", "櫻桃鴨握壽司", "片皮鴨捲三星蔥", "三杯鴨", "櫻桃鴨片肉", "慢火白菜燉鴨湯" };

            //第一種寫法,字串串接
            //show = "<p style='text-align:center'><img src='../images/" + index + ".jpg' /></p><h3 style='text-align:center'>" + name[index-1] + "</h3><br /><div style='text-align:right'><a href='ShowImages'>回上一頁</a></div>";
            //show += "<br /><div style='text-align:right'><a href='ShowImages'>回上一頁</a></div>";

            //第二種寫法,字串格式函數
            show = string.Format("<p style='text-align:center'><img src='../images/{0}.jpg' /></p><h3 style='text-align:center'>{1}</h3><br /><div style='text-align:right'><a href='ShowImages'>回上一頁</a></div>", index, name[index-1]);


            return show;
        }

    }
}