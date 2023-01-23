using Microsoft.AspNetCore.Mvc;

namespace HamburgerTown.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExtraSupplyController : Controller
    {
        private readonly ApplicationDbContext _db;



        public ExtraSupplyController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ekstraMalzemelerListesi = _db.ExtraSupplies.ToList();
            return View(ekstraMalzemelerListesi);
        }



        public IActionResult Ekle()
        {
            return View();
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Ekle(ExtraSupply ekstraMalzeme)
        {
            if (ModelState.IsValid)
            {
                _db.ExtraSupplies.Add(ekstraMalzeme);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        public IActionResult Guncelle(int id)
        {
            var guncellenecekEkstraMalzeme = _db.ExtraSupplies.Find(id);
            TempData["Id"] = guncellenecekEkstraMalzeme!.Id;
            return View(guncellenecekEkstraMalzeme);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Guncelle(ExtraSupply ekstraMalzeme)
        {
            var guncellenecekEkstraMalzeme = _db.ExtraSupplies.Find(TempData["Id"]);
            if (ModelState.IsValid)
            {
                guncellenecekEkstraMalzeme!.ExtraSupplyName = ekstraMalzeme.ExtraSupplyName;
                guncellenecekEkstraMalzeme.Price = ekstraMalzeme.Price;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ekstraMalzeme);
        }



        public IActionResult Sil(int id)
        {
            var silinecekEkstraMalzeme = _db.ExtraSupplies.Find(id);
            _db.ExtraSupplies.Remove(silinecekEkstraMalzeme!);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
