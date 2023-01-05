using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MCSDD22.Models
{
    public class Shippers
    {
        [Key]
        [DisplayName("運送編號")]
        public int ShipID { get; set; }

        [DisplayName("運送方式")]
        public string ShipVia { get; set; }
    }
}