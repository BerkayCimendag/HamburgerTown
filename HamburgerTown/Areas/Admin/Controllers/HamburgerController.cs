using HamburgerTown.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerTown.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HamburgerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly Hamburger _hamburger;



        public HamburgerController(ApplicationDbContext db, Hamburger hamburger)
        {
            _db = db;
            _hamburger = hamburger;
        }



        public IActionResult Index()
        {
            //Hamburgerler listesini getirir.
            var hamburgerlerListesi = _db.Hamburgers.ToList();
            return View(hamburgerlerListesi);
        }



        public IActionResult Ekle() // Ekleme view'ını Getirir
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(HamburgerViewModel hamburgerViewModel)
        //Hamburgeri db'ye ekle ve güncel Hamburger listesi görünümüne git (Hamburger hamburger)
        //Formdan gelen HamburgerViewModel nesnesini yakalayıp, özelliklerini hakiki hamburger'e atayıp db'ye ekleyeceğiz.



        {
            if (hamburgerViewModel.HamburgerPrice <= 0)
            {
                return View();
            }



            try
            {
                //resim yüklediyse resmin adını GUID + uzantısını formatında DB'de tut. Kendisi de images klasörüne kaydet
                if (hamburgerViewModel.HamburgerPicture != null)
                {
                    //Önce resmin uzantısını çekelim
                    //var uzanti = Path.GetExtension(hamburgerViewModel.HamburgerResmi.FileName);



                    //Daha sonra dosyamızın adını oluşturalım 
                    //GUID + uzanti şeklinde...
                    var dosyaAdi = hamburgerViewModel.HamburgerPicture.FileName;



                    //Sonra dosyanın kaydedileceği konum belirlenir
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", dosyaAdi);



                    //Sonra dosya için bir akış ortamı oluşturulur. Kaydetmek için ortam hazırlıyoruz.
                    var akisOrtami = new FileStream(konum, FileMode.Create);



                    //Resmi o klasöre kaydet 
                    hamburgerViewModel.HamburgerPicture.CopyTo(akisOrtami);
                    akisOrtami.Close();



                    //Resmi o klasöre kaydettiniz
                    //_db'ye de sadece dosya adını ekle
                    _hamburger.Picture = dosyaAdi;
                }
                //Formdan gelenler
                //Automapper ile daha kolay olur.



                _hamburger.HamburgerName = hamburgerViewModel.HamburgerName;
                _hamburger.Price = hamburgerViewModel.HamburgerPrice;



                if (_db.Hamburgers.FirstOrDefault(u => u.HamburgerName == _hamburger.HamburgerName) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                //_db ye ekleme olacak.
                _db.Hamburgers.Add(_hamburger);
                _db.SaveChanges();



            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }



        //Gönderilen Id'ye ait hamburgeri getir ve post etmek için tekrar view'a yolla
        public IActionResult Guncelle(int id)
        {
            Hamburger guncelenecekHamburger = _db.Hamburgers.Find(id)!;
            HamburgerViewModel hamburgerViewModel = new HamburgerViewModel();
            hamburgerViewModel.HamburgerName = guncelenecekHamburger.HamburgerName;
            hamburgerViewModel.HamburgerPrice = guncelenecekHamburger.Price;
            TempData["Id"] = guncelenecekHamburger.Id;
            return View(hamburgerViewModel);
        }



        [HttpPost]
        public IActionResult Guncelle(HamburgerViewModel hamburgerViewModel)
        {
            try
            {
                var guncelenecekHamburger = _db.Hamburgers.Find((int)TempData["Id"]!);



                if (hamburgerViewModel.HamburgerPicture != null)
                {
                    var dosyaAdi = hamburgerViewModel.HamburgerPicture.FileName;
                    if (guncelenecekHamburger!.Picture == dosyaAdi)
                    {
                        return RedirectToAction(nameof(Index));
                    }



                    //Sonra dosyanın kaydedileceği konum belirlenir
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", dosyaAdi);



                    //Sonra dosya için bir akış ortamı oluşturulur. Kaydetmek için ortam hazırlıyoruz.
                    var akisOrtami = new FileStream(konum, FileMode.Create);



                    //Resmi o klasöre kaydet 
                    hamburgerViewModel.HamburgerPicture.CopyTo(akisOrtami);
                    akisOrtami.Close();



                    //Resmi o klasöre kaydettiniz
                    //_db'ye de sadece dosya adını ekle
                    guncelenecekHamburger.Picture = dosyaAdi;
                }
                guncelenecekHamburger!.HamburgerName = hamburgerViewModel.HamburgerName;
                guncelenecekHamburger.Price = hamburgerViewModel.HamburgerPrice;



                var digerHamburgerler = _db.Hamburgers.Except(_db.Hamburgers.Where(u => u.Id == guncelenecekHamburger.Id)).ToList();



                if (digerHamburgerler.Any(u => u.HamburgerName == guncelenecekHamburger.HamburgerName))
                {
                    return RedirectToAction(nameof(Index));
                }
                _db.Hamburgers.Update(guncelenecekHamburger);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction(nameof(Index)); //Güncelledikten sonra yine hamburger listesine git
        }
        public IActionResult Sil(int id)
        {
            Hamburger silinecekHamburger = _db.Hamburgers.Find(id)!;
            if (silinecekHamburger == null)
            {
                return NotFound();
            }
            _db.Hamburgers.Remove(silinecekHamburger);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult ResimKaldir(int id)
        {
            Hamburger resmiSilinecekHamburger = _db.Hamburgers.Find(id)!;
            if (resmiSilinecekHamburger.Picture == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var resimAdi = resmiSilinecekHamburger.Picture;
            resmiSilinecekHamburger.Picture = null;
            _db.Hamburgers.Update(resmiSilinecekHamburger);
            _db.SaveChanges();



            //Bu resmi kullanan başka hamburger yoksa resmi de sil.
            var silinecekHamburgerlerHaricindekiHamburgerler = _db.Hamburgers.Except(_db.Hamburgers.Where(u => u.Id == resmiSilinecekHamburger.Id));
            var resmiKullananBaskaYok = silinecekHamburgerlerHaricindekiHamburgerler.All(u => u.Picture != resimAdi);



            if (resmiKullananBaskaYok)
            {
                //resimler klasörünün olduğu yerdeki dosyaları al.
                //her kullanıcı kendi yolunu kendi yolunu vermeli getfiles'ın içine
                string[] dosyalar = Directory.GetFiles("C:\\Users\\Asus\\Desktop\\HamburgerTown\\HamburgerTown\\wwwroot\\img\\");



                //Bu dosyalardan silmek istediğimizi bulup sileceğiz.
                foreach (var item in dosyalar)
                {
                    var resimIsmiDizisi = item.Split("\\");



                    //Artık dosya adı bu resim dizisinin son elemanı oldu
                    if (resimIsmiDizisi[resimIsmiDizisi.Length - 1] == resimAdi)
                    {
                        System.IO.File.Delete(item);
                        break;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
