using MSE_SWE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMSEBlog.Controllers
{
    public class AdminController : Controller, IAdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}