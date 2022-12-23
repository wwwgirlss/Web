using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _03HW1_1Controller : Controller
    {
        //第一題,判斷質數 //寫一個程式判斷n是不是質數
        public string No1(int n)
        {

            if (n < 2)
            {
                return (n + "不是質數");
            }

            for (int i = 2; i < n; i++)
                if (n % i == 0)
                {

                    return (n + "不是質數");

                }

            return (n + "是質數");

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

            while (M % N != 0)
            {
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

            do
            {
                r = N % 10; //餘數,數得N的個位數
                q = N / 10; //商數,數得N的個位數以外的數字
                N = q; //把商數變成下一次的被除數

                result = result * 10 + r;  //把數字倒過來排的結果
            } while (q != 0);

            if (n == result)
                return n + "是迴文";

            return n + "不是迴文";
        }


        //第四題,發牌程式
        public void No4()
        {


            //1.用迴圈依序將牌擺入陣列中
            //2.用迴圈及亂數將陣列中的牌順序打亂(洗牌)
            //3.用迴圈依序讀出陣列中的牌,分成四份,並顯示於網頁上(發牌)



            //1.用迴圈依序將牌擺入陣列中
            string[] poker = new string[52];


            for (int i = 0; i < poker.Length; i++)
            {

                poker[i] = (i + 1).ToString();

            }
            Response.Write("<h2>原始牌列:</h2>");

            for (int i = 0; i < poker.Length; i++)
            {

                Response.Write("<img src='../poker_img/" + poker[i] + ".gif' />");
            }

            Response.Write("<hr />");


            //2.用迴圈及亂數將陣列中的牌順序打亂(洗牌)
            Random r = new Random();
            //r.Next(0, 52);  //產生0~51的隨機整數
            int temp = 0;
            string t = "";

            //交換陣列位置
            //寫一個兩數交換的演算法
            Response.Write("<h2>洗牌三次:</h2>");
            for (int j = 0; j < 3; j++)   
            {
                for (int i = 0; i < poker.Length; i++)
                {
                    temp = r.Next(0, poker.Length);  //隨機取一個0~51的值放到temp變數
                    t = poker[i];  //把第一個陣列位置 的值 丟到t變數裡

                    poker[i] = poker[temp];  //把隨機的一個陣列位置 的值 丟到第一個陣列位置裡

                    poker[temp] = t; //把t變數裡 的值 丟到 剛剛的隨機陣列位置
                }
                
            }
            
            for (int i = 0; i < 52; i++)
            {
                
                Response.Write("<img src='../poker_img/" + poker[i] + ".gif' />");
            }

            Response.Write("<hr />");


            string p1 = "", p2 = "", p3 = "", p4 = "";
            string result = "";
            for (int i = 0; i < poker.Length; i++)
            {
               

                result = "<img src='../poker_img/" + poker[i] + ".gif' />";

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
            Response.Write("<h2> 這裡是發牌結果: </h2>");
            Response.Write("我是玩家1:" + p1 + "<br>");
            Response.Write("我是玩家2:" + p2 + "<br>");
            Response.Write("我是玩家3:" + p3 + "<br>");
            Response.Write("我是玩家4:" + p4);
        }

    }
}




