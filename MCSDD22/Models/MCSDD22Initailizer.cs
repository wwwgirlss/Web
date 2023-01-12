using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MCSDD22.Models
{
    public class MCSDD22Initailizer:DropCreateDatabaseAlways<MCSDD22Context>
    {
        protected override void Seed(MCSDD22Context db)
        {
            base.Seed(db);

            /////////
            ///建立某些資料表的基礎資料

            List<Shippers> shippers = new List<Shippers>
            {
                new Shippers
                {
                ShipVia="到店取貨"
                },
                new Shippers
                {
                ShipVia="宅配到府"
                },
                new Shippers
                {
                ShipVia="郵寄"
                },
            };

            shippers.ForEach(s => db.Shippers.Add(s));
            db.SaveChanges();


            List<PayTypes> payTypes = new List<PayTypes>
            {
                 new PayTypes
                {
                    PayTypeName="信用卡"
                },
                new PayTypes
                {
                    PayTypeName="Line Pay"
                },
                new PayTypes
                {
                    PayTypeName="貨到付款"
                },
                new PayTypes
                {
                    PayTypeName="到店取貨付款"
                }
            };

            payTypes.ForEach(s => db.PayTypes.Add(s));
            db.SaveChanges();




            List<Employees> employees = new List<Employees>
            {
                new Employees
                {
                    EmployeeName="白冰冰",
                    CreatedDate=DateTime.Today,
                    Account="admin",
                    Password="12345678"
                }
            };

            employees.ForEach(s => db.Employees.Add(s));
            db.SaveChanges();


            List<Members> members = new List<Members>
            {
                new Members
                {
                    MemberName="莊肖為",
                    MemberBirthday=Convert.ToDateTime("1999/10/10"),
                    CreatedDate=DateTime.Today,
                    Account="shiao",
                    Password="12345678"
                }
            };

            members.ForEach(s => db.Members.Add(s));
            db.SaveChanges();

        }
    }
}