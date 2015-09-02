using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using ServiceApi.DataAccess;

namespace ACS.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register((c, p) => new CrewParserDA("http://api.duckduckgo.com/?q=star+trek+deep+space+nine+characters&format=json&p")).As<ICrewDA>();
            builder.Register((c, p) => new CrewManifestJsonDA("~/App_Data/crewmanifest.json")).As<ICrewManifestDA>();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public class MyDependencyResolver : IDependencyResolver {            

            public object GetService(Type serviceType) {
                throw new NotImplementedException();
            }

            public IEnumerable<object> GetServices(Type serviceType) {
                throw new NotImplementedException();
            }

            public IDependencyScope BeginScope() {
                throw new NotImplementedException();
            }

            public void Dispose()
            {

            }
        }
    }
}
