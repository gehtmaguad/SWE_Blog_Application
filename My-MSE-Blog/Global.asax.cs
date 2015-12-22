
﻿using Autofac;
using Autofac.Integration.Mvc;
using MSE.SWE.Interfaces;
using MyMSEBlog.Core.BL;
using MyMSEBlog.Core.DAL;
using MyMSEBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMSEBlog
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");

			routes.MapRoute (
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = "" }
			);

		}

		public static void RegisterGlobalFilters (GlobalFilterCollection filters)
		{
			filters.Add (new HandleErrorAttribute ());
		}

        public static void RegisterAutofac(HttpServerUtility server)
        {
            // DOC: http://docs.autofac.org/en/v3.5.2/integration/mvc.html
            // DOC: http://docs.autofac.org/en/v3.5.2/register/registration.html
            // DOC: https://github.com/autofac/Autofac/tree/master/samples/AutofacWebApiSample

            // Create the builder with which components/services are registered.
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register instances of objects you create...
            builder.RegisterInstance(new FileDAL(server.MapPath("~/App_Data/Repository.xml"))).As<IDAL>();

            // Register types that expose interfaces...
            builder.RegisterType<BL>().As<MyIBL>().As<IBL>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			RegisterGlobalFilters (GlobalFilters.Filters);
			RegisterRoutes (RouteTable.Routes);
            RegisterAutofac(Server);
		}
	}
}
