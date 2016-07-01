using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Practices.Unity.Mvc;
using Newtonsoft.Json;
using Owin;
using SignalRDashboard.Data.Core.Hubs.Models;
using SignalRDashboard.Web;
using SignalRDashboard.Web.Utilities;

[assembly: OwinStartup(typeof(Startup))]
namespace SignalRDashboard.Web
{
    public partial class Startup
    {
        private static readonly Lazy<JsonSerializer> JsonSerializerFactory = new Lazy<JsonSerializer>(GetJsonSerializer);

        private static JsonSerializer GetJsonSerializer()
        {
            return new JsonSerializer
            {
                ContractResolver = new FilteredCamelCasePropertyNamesContractResolver
                {
                    AssembliesToInclude = AssembliesContainingHubModels()              
                }
            };
        }

        /// <summary>
        /// Finds all assemblies in the current app domain that contain Hub Model classes that derive
        /// from <see cref="DashboardHubModel"/>. These models are returned to connected SignalR clients, and 
        /// we want property names to be camelCased.
        /// </summary>
        /// <returns>hashset of assemblies to include in the JsonSerializer contract resolver</returns>
        private static HashSet<Assembly> AssembliesContainingHubModels()
        {
            return new HashSet<Assembly>(AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof (DashboardHubModel).IsAssignableFrom(type))
                .Select(type => type.Assembly)
                .Distinct());
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.GetConfiguredContainer()));
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => JsonSerializerFactory.Value);
        }
    }
}
