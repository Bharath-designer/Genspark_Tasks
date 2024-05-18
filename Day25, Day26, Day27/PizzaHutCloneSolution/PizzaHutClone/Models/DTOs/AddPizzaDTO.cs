namespace PizzaHutClone.Models.DTOs
{
    public class AddPizzaDTO
    {
        public string? Name { get; set; }
        public double PriceInRupees { get; set; }
        public bool InStock { get; set; }
    }
}
