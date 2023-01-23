using HamburgerTown.Models;
using HamburgerTown.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace HamburgerTown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

        public IActionResult Index()
        {
            return View();
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MakeOrder()
        {
            var model = new IndexViewModel();
            model.HamburgerList = _db.Hamburgers.ToList();
            model.BeverageList = _db.Beverages.ToList();
            model.Extras = _db.ExtraSupplies.Select(e => new SelectListItem()
            {
                Text = e.ExtraSupplyName + " " + e.Price,
                Value = e.Id.ToString(),
            }).ToList();
            model.BoyutList = _db.Sizes.ToList();
            
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult MakeOrder(IndexViewModel vm)
        {

            Order siparis = new Order();
            List<ExtraSupply> ekstraList = new List<ExtraSupply>();
            var secilenHamburger = _db.Hamburgers.Where(m => m.Id == vm.Order.Hamburgers.Id).FirstOrDefault();
            var secilenIcecek = _db.Beverages.Where(m => m.Id == vm.Order.Beverages.Id).FirstOrDefault();
            foreach (var item in vm.Extras)
            {
                if (item.Selected)
                {
                    ekstraList.Add(_db.ExtraSupplies.FirstOrDefault(e => e.Id == Convert.ToInt32(item.Value)));
                }
            }
            siparis.Count = vm.HamburgerCount;
            siparis.Hamburgers = secilenHamburger;
            siparis.Hamburgers.Picture = secilenHamburger.Picture;
            siparis.ExtraSupplies = ekstraList;
            siparis.Beverages = secilenIcecek;
            siparis.Sizes = _db.Sizes.Find(vm.SizeId);

            siparis.TotalFee = (siparis.Hamburgers.Price + siparis.Sizes.SizePrice + siparis.Beverages.Price) * siparis.Count;

            siparis.TotalFee += ekstraList.Sum(e => e.Price);

            _db.Orders.Add(siparis);
            _db.SaveChanges();
            return RedirectToAction("ShowOrder");
        }

        public IActionResult ShowOrder()
        {
            var lastOrder = _db.Orders
         .Include(o => o.Hamburgers)
         .Include(o => o.Beverages)
         .Include(o => o.Sizes)
         .Include(o => o.ExtraSupplies)
         .OrderByDescending(o => o.OrderId)
         .FirstOrDefault();
            return View(lastOrder);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}