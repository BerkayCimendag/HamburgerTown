using Microsoft.AspNetCore.Mvc;

namespace HamburgerTown.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BeverageController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BeverageController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var iceceklerlerListesi = _db.Beverages.ToList();
            return View(iceceklerlerListesi);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Ekle(Beverage ıcecek)
        {
            if (ModelState.IsValid)
            {
                _db.Beverages.Add(ıcecek);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Guncelle(int id)
        {
            var guncellenecekIcecek = _db.Beverages.Find(id);
            TempData["Id"] = guncellenecekIcecek!.Id;
            return View(guncellenecekIcecek);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Guncelle(Beverage icecek)
        {
            var guncellenecekIcecek = _db.Beverages.Find(TempData["Id"]);
            if (ModelState.IsValid)
            {
                guncellenecekIcecek!.BeverageName = icecek.BeverageName;
                guncellenecekIcecek.Price = icecek.Price;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(icecek);
        }

        public IActionResult Sil(int id)
        {
            var silinecekIcecek = _db.Beverages.Find(id);
            _db.Beverages.Remove(silinecekIcecek!);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
