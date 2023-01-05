using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCSDD22.Models
{
    public class OrderDetails
    {
        [Key]
        [DisplayName("訂單編號")]
        [Column(Order = 1)]
        public string OrderID { get; set; }

        [Key]
        [DisplayName("商品編號")]
        [Column(Order = 2)]
        public string ProductID { get; set; }

        [DisplayName("商品單價")]
        public short UnitPrice { get; set; }

        [DisplayName("數量")]
        public short Quantity { get; set; }

        //拉關聯
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }

    }
}