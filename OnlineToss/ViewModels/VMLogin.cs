using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineToss.ViewModels
{
    public class VMLogin
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        //[StringLength(20, ErrorMessage = "帳號不可以超過20字")] //[EmailAddress]注意文字長度和ErrorMessage(如果是用EMAIL當作帳號)
        //[RegularExpression("[0-9]{4,19}")]/*[A-Za-z][A-Za-z0-9]最少五個字最多20字*/
        public string Account { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}