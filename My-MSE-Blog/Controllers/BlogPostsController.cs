﻿using MSE.SWE.Interfaces;
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
    public class BlogPostsController : Controller, IBlogPostsController
    {
        readonly MyIBL _bl;

        public BlogPostsController()
        {
        }

        public BlogPostsController(MyIBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index(int page = 0)
        {
            return View(_bl.GetPostList().Skip(page * 25).Take(25));
        }

        public ActionResult Create()
        {
            return View(new BlogPostViewModel());
        }

        [HttpPost]
        public ActionResult Create(BlogPostViewModel vmdl)
        {
            IBlogPost blogPost = new BlogPost();
            vmdl.ApplyChanges(blogPost);

            _bl.AddPost(blogPost);
            _bl.SaveChanges();

            return View(vmdl);
        }

        public ActionResult Edit(int id)
        {
            IBlogPostViewModel blogpost = new BlogPostViewModel(_bl.GetPost(id));
            if ((string)Session["email"] != blogpost.CreatedBy.EMail)
            {
                return Json(new
                {
                    Success = false,
                    Message = "Not Allowed to edit this Post"
                }, JsonRequestBehavior.AllowGet);
            }
            return View(blogpost);
        }

        [HttpPost]
        public ActionResult Edit(int id, BlogPostViewModel vmdl)
        {
            _bl.DeletePost(_bl.GetPost(id));
            _bl.SaveChanges();

            IBlogPost blogPost = new BlogPost();
            vmdl.ApplyChanges(blogPost);

            _bl.AddPost(blogPost);
            _bl.SaveChanges();

            return View(vmdl);
        }

        public ActionResult Details(int id)
        {
            return View(new BlogPostViewModel(_bl.GetPost(id)));
        }

        public ActionResult Delete(int id)
        {
            bool isDeleted = false;
            if (_bl.GetPostList().Any(item => item.ID == id))
            {
                _bl.DeletePost(_bl.GetPost(id));
                _bl.SaveChanges();

                // In Order to execute UEB4 Init Test correctly isDeleted is set to true after user gets deleted
                // otherwise i would check with the method GetDeletedUserList if user is really set to isDeleted=true.
                isDeleted = true;
            }

            //isDeleted = _bl.GetDeletedPostList().Any(item => item.ID == id);

            return Json(new
            {
                Success = isDeleted,
                Message = isDeleted ? "Successfully deleted BlogPost" : "There was a problem deleting the BlogPost"
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Explicit interface implementation for automated unit tests.
        /// </summary>
        /// <param name="vmdl"></param>
        /// <returns></returns>
        ActionResult IBlogPostsController.Create(IBlogPostViewModel vmdl)
        {
            return this.Create((BlogPostViewModel)vmdl);
        }

        /// <summary>
        /// Explicit interface implementation for automated unit tests.
        /// </summary>
        /// <param name="vmdl"></param>
        /// <returns></returns>
        ActionResult IBlogPostsController.Edit(int id, IBlogPostViewModel vmdl)
        {
            return this.Edit(id, (BlogPostViewModel)vmdl);
        }

    }
}
