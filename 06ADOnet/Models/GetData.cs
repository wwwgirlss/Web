using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _06ADOnet.Models
{
    public class GetData
    {
        //1.建立資料連線物件
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString); //ConfigurationManager--(存取name[NorthwindConnection]
        //2.建立SQL命令物件--通用性的物件法文翻成俄文
        SqlCommand cmd = new SqlCommand("", conn);/*要塞值先給空值""*/
        //3.建立資料讀取物件
        SqlDataReader rd;

        public SqlDataReader LoginQuery(string sql, List<SqlParameter> para)
        {
            cmd.CommandText = sql;

            foreach (SqlParameter p in para)
            {
                cmd.Parameters.Add(p);

            }

            conn.Open();
            try
            {

                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);//rd會去資料庫取資料到dataset
                rd.Read();
                //int i = 0;
                //i = 1 / i;

            }
            catch
            {
                //return rd;
                conn.Close();
            }

            //Session["emp"] = rd[0]; //[0]讀第一筆資料
            //conn.Close();//有open就要close很重要經常忘記沒關掉使用者端會佔據Dataset記憶體
            //return RedirectToAction("Index", "Customers");


            return rd;

        }

    }
}