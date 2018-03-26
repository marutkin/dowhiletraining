using DoWhileTrain.App_Start;
using DoWhileTrain.Contracts;
using DoWhileTrain.Controllers;
using DoWhileTrain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace DoWhileTrain
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ITrainingTypesRepository, TrainingTypesRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrainingRepository, TrainingRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrainingApparatusRepository, TrainingApparatusRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
