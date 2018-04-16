using Ninject.Web.Common.WebHost;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using MvcMusicStore.Infrastructure;
using PerformanceCounterHelper;

namespace MvcMusicStore
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private void RegisterServices(IKernel kernel)
        {
            kernel.Load(new MvcMusicStoreModule());
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var counterHelper = PerformanceHelper.CreateCounterHelper<StoreCounters>("Test counter project"))
            {
                counterHelper.RawValue(StoreCounters.GoToHome, 0);
                counterHelper.RawValue(StoreCounters.LogInSuccess, 0);
                counterHelper.RawValue(StoreCounters.LogOffSuccess, 0);
            }
        }
    }
}
