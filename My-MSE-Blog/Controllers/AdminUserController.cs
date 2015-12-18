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
        MyIBL _bl;

        public AdminUserController()
        {
        }

        /// <summary>
        /// Temporary. Will be replaced by a autofac solution.
        /// </summary>
        private void EnsureBL()
        {
            // TODO: Improve this!
            _bl = new MyMSEBlog.Core.BL.BL(new MyMSEBlog.Core.DAL.FileDAL(Server.MapPath("~/App_Data/Repository.xml")));
        }

        public AdminUserController(MyIBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index(int page = 0)
        {
            EnsureBL();
            return View(_bl.GetUserList().Skip(page * 25).Take(25));
        }

        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserViewModel vmdl)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            IUser user = new MyMSEBlog.Core.DAL.User();
            user.BirtDate = new DateTime();
            user.EMail = vmdl.EMail;
            user.FirstName = vmdl.FirstName;
            user.Group = new UserGroup();
            user.IsDeleted = vmdl.IsDeleted;
            user.LastName = vmdl.LastName;
            user.MiddleName = vmdl.MiddleName;
            user.NeedPasswordReset = vmdl.NeedPasswordReset;
            user.PasswordHash = "test";
            user.ValidationToken = vmdl.ValidationToken;

            _bl.AddUser(user);
            _bl.SaveChanges();

            return View(vmdl);
        }

        public ActionResult Edit(int id)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            return View(new UserViewModel(_bl.GetUser(id)));
        }

        [HttpPost]
        public ActionResult Edit(int id, UserViewModel vmdl)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            _bl.DeleteUser(_bl.GetUser(id));
            _bl.SaveChanges();

            IUser user = new MyMSEBlog.Core.DAL.User();
            user.BirtDate = new DateTime();
            user.EMail = vmdl.EMail;
            user.FirstName = vmdl.FirstName;
            user.Group = new UserGroup();
            user.IsDeleted = vmdl.IsDeleted;
            user.LastName = vmdl.LastName;
            user.MiddleName = vmdl.MiddleName;
            user.NeedPasswordReset = vmdl.NeedPasswordReset;
            user.PasswordHash = "test";
            user.ValidationToken = vmdl.ValidationToken;

            _bl.AddUser(user);
            _bl.SaveChanges();

            return View(vmdl);
        }


        public ActionResult Details(int id)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            return View(new UserViewModel(_bl.GetUser(id)));
        }

        public ActionResult Delete(int id)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            return View(new UserViewModel(_bl.GetUser(id)));
        }

        [HttpPost]
        public ActionResult Delete(int id, UserViewModel vmdl)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

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