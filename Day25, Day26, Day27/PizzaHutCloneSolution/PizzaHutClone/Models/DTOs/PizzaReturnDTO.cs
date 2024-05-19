namespace PizzaHutClone.Models.DTOs
{
    public class PizzaReturnDTO
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double PriceInRupees { get; set; }
        public bool InStock { get; set; }
    }
}
