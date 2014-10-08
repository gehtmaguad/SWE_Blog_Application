using MSE.SWE.Interfaces;
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
        IBL _bl;

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

        public AdminUserController(IBL bl)
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
            // TODO: Implementation
            return View();
        }

        [HttpPost]
        ActionResult Create(UserViewModel vmdl)
        {
            // TODO: Implementation
            return View();
        }

        public ActionResult Edit(int id)
        {
            // TODO: Implementation
            return View();
        }

        [HttpPost]
        ActionResult Edit(int id, UserViewModel vmdl)
        {
            // TODO: Implementation
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // TODO: Implementation
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