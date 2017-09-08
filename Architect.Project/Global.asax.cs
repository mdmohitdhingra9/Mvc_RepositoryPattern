using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Application.Dal;
using Architect.Models.Models;
using System.Web.Http;
using System.Web.Routing;

namespace Architect.Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootStrapper.Load();
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Application.Dal.Migrations.Configuration>());
            //CreateDataBase();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception exception = Server.GetLastError();
            //Response.Clear();
            //Server.ClearError();
            //Response.Redirect(string.Format("~/Error", exception));


            //ViewResult view = new ViewResult();
            //view.ViewName = "Error";
            //Request.RequestContext.HttpContext.Error
            //LogException logDetails = new LogException()
            //{
            //    Message = Context.ApplicationException.Message,
            //    Url = filterContext.HttpContext.Request.Url.ToString(),
            //    UserId = filterContext.HttpContext.User.Identity.Name,
            //    Source = filterContext.Exception.StackTrace,
            //    Type = filterContext.Exception.GetType().Name
            //};
            //Logger.Log(logDetails);
        }

        private void CreateDataBase()
        {
            var context = new ApplicationDbContext();
            
            context.Database.Initialize(true);

            //var context1 = new ArchitectDbContext();
            //context1.Database.Initialize(true);
        }
    }
}
