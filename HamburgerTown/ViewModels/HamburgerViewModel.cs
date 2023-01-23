using System.ComponentModel.DataAnnotations;

namespace HamburgerTown.ViewModels
{
    public class HamburgerViewModel
    {
        [Required(ErrorMessage = "{0} Alanı Boş Olamaz!")]
        public string HamburgerName { get; set; } = null!;



        [Required(ErrorMessage = "{0} Alanı Boş Olamaz!")]
        public decimal HamburgerPrice { get; set; }



        public IFormFile? HamburgerPicture { get; set; }
    }
}
