using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSE.SWE.Interfaces;
using MyMSEBlog.Controllers;
using MyMSEBlog.Models;
using MyMSEBlog.Core.Interfaces;

namespace MyMSEBlog.Uebungen
{
    public class UEB1 : IUEB1
    {
        public void HelloWorld()
        {
            // I'm fine
        }

        public MSE.SWE.Interfaces.IAdminController GetAdminController()
        {
            return new AdminController();
        }

        public MSE.SWE.Interfaces.IAdminUserController GetAdminUserController()
        {
            return new AdminUserController();
        }

        public IBL GetBL(IDAL dal)
        {
            return new MyMSEBlog.Core.BL.BL(dal);
        }

        public MSE.SWE.Interfaces.IBlogPostsController GetBlogPostController()
        {
            return new BlogPostsController();
        }

        public MSE.SWE.Interfaces.IBlogPostViewModel GetBlogPostViewModel(MSE.SWE.Interfaces.IBlogPost mdl)
        {
            return new BlogPostViewModel(mdl);
        }

        public IDAL GetDAL(string filename)
        {
            return new MyMSEBlog.Core.DAL.FileDAL(filename);
        }

        public MSE.SWE.Interfaces.IUserViewModel GetUserViewModel(MSE.SWE.Interfaces.IUser mdl)
        {
            return new UserViewModel(mdl);
        }

        public MSE.SWE.Interfaces.IAdminUserController GetAdminUserController(IBL bl)
        {
            return new AdminUserController((MyIBL)bl);
        }

        public MSE.SWE.Interfaces.IBlogPostsController GetBlogPostController(IBL bl)
        {
            return new BlogPostsController((MyIBL)bl);
        }
    }
}
