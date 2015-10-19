using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;


namespace ACS.StartTrekTesting
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var physicalFileSystem = new PhysicalFileSystem(@"C:\Work\Advanced\ACSStarTrek\ACS.Client");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };

            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[]
            {
                "index.html"
            };

            appBuilder.UseFileServer(options);

            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
                );

            appBuilder.UseWebApi(config);

        }
    }
}
