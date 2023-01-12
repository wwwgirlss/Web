using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MCSDD22.Models
{
    public class MCSDD22Context:DbContext //繼承DB context類別
    {
        public MCSDD22Context():base("name=MCSDD22Connection") //這是建構子
        {
        
        }
        //這段的用意是要只連線資料庫的字串(DB First在用的)
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        //描述資料庫裏面的資料表
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<PayTypes> PayTypes { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        
    }
}