using Microsoft.AspNetCore.Mvc;

namespace HamburgerTown.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private readonly ApplicationDbContext _db;



        public SizeController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            var boyutlarListesi = _db.Sizes.ToList();
            return View(boyutlarListesi);
        }



        public IActionResult Ekle()
        {
            return View();
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Ekle(Size boyut)
        {
            if (ModelState.IsValid)
            {
                _db.Sizes.Add(boyut);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        public IActionResult Guncelle(int id)
        {
            var guncellenecekBoyut = _db.Sizes.Find(id);
            TempData["Id"] = guncellenecekBoyut!.Id;
            return View(guncellenecekBoyut);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Guncelle(Size boyut)
        {
            var guncellenecekBoyut = _db.Sizes.Find(TempData["Id"]);
            if (ModelState.IsValid)
            {
                guncellenecekBoyut!.SizeName = boyut.SizeName;
                guncellenecekBoyut.SizePrice = boyut.SizePrice;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(boyut);
        }



        public IActionResult Sil(int id)
        {
            var silinecekBoyut = _db.Sizes.Find(id);
            _db.Sizes.Remove(silinecekBoyut!);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
