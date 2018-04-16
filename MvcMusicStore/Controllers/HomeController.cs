using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Loger;
using MvcMusicStore.Models;
using PerformanceCounterHelper;
using MvcMusicStore.Infrastructure;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();
        private readonly ILogger _logger;
        private static readonly CounterHelper<StoreCounters> CounterHelper;

        static HomeController()
        {
            CounterHelper = PerformanceHelper.CreateCounterHelper<StoreCounters>("Test counter project");
        }

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }




        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            _logger.Info("Home page started");

            CounterHelper.Increment(StoreCounters.GoToHome);

            return View(await _storeContext.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}