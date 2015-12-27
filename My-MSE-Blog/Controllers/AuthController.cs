using MyMSEBlog.Core.Interfaces;
using MyMSEBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMSEBlog.Controllers
{
    public class AuthController : Controller
    {
        readonly MyIBL _bl;

        public AuthController()
        {
        }

        public AuthController(MyIBL bl)
        {
            _bl = bl;
        }

        public ActionResult LogIn()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult LogIn(UserViewModel vmdl)
        {
            bool IsAuth = _bl.Authenticate(vmdl.EMail, vmdl.PasswordHash);
            if (IsAuth == true)
            {
                Session["email"] = vmdl.EMail;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Json(new
                {
                    Success = IsAuth,
                    Message = IsAuth ? "You successfully authenticated" : "There was an error authenticating the given user"
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
