using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSE.SWE.Interfaces;
using MyMSEBlog.Core.DAL;
using MyMSEBlog.Core.Interfaces;
using MyMSEBlog.Core.BL;
using MyMSEBlog.Models;
using System.Web;

namespace MyMSEBlog.Uebungen
{
    public class UEB2 : IUEB2
    {
        public void HelloWorld()
        {
        }


        public void SetupContainer(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<BL>()
                .As<MyIBL>()
                .As<IBL>()
                .InstancePerLifetimeScope();

            // Using physical path as parameter
            builder.RegisterType<FileDAL>()
                .As<IDAL>()
                .WithParameter(new TypedParameter(typeof(string),
                    "../App_Data/Repository.xml"))
                .InstancePerLifetimeScope();

            builder.RegisterType<UserViewModel>()
                .As<IUserViewModel>()
                .InstancePerDependency();

            builder.RegisterType<BlogPostViewModel>()
                .As<IBlogPostViewModel>()
                .InstancePerDependency();
        }
    }
}
