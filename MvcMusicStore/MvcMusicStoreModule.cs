using MvcMusicStore.Loger;
using Ninject.Modules;
using log4net;

namespace MvcMusicStore
{
    public class MvcMusicStoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(context => LogManager.GetLogger(context.Request.Target?.Member.ReflectedType));
            Bind<ILogger>().To<Logger>();
        }
    }
}