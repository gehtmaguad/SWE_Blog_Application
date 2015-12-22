using MSE.SWE.Interfaces;
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
            IUser user = CopyViewModelData(vmdl);

            _bl.AddUser(user);
            _bl.SaveChanges();

            return View(vmdl);
        }

        private IUser CopyViewModelData(UserViewModel vmdl)
        {
            IUser user = new MyMSEBlog.Core.DAL.User();

            user.BirtDate = new DateTime();
            user.EMail = vmdl.EMail;
            user.FirstName = vmdl.FirstName;
            user.Group = vmdl.Group;
            user.IsDeleted = vmdl.IsDeleted;
            user.LastName = vmdl.LastName;
            user.MiddleName = vmdl.MiddleName;
            user.NeedPasswordReset = vmdl.NeedPasswordReset;
            user.PasswordHash = "test";
            user.ValidationToken = vmdl.ValidationToken;

            return user;
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

            IUser user = CopyViewModelData(vmdl);

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
            return View(new UserViewModel(_bl.GetUser(id)));
        }

        [HttpPost]
        public ActionResult Delete(int id, UserViewModel vmdl)
        {
            _bl.DeleteUser(_bl.GetUser(id));
            _bl.SaveChanges();

            return View();
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