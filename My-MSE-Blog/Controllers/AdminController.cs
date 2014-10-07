using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMSEBlog.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListUser()
        {
            var bl = new MyMSEBlog.Core.BL.BL(new MyMSEBlog.Core.DAL.FileDAL(Server.MapPath("~/App_Data/Repository.xml")));
            return View(bl.GetUserList().Skip(0).Take(25));
        }
    }
}