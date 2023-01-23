namespace HamburgerTown.Data
{
    public class ExtraSupply
    {

        public int Id { get; set; }
        public string ExtraSupplyName { get; set; } = null!;
        public decimal Price { get; set; }

        public Order? Order { get; set; }
    }
}
