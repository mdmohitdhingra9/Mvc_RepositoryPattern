using Architect.DAL.Log;
using Architect.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Filters;
using System.Web.Http;

namespace Architect.Project
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            LogException logDetails = new LogException()
            {
                Message = filterContext.Exception.Message,
                Url = filterContext.HttpContext.Request.Url.ToString(),
                UserId = filterContext.HttpContext.User.Identity.Name,
                Source = filterContext.Exception.StackTrace,
                Type = filterContext.Exception.GetType().Name
            };
            Logger.Log(logDetails);
            ViewResult view = new ViewResult();
            view.ViewName = "Error";
            filterContext.Result = view;
            filterContext.Exception = logDetails;
            filterContext.ExceptionHandled = true;
        }
    }

    public class ApiErrorHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            LogException logDetails = new LogException()
            {
                Message = actionExecutedContext.Exception.Message,
                Url = actionExecutedContext.ActionContext.Request.RequestUri.ToString(),
                UserId = null,
                Source = actionExecutedContext.Exception.StackTrace,
                Type = actionExecutedContext.Exception.GetType().Name
            };
            Logger.Log(logDetails);
            actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
           // base.OnException(actionExecutedContext);
        }
    }
}