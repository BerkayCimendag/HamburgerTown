using Microsoft.AspNetCore.Mvc;

namespace HamburgerTown.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Dashboard : Controller
    {
        private readonly ApplicationDbContext _db;

        public Dashboard(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var orders = _db.Orders.Include(o => o.Hamburgers).Include(o => o.Beverages).Include(o => o.Sizes).Include(o => o.ExtraSupplies).ToList();
            return View(orders);

        }
    }
}
