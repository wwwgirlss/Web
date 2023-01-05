using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD22.Models
{
    public class PayTypes
    {
        [Key]
        public int PayTypeID { get; set; }

        [DisplayName("付款方式")]
        public string PayTypeName { get; set; }
    }
}