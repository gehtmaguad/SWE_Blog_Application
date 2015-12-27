using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSE.SWE.Interfaces;
using Autofac;
using MyMSEBlog.Core.BL;
using MyMSEBlog.Core.Interfaces;
using MyMSEBlog.Controllers;
using MyMSEBlog.Models;

namespace MyMSEBlog.Uebungen
{
    public class UEB5 : IUEB5
    {
        public void HelloWorld()
        {
        }


        public void SetupContainer(Autofac.ContainerBuilder builder)
        {
            {
                builder.RegisterType<BL>()
                    .As<MyIBL>()
                    .As<IBL>()
                    .InstancePerLifetimeScope();

                builder.RegisterType<AdminUserController>()
                    .As<IAdminUserController>()
                    .InstancePerDependency();

                builder.RegisterType<UserViewModel>()
                    .As<IUserViewModel>()
                    .InstancePerDependency();
            }
        }
    }
}
