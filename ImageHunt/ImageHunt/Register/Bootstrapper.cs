using CommonServiceLocator;
using ImageHunt.ViewModels;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace ImageHunt.Register
{
    public static class Bootstrapper
    {
        private static readonly UnityContainer _container = new UnityContainer();

        public static void RegisterDependencies()
        {
            _container.RegisterType<MainPageViewModel>(new ContainerControlledLifetimeManager());

            var locator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        public static void RegisterPlatformDependency<TInterface, TImplementation>(ITypeLifetimeManager lifetimeManager)
        {
            _container.RegisterType(typeof(TInterface), typeof(TImplementation), lifetimeManager);
        }
    }
}
