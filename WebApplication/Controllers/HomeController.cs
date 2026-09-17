using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GymManagement.AppDpContext;
using GymManagement.Models;

namespace GymManagement.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly GymManagement.AppDpContext.AppDpContext _context;
        #endregion

        #region Constructors
        public HomeController(GymManagement.AppDpContext.AppDpContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        public IActionResult Index()
        {
            var plans = _context.Plans.ToList();
            return View(plans);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
