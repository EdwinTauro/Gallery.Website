﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gallery.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        //private ISessionFactory _sessionFactory;
        //private Configuration _configuration;

        //private void LoadDb()
        //{
        //    _configuration = new Configuration();
        //    _configuration.Configure();
        //    //_configuration.AddAssembly("FirstSolutionNHibernate");
        //    _sessionFactory = _configuration.BuildSessionFactory();
        //    //_configuration.AddFile(".\\Mappings\\Account.hbm.xml");

        //}
    }
}