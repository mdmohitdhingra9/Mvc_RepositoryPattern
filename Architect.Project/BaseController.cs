using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architect.DAL.Log;
using Architect.Models.Models;

namespace Architect.Project
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //LogException logDetails = new LogException()
            //{
            //    Message = filterContext.Exception.Message,
            //    Url = filterContext.HttpContext.Request.Url.ToString(),
            //    UserId = filterContext.HttpContext.User.Identity.Name,
            //    Source = filterContext.Exception.StackTrace,
            //    Type = filterContext.Exception.GetType().Name
            //};
            //Logger.Log(logDetails);
            //ViewResult view = new ViewResult();
            //view.ViewName = "Error";
            //filterContext.Result = view;
            //filterContext.ExceptionHandled = true;
        }

    }
}