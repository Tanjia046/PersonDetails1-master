using PersonDetails.Controllers;
using PersonDetails.Database;
using PersonDetails.Repositories.Implementation;
using PersonDetails.Repositories.Interface;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace PersonDetails
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            #region Identity Entity Config & DB ConnectionString Alias
            container.RegisterType<DbContext, PersonDbContext>(new Unity.Lifetime.HierarchicalLifetimeManager());
            #endregion

            #region Repository Alias
            container.RegisterType<IPersonsRepository, PersonsRepository>();



            #endregion

            #region Manager Alias
            container.RegisterType<IPersonManager, PersonManager>();


            #endregion          
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}