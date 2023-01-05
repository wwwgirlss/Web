using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MCSDD22.Models
{
    public class Orders
    {
        [Key]
        [DisplayName("訂單編號")]
        public string OrderID { get; set; }

        [DisplayName("訂單成立時間")]
        public DateTime OrderDate { get; set; }

        [DisplayName("收貨人姓名")]
        public string ShipName { get; set; }

        [DisplayName("收貨人地址")]
        public string ShipAddress { get; set; }

        [DisplayName("出貨日")]
        public Nullable<DateTime> ShippedDate { get; set; }


        //Forign Key
        public int EmployeeID { get; set; }
        public int MemberID { get; set; }
        public int ShipID { get; set; }
        public int PayTypeID { get; set; }

        //拉關聯
        public virtual Employees Employees { get; set; }
        public virtual Members Members { get; set; }
        public virtual Shippers Shippers { get; set; }
        public virtual PayTypes PayTypes { get; set; }
    }
}