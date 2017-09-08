using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace Architect.Project
{
    public class UnityWebApiResolver : IDependencyResolver
    {
        private IUnityContainer container;
        public UnityWebApiResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this.container = container;
        }
        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityWebApiResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch(ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
           try
            {
                return container.ResolveAll(serviceType);
            }
            catch(ResolutionFailedException)
            {
                return null;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }
    }
}