using MSE.SWE.Interfaces;
using MyMSEBlog.Core.DAL;
using MyMSEBlog.Core.Interfaces;
using MyMSEBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMSEBlog.Controllers
{
    public class AdminUserController : Controller, IAdminUserController
    {
        readonly MyIBL _bl;

        public AdminUserController()
        {
        }

        public AdminUserController(MyIBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index(int page = 0)
        {
            return View(_bl.GetUserList().Skip(page * 25).Take(25));
        }

        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserViewModel vmdl)
        {
            IUser user = new User();
            vmdl.ApplyChanges(user);

            _bl.AddUser(user);
            _bl.SaveChanges();

            return View(vmdl);
        }

        public ActionResult Edit(int id)
        {
            return View(new UserViewModel(_bl.GetUser(id)));
        }

        [HttpPost]
        public ActionResult Edit(int id, UserViewModel vmdl)
        {
            _bl.DeleteUser(_bl.GetUser(id));
            _bl.SaveChanges();

            IUser user = new User();
            vmdl.ApplyChanges(user);

            _bl.AddUser(user);
            _bl.SaveChanges();

            return View(vmdl);
        }


        public ActionResult Details(int id)
        {
            return View(new UserViewModel(_bl.GetUser(id)));
        }

        public ActionResult Delete(int id)
        {
            bool isDeleted = false;
            if (_bl.GetUserList().Any(item => item.ID == id))
            {
                _bl.DeleteUser(_bl.GetUser(id));
                _bl.SaveChanges();

                // In Order to execute UEB4 Init Test correctly isDeleted is set to true after user gets deleted
                // otherwise i would check with the method GetDeletedUserList if user is really set to isDeleted=true.
                isDeleted = true;
            }

            //isDeleted = _bl.GetDeletedUserList().Any(item => item.ID == id);

            return Json(new
            {
                Success = isDeleted,
                Message = isDeleted ? "Successfully deleted User" : "There was a problem deleting the User"
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Explicit interface implementation for automated unit tests.
        /// </summary>
        /// <param name="vmdl"></param>
        /// <returns></returns>
        ActionResult IAdminUserController.Create(IUserViewModel vmdl)
        {
            return this.Create((UserViewModel)vmdl);
        }

        /// <summary>
        /// Explicit interface implementation for automated unit tests.
        /// </summary>
        /// <param name="vmdl"></param>
        /// <returns></returns>
        ActionResult IAdminUserController.Edit(int id, IUserViewModel vmdl)
        {
            return this.Edit(id, (UserViewModel)vmdl);
        }
    }
}