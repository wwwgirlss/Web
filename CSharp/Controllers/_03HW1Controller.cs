using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _03HW1Controller : Controller
    {
        //第一題,判斷質數
        public string No1(int n)
        {
            //寫一個程式判斷n是不是質數

            //做法參考
            //用迴圈,對n進行除法運算,看看他能不能被除了1或n以外的某個數整除
            //若可以,則n就不是質數

            if (n == 0 || n == 1)
                return n + "不是質數";

            for (int i = 2; i < n; i++)  //這裡的i值,會由2跑到n-1
            {
                if (n % i == 0)
                    return n + "不是質數";
            }

            return n + "是質數";

            ///////////////////////////////////////////////////////
            //bool flag = true;

            //for(int i = 2; i < n; i++)  //這裡的i值,會由2跑到n-1
            //{

            //    if (n % i == 0)
            //    {
            //        Response.Write(n + "不是質數");
            //        flag = false;
            //        break;
            //    }

            //}
            //if (flag)
            //    Response.Write(n + "是質數");

            }

        //第二題,找任意兩數之最大公因數
        public string No2(int n, int m)
        {
            //寫一個程式找出n與m的最大公因數

            //做法參考
            //不能使用短除法,要使用輾轉相除法
            //除到餘數為零時,當次的除數即為兩數的最大公因數

            int M = m, N = n;  //永遠把M當被除數,永遠把N當除數
            int z = 0; //這個變數來放餘數

            while (M % N != 0) {
                z = M % N;
                M = N;  //除數變被除數
                N = z;  //餘數變除數
            }

            return m + "與" + n + "的最大公因數為" + N;

        }


        //第三題,迴文判斷
        public string No3(int n)
        {
            //n=12321
            //n=12333321
            //寫一個程式判斷n是不是迴文

            //做法參考
            //將n倒過來排列,再與原來的n比較,若相等即是迴文

            //取個位數的做法 % 10
            //取個位數以外的數 /10

            int N = n, result = 0;
            int q = 0, r = 0;

             do {
                r = N % 10; //餘數,數得N的個位數
                q = N / 10; //商數,數得N的個位數以外的數字
                N = q; //把商數變成下一次的被除數

                result = result * 10 + r;  //把數字倒過來排的結果
            } while (q != 0) ;

            if (n == result)
                return n + "是迴文";

            return n + "不是迴文";
        }


        //第四題,發牌程式
        public void No4()
        {

            //for(int i = 1; i <= 52; i++)
            //{
            //    Response.Write("<img src='../poker_img/"+i+".gif' />");
            //}

            //鑄造亂數物件
            //Random r = new Random();
            //Response.Write(r.Next(1,100));

            //1.用迴圈依序將牌擺入陣列中
            //2.用迴圈及亂數將陣列中的牌順序打亂(洗牌)
            //3.用迴圈依序讀出陣列中的牌,分成四份,並顯示於網頁上(發牌)



            //1.用迴圈依序將牌擺入陣列中
            string[] poker = new string[52];

            //poker[0] = "1";
            //poker[1] = "2";
            //poker[2] = "3";
            //poker[3] = "4";
            //poker[4] = "5";
            //poker[5] = "6";
            //poker[6] = "7";
            //poker[7] = "8";
            //poker[8] = "9";

            //poker[51] = "52";

            for (int i = 0; i < poker.Length; i++)
            {
              
               poker[i] = (i+1).ToString();

            }

            //測試用
            for (int i = 0; i < poker.Length; i++)
            {
                //Response.Write(poker[i]+", ");
                Response.Write("<img src='../poker_img/" + poker[i] + ".gif' />");
            }

            Response.Write("<hr />");


            //2.用迴圈及亂數將陣列中的牌順序打亂(洗牌)
            Random r = new Random();
            //r.Next(0, 52);  //產生0~51的隨機整數
            int temp = 0;
            string t= "";

            //交換陣列位置
            //寫一個兩數交換的演算法
            for (int j = 0; j < 5;j++) {
                for (int i = 0; i < poker.Length; i++)
                {
                    temp = r.Next(0, poker.Length);  //隨機取一個0~51的值放到temp變數
                    t = poker[i];  //把第一個陣列位置 的值 丟到t變數裡

                    poker[i] = poker[temp];  //把隨機的一個陣列位置 的值 丟到第一個陣列位置裡

                    poker[temp] = t; //把t變數裡 的值 丟到 剛剛的隨機陣列位置
                }
            }
            //測試用
            for (int i = 0; i < 52; i++)
            {
                //Response.Write(poker[i]+", ");
                Response.Write("<img src='../poker_img/" + poker[i] + ".gif' />");
            }

            Response.Write("<hr />");

            //3.用迴圈依序讀出陣列中的牌,分成四份,並顯示於網頁上(發牌)
            //不應該這樣發
            //for(int i=0;i<13;i++)
            //    Response.Write(poker[i]);

            //for (int i = 13; i < 26; i++)
            //    Response.Write(poker[i]);

            //for (int i = 26; i < 39; i++)
            //    Response.Write(poker[i]);

            //for (int i = 39; i < 52; i++)
            //    Response.Write(poker[i]);

            /////////////////////////////////////
            ///
            //p1 = "<img src='../poker_img/" + poker[0] + ".gif' />";
            //p2 = "<img src='../poker_img/" + poker[1] + ".gif' />";
            //p3 = "<img src='../poker_img/" + poker[2] + ".gif' />";
            //p4 = "<img src='../poker_img/" + poker[3] + ".gif' />";

            //p1 = "<img src='../poker_img/" + poker[4] + ".gif' />";
            //p2 = "<img src='../poker_img/" + poker[5] + ".gif' />";
            //p3 = "<img src='../poker_img/" + poker[6] + ".gif' />";
            //p4 = "<img src='../poker_img/" + poker[7] + ".gif' />";

            //p1 = "<img src='../poker_img/" + poker[8] + ".gif' />";
            //p2 = "<img src='../poker_img/" + poker[9] + ".gif' />";
            //p3 = "<img src='../poker_img/" + poker[10] + ".gif' />";
            //p4 = "<img src='../poker_img/" + poker[11] + ".gif' />";

            string p1 = "", p2 = "", p3 = "", p4 = "";
            string result = "";
            for(int i = 0; i < poker.Length; i++)
            {
                //if (i%4==0)
                //    p1 += "<img src='../poker_img/" + poker[i] + ".gif' />";
                //else if(i % 4 == 1)
                //    p2 += "<img src='../poker_img/" + poker[i] + ".gif' />";
                //else if(i % 4 == 2)
                //    p3 += "<img src='../poker_img/" + poker[i] + ".gif' />";
                //else if (i % 4 == 3)
                //    p4 += "<img src='../poker_img/" + poker[i] + ".gif' />";

                result= "<img src='../poker_img/" + poker[i] + ".gif' />";

                switch (i % 4)
                {
                    case 0:
                        p1 += result;
                        break;
                    case 1:
                        p2 += result;
                        break;
                    case 2:
                        p3 += result;
                        break;
                    case 3:
                        p4 += result;
                        break;
                }
            }
            Response.Write("發牌結果:<br>");
            Response.Write("玩家1:" + p1 +"<br>");
            Response.Write("玩家2:" + p2 + "<br>");
            Response.Write("玩家3:" + p3 + "<br>");
            Response.Write("玩家4:" + p4);
        }

    }
}