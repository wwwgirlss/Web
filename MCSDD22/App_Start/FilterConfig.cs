using MCSDD22.Controllers;
using System.Web;
using System.Web.Mvc;

namespace MCSDD22
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                View = "Error2"
            }); ;

            filters.Add(new LogReport());
        }
    }
}
