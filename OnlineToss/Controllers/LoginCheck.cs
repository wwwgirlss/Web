using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace OnlineToss.Controllers
{
    public class LoginCheck : ActionFilterAttribute
    {
        public bool flag = true;

        public short id = 2;


        void MemberLoginState(HttpContext context)
        {

            if (context.Session["member"] == null)
            {
                context.Response.Redirect("/Home/Login");
            }
        }
        void AdminLoginState(HttpContext context)
        {

            if (context.Session["Memp"] == null)
            {
                context.Response.Redirect("/HomeManager/Login");
            }
        }




        public override void OnActionExecuting(ActionExecutingContext filterContex)
        {
            if (flag)
            {
                HttpContext context = HttpContext.Current;

                if (id == 1)
                    MemberLoginState(context);
                else
                    AdminLoginState(context);

            }
        }


    }
}