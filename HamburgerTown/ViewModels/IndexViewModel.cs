using Microsoft.AspNetCore.Mvc.Rendering;

namespace HamburgerTown.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            HamburgerList = new List<Hamburger>();
            Order = new Order();
            BeverageList = new List<Beverage>();
        }
        public List<Hamburger> HamburgerList { get; set; }
        public List<Beverage> BeverageList { get; set; }
        public int BeveragesId { get; set; }
        public Order Order { get; set; }
        public List<Size> BoyutList { get; set; }
        public int SizeId { get; set; }
        public IList<SelectListItem> Extras { get; set; }
        public int HamburgerCount { get; set; }
    }
}
