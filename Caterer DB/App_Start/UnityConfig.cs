using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.AspNet.Identity;
using DataAccess.Model;
using DataAccess.Context;
using DataAccess.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Caterer_DB.Controllers;
using System.Web;
using DataAccess.Repositories;
using Business.Services;
using Business.Interfaces;
using Caterer_DB.Interfaces;
using Caterer_DB.Services;
using Caterer_DB.Models.ViewModelServices;
using Caterer_DB.Models.Interfaces;
using Common.Interfaces;
using Common.Services;

namespace Caterer_DB.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
        
            container.RegisterType<ICatererContext, CatererContext>(new PerResolveLifetimeManager());
          
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IFindCurrentUserService, FindCurrentUserService>();

            container.RegisterType<IBenutzerRepository, BenutzerRepository>();
            container.RegisterType<IBenutzerService, BenutzerService>();
            container.RegisterType<IBenutzerViewModelService, BenutzerViewModelService>();

            container.RegisterType<IBenutzerGruppeService, BenutzerGruppeService>();
            container.RegisterType<IBenutzerGruppeRepository, BenutzerGruppeRepository>();
            container.RegisterType<IBenutzerGruppeViewModelService, BenutzerGruppeViewModelService>();

            container.RegisterType<IRechtViewModelService, RechtViewModelService>();
            container.RegisterType<IRechtService, RechtService>();
            container.RegisterType<IRechtRepository, RechtRepository>();

            container.RegisterType<IRechteGruppeViewModelService, RechteGruppeViewModelService>();
            container.RegisterType<IRechteGruppeService, RechteGruppeService>();
            container.RegisterType<IRechteGruppeRepository, RechteGruppeRepository>();

            container.RegisterType<IMailService, MailService>();
            container.RegisterType<IMd5Hash, MD5Hash>();

        }
    }
}
