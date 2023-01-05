using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MCSDD22.Models
{
    public class Employees
    {   //這裡很重要!這裡很重要!這裡很重要!這裡文字不能敲錯,否則之後資料在建立資料庫時,程式兩端對不起來而無法建立成功!!
        [Key]
        [DisplayName("員工編號")]
        public int EmployeeID { get; set; }

        [DisplayName("員工姓名")]
        [StringLength(40, ErrorMessage = "員工姓名不可超過40字")]
        [Required(ErrorMessage = "請填寫員工姓名")]
        public string EmployeeName { get; set; }

        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]/*{0:yyyy-MM-dd hh:mm}hh:mm 時間*//*ApplyFormatInEditMode =true編輯模式顯示格式*/
        [DataType(DataType.DateTime)]
        [Required]//不能讓他自己填
        public DateTime CreatedDate { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不可以超過20字")]
        //[EmailAddress]注意文字長度和ErrorMessage(如果是用EMAIL當作帳號)
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}")]/*{5,20}最少五個字最多20字*/
        public string Account { get; set; }

        //欄位開頭用小寫

        //field
        string password;

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]//會跑黑點看不到密碼
        [MinLength(8,ErrorMessage ="密碼最少8碼")]
        [MaxLength(20, ErrorMessage = "密碼最多20碼")]
        //[StringLength(20)]
      
        //P屬性用大寫
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                //我們要先把 Password收到的value做雜湊,再把值給password
                password = BR.getHashPassword(value);
            }

        }

        //以下搬到BR去了
        ////這個是密碼雜湊的演算法method
        //string getHashPassword(string pw)
        //{
        //    byte[] hashValue;
        //    string result = "";


        //    System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();

        //    byte[] pwBytes = ue.GetBytes(pw);

        //    SHA256 shHash = SHA256.Create(); //SHA256是一種hash的演算法 是「安全雜湊演算法256 位元」(Secure Hash Algorithm 256-bit) 的英文縮寫
        //    //RIPEMD160 shHash = RIPEMD160.Create();
        //    hashValue = shHash.ComputeHash(pwBytes);


        //    foreach (byte b in hashValue)
        //    {
        //        result += b.ToString();
        //    }

        //    return result;
        //}



        //做密碼的時候要做"雜湊"連有權限的管理員也看不到,必須只能做重置密碼,這是一個商業邏輯
        //做加密有全縣的管理員還是可以解密看到密碼


        //int score;//屬性
        //public int Score {
        //    //get set屬性封裝這個類別變數中
        //    get
        //    {
        //        //if()
        //        //    return 0
        //        //else
        //        return score; 
        //    } 

        // set { 
        //        if(value< 0 )
        //            score = 0;
        //        else if(value > 100)
        //            score = 100;
        //        else
        //        score = value; 
        //    } 

    }



}
