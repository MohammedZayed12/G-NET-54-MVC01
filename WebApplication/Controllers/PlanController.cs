using GymManagement.AppDpContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class PlanController : Controller
    {
        #region Fields
        private readonly AppDpContext _context;
        #endregion

        #region Constructors
        public PlanController(AppDpContext context)
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

        public async Task<IActionResult> details(int id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                //if the plan is not found,go back to the index page
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
        #endregion
    }
}
