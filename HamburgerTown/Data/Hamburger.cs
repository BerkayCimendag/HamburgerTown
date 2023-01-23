namespace HamburgerTown.Data
{
    public class Hamburger
    {
        public int Id { get; set; }
        public string HamburgerName { get; set; } = null!;

        public string? Picture { get; set; }
        public decimal Price { get; set; }
    }
}
