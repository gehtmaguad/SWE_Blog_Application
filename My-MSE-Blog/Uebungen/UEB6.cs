using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSE.SWE.Interfaces;
using Autofac;
using MyMSEBlog.Core.BL;
using MyMSEBlog.Core.Interfaces;

namespace MyMSEBlog.Uebungen
{
    public class UEB6 : IUEB6
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
        }
    }
}
