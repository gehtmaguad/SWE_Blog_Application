using MSE.SWE.Interfaces;
using MyMSEBlog.Core.BL;
using MyMSEBlog.Core.DAL;
using MyMSEBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace MyMSEBlog.Controllers
{
    public class CacheController : Controller
    {
        static readonly MyIBL _bl;

        static CacheController()
        {
            _bl = DependencyResolver.Current.GetService<MyIBL>();
        }

        public static IQueryable<IBlogPost> GetBlogPosts()
        {
            lock (typeof(CacheController))
            {
                IQueryable<IBlogPost> blogPosts = (IQueryable<IBlogPost>)HttpRuntime.Cache["BlogPosts"];
                if (blogPosts == null)
                {
                    blogPosts = _bl.GetPostList();
                    HttpRuntime.Cache.Insert("BlogPosts", blogPosts);
                }
                return blogPosts;
            }
        }

        public static void UpdateBlogPosts()
        {
            IQueryable<IBlogPost> blogPosts = new BL(new FileDAL("C:/Users/gehtmaguad/Technikum/FH SWE Projekt/My-MSE-Blog/App_Data/Repository.xml")).GetPostList();
            HttpRuntime.Cache.Insert("BlogPosts", blogPosts);
        }

        public static IQueryable<IUser> GetUsers()
        {
            lock (typeof(CacheController))
            {
                IQueryable<IUser> users = (IQueryable<IUser>)HttpRuntime.Cache["Users"];
                if (users == null)
                {
                    users = _bl.GetUserList();
                    HttpRuntime.Cache.Insert("Users", users);
                }
                return users;
            }
        }

        public static void UpdateUsers()
        {
            IQueryable<IUser> users = new BL(new FileDAL("C:/Users/gehtmaguad/Technikum/FH SWE Projekt/My-MSE-Blog/App_Data/Repository.xml")).GetUserList();
            HttpRuntime.Cache.Insert("Users", users);
        }

    }
}
