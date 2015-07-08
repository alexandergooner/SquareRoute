using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
//using SquareRouteProject.Infastructure.EntityFramework;
using SquareRouteProject.Domain;
using SquareRouteProject.Presentation.Identity;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using SquareRouteProject.Infastructure;
using System;

namespace SquareRouteProject.Presentation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("Mvc5IdentityExample"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}