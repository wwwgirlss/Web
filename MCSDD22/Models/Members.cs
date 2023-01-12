using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MCSDD22.Models
{
    public class Members
    {
        [Key]
        [DisplayName("會員編號")]
        public int MemberID { get; set; }

        [DisplayName("姓名")]
        [StringLength(40, ErrorMessage = "姓名不可超過40字")]
        [Required(ErrorMessage = "請填寫您的姓名")]
        public string MemberName { get; set; }

        [DisplayName("照片")]
        public string MemberPhotoFile { get; set; }

        [DisplayName("生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime MemberBirthday { get; set; }

        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]/*{0:yyyy-MM-dd hh:mm}hh:mm 時間*//*ApplyFormatInEditMode =true編輯模式顯示格式*/
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填您的寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不可以超過20字")]
        //[EmailAddress]注意文字長度和ErrorMessage(如果是用EMAIL當作帳號)
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}")]/*{5,20}最少五個字最多20字*/
        public string Account { get; set; }

        //field
        string password;

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]//會跑黑點看不到密碼
        //[MinLength(8, ErrorMessage = "密碼最少8碼")]
        //[MaxLength(20, ErrorMessage = "密碼最多20碼")]

        //[StringLength(20)]
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
        //這個是密碼雜湊的演算法method
        //string getHashPassword(string pw)
        //{
        //    byte[] hashValue;
        //    string result = "";


        //    System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();

        //    byte[] pwBytes = ue.GetBytes(pw);

        //    SHA256 shHash = SHA256.Create(); 
        //    hashValue = shHash.ComputeHash(pwBytes);


        //    foreach (byte b in hashValue)
        //    {
        //        result += b.ToString();
        //    }

        //    return result;
        //}

    }
}