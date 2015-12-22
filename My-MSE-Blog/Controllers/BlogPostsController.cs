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
    public class BlogPostsController : Controller, IBlogPostsController
    {
        MyIBL _bl;

        public BlogPostsController()
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

        public BlogPostsController(MyIBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index(int page = 0)
        {
            EnsureBL();
            return View(_bl.GetPostList().Skip(page * 25).Take(25));
        }

        public ActionResult Create()
        {
            return View(new BlogPostViewModel());
        }

        [HttpPost]
        public ActionResult Create(BlogPostViewModel vmdl)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            IBlogPost blogPost = CopyViewModelData(vmdl);

            _bl.AddPost(blogPost);
            _bl.SaveChanges();

            return View(vmdl);
        }

        private IBlogPost CopyViewModelData(BlogPostViewModel vmdl)
        {
            IBlogPost blogPost = new MyMSEBlog.Core.DAL.BlogPost();

            blogPost.Content = vmdl.Content;
            // TODO: Improve this
            blogPost.CreatedBy = _bl.GetUser(1);
            blogPost.CreatedOn = new DateTime();
            blogPost.IsDeleted = false;
            blogPost.Summary = vmdl.Summary;
            blogPost.Tags = vmdl.Tags;
            blogPost.Title = vmdl.Title;

            return blogPost;
        }

        public ActionResult Edit(int id)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            return View(new BlogPostViewModel(_bl.GetPost(id)));
        }

        [HttpPost]
        public ActionResult Edit(int id, BlogPostViewModel vmdl)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            _bl.DeletePost(_bl.GetPost(id));
            _bl.SaveChanges();

            IBlogPost blogPost = CopyViewModelData(vmdl);

            _bl.AddPost(blogPost);
            _bl.SaveChanges();

            return View(vmdl);
        }

        public ActionResult Details(int id)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            return View(new BlogPostViewModel(_bl.GetPost(id)));
        }

        public ActionResult Delete(int id)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            return View(new BlogPostViewModel(_bl.GetPost(id)));
        }

        [HttpPost]
        public ActionResult Delete(int id, BlogPostViewModel vmdl)
        {
            if (_bl == null)
            {
                EnsureBL();
            }

            _bl.DeletePost(_bl.GetPost(id));
            _bl.SaveChanges();

            return View();
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
