using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSE.SWE.Interfaces;
using MyMSEBlog.Controllers;
using MyMSEBlog.Models;

namespace MyMSEBlog.Uebungen
{
    public class UEB1 : IUEB1
    {
        public void HelloWorld()
        {
            // I'm fine
        }

        public MSE_SWE.Interfaces.IAdminController GetAdminController()
        {
            return new AdminController();
        }

        public MSE_SWE.Interfaces.IAdminUserController GetAdminUserController()
        {
            return new AdminUserController();
        }

        public IBL GetBL(IDAL dal)
        {
            return new MyMSEBlog.Core.BL.BL(dal);
        }

        public MSE_SWE.Interfaces.IBlogPostsController GetBlogPostController()
        {
            throw new NotImplementedException();
        }

        public MSE_SWE.Interfaces.IBlogPostViewModel GetBlogPostViewModel(MSE_SWE.Interfaces.IBlogPost mdl)
        {
            throw new NotImplementedException();
        }

        public IDAL GetDAL(string filename)
        {
            return new MyMSEBlog.Core.DAL.FileDAL(filename);
        }

        public MSE_SWE.Interfaces.IUserViewModel GetUserViewModel(MSE_SWE.Interfaces.IUser mdl)
        {
            return new UserViewModel(mdl);
        }

        public MSE_SWE.Interfaces.IAdminUserController GetAdminUserController(IBL bl)
        {
            return new AdminUserController(bl);
        }

        public MSE_SWE.Interfaces.IBlogPostsController GetBlogPostController(IBL bl)
        {
            throw new NotImplementedException();
        }
    }
}
