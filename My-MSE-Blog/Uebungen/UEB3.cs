using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSE.SWE.Interfaces;
using MyMSEBlog.Core.DAL;
using MyMSEBlog.Core.BL;
using MyMSEBlog.Core.Interfaces;

namespace MyMSEBlog.Uebungen
{
    public class UEB3 : IUEB3
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
                    "C:/Users/gehtmaguad/Technikum/FH SWE Projekt/My-MSE-Blog/App_Data/Repository.xml"))
                .InstancePerLifetimeScope();

            builder.RegisterType<User>()
                .As<IUser>()
                .InstancePerDependency();

            builder.RegisterType<BlogPost>()
                .As<IBlogPost>()
                .InstancePerDependency();
        }
    }
}
