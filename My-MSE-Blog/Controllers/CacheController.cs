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
    public static class CacheController
    {

        public static IQueryable<IBlogPost> GetBlogPosts(MyIBL ibl)
        {
            lock (typeof(CacheController))
            {
                IQueryable<IBlogPost> blogPosts = (IQueryable<IBlogPost>)HttpRuntime.Cache["BlogPosts"];
                if (blogPosts == null)
                {
                    blogPosts = ibl.GetPostList();
                    HttpRuntime.Cache.Insert("BlogPosts", blogPosts);
                }
                return blogPosts;
            }
        }

        public static void UpdateBlogPosts(MyIBL ibl)
        {
            IQueryable<IBlogPost> blogPosts = ibl.GetPostList();
            HttpRuntime.Cache.Insert("BlogPosts", blogPosts);
        }

        public static IQueryable<IUser> GetUsers(MyIBL ibl)
        {
            lock (typeof(CacheController))
            {
                IQueryable<IUser> users = (IQueryable<IUser>)HttpRuntime.Cache["Users"];
                if (users == null)
                {
                    users = ibl.GetUserList();
                    HttpRuntime.Cache.Insert("Users", users);
                }
                return users;
            }
        }

        public static void UpdateUsers(MyIBL ibl)
        {
            IQueryable<IUser> users = ibl.GetUserList();
            HttpRuntime.Cache.Insert("Users", users);
        }

    }
}
