using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;
using Architect.Project.Controllers;
using System.Web.Http;

namespace Architect.Project
{
    public static class BootStrapper
    {
       public static IUnityContainer Load()
        {
            var container = new UnityContainer();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromMatchingInterface, WithName.Default);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            // register dependency resolver for web api
            GlobalConfiguration.Configuration.DependencyResolver = new UnityWebApiResolver(container);
            return container;

        }

    }

   
}