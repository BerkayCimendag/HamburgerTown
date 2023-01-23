namespace HamburgerTown.Data
{
    public class Order
    {
        public int OrderId { get; set; }

        public int Count { get; set; }
        public List<ExtraSupply>? ExtraSupplies { get; set; } = new List<ExtraSupply>();
        public Size Sizes { get; set; }

        public Beverage? Beverages { get; set; }

        public Hamburger Hamburgers { get; set; } = null!;
        public decimal  TotalFee { get; set; }

       
    }
}
