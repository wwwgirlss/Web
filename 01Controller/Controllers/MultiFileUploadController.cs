using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class MultiFileUploadController : Controller
    {
        // GET: MultiFileUpload
        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photos)
        {
            if (photos != null)
            {
                foreach (var photo in photos)
                {
                    if (photo.ContentLength > 0)
                    {
                        photo.SaveAs(Server.MapPath("~/phoho/" + photo.FileName));
                        ViewBag.Message = "上傳成功";
                    }
                }

            }
            else
            {
                ViewBag.Message = "你上傳失敗 或 您沒有上傳任何檔案!!";
            }

            return View();
        }
    }
}